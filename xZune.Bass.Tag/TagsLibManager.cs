// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagsLibManager.cs
// Version: 20160316

using System;
using System.ComponentModel;
using System.IO;
using xZune.Bass.Tag.Interop;
using xZune.Bass.Tag.Modules;

namespace xZune.Bass.Tag
{
    public static class TagsLibManager
    {
        #region -- Tags library properties --

        /// <summary>
        ///     Get the Tags library handle.
        /// </summary>
        public static IntPtr TagsLibHandle { get; private set; }

        /// <summary>
        ///     Get the directory of set.
        /// </summary>
        public static String TagsLibDirectory { get; private set; }

        /// <summary>
        ///     Get the path of "TagsLib.dll".
        /// </summary>
        public static String TagsLibPath { get; private set; }

        /// <summary>
        ///     Get is Bass loaded and available.
        /// </summary>
        public static bool Available => TagsLibHandle != IntPtr.Zero;

        #endregion

        public static void Initialize(String tagsLibPath)
        {
            if (tagsLibPath == null)
            {
                tagsLibPath = Directory.GetCurrentDirectory();
            }

            // If tagsLibPath is file, then we initialize TagsLib with this file.
            if (File.Exists(tagsLibPath))
            {
                FileInfo tagsLib = new FileInfo(tagsLibPath);

                TagsLibPath = tagsLib.FullName;
                TagsLibDirectory = tagsLib.DirectoryName;
            }
            // If tagsLibPath is a directory, we will find "TagsLib.dll" in this directory, then we initialize TagsLib with found file.
            else if (Directory.Exists(tagsLibPath))
            {
                DirectoryInfo tagsLib = new DirectoryInfo(tagsLibPath);

                TagsLibDirectory = tagsLib.FullName;

                var files = tagsLib.GetFiles("TagsLib.dll", SearchOption.AllDirectories);

                if (files.Length == 0) throw new TagsLibNotFoundException();

                TagsLibPath = files[0].FullName;
            }
            // Provided path is not existing.
            else
            {
                throw new TagsLibNotFoundException(TagsLibPath);
            }

            try
            {
                TagsLibHandle = Win32Api.LoadLibrary(TagsLibPath);
            }
            catch (Win32Exception e)
            {
                throw new TagsLibLoadLibraryException(e);
            }

            if (Available)
            {
                TagsLibCoreModule.Current.InitializeModule();
            }
        }
    }
}