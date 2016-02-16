// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassStream.cs
// Version: 20160216

using System;
using System.IO;
using System.Runtime.InteropServices;
using xZune.Bass.Interop.Core;

namespace xZune.Bass
{
    /// <summary>
    /// A <see cref="Stream"/> wrapper for <see cref="AudioStream.CreateFormStream"/>.
    /// </summary>
    public class BassStream : IDisposable
    {
        private GCHandle _fileCloseHandle;
        private FileCloseHandler _fileCloseHandler;
        private GCHandle _fileLengthHandle;
        private FileLengthHandler _fileLengthHandler;
        private GCHandle _fileReadHandle;
        private FileReadHandler _fileReadHandler;
        private GCHandle _fileSeekHandle;
        private FileSeekHandler _fileSeekHandler;

        private Stream _stream;
        private long _streamPosition;

        /// <summary>
        /// Create a <see cref="BassStream"/> form a <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">Stream to wrap.</param>
        public BassStream(Stream stream)
        {
            _stream = stream;
            _streamPosition = _stream.Position;

            _fileCloseHandler = OnFileClose;
            _fileLengthHandler = OnFileLength;
            _fileReadHandler = OnFileRead;
            _fileSeekHandler = OnFileSeek;

            _fileCloseHandle = GCHandle.Alloc(_fileCloseHandler);
            _fileLengthHandle = GCHandle.Alloc(_fileLengthHandler);
            _fileReadHandle = GCHandle.Alloc(_fileReadHandler);
            _fileSeekHandle = GCHandle.Alloc(_fileSeekHandler);

            StreamHandlers = new FileHandlers
            {
                CloseHandler = _fileCloseHandler,
                LengthHandler = _fileLengthHandler,
                ReadHandler = _fileReadHandler,
                SeekHandler = _fileSeekHandler
            };
        }

        /// <summary>
        /// Get stream handles.
        /// </summary>
        public FileHandlers StreamHandlers { get; private set; }

        /// <summary>
        /// Release all resource.
        /// </summary>
        public void Dispose()
        {
            _fileCloseHandle.Free();
            _fileLengthHandle.Free();
            _fileReadHandle.Free();
            _fileSeekHandle.Free();

            _fileCloseHandler = null;
            _fileLengthHandler = null;
            _fileReadHandler = null;
            _fileSeekHandler = null;

            StreamHandlers = new FileHandlers();
        }

        private void OnFileClose(IntPtr user)
        {
        }

        private UInt64 OnFileLength(IntPtr user)
        {
            return (UInt64) _stream.Length;
        }

        private uint OnFileRead(IntPtr buffer, uint length, IntPtr user)
        {
            byte[] streamBuffer = new byte[length];
            var result = _stream.Read(streamBuffer, 0, (int) length);
            Marshal.Copy(streamBuffer, 0, buffer, result);
            return (uint) result;
        }

        private bool OnFileSeek(uint offset, IntPtr user)
        {
            var pos = _stream.Position;
            var newPos = offset + _streamPosition;

            if (newPos == _stream.Seek(newPos, SeekOrigin.Begin))
            {
                return true;
            }
            _stream.Seek(pos, SeekOrigin.Begin);
            return false;
        }
    }

    /// <summary>
    /// Some extension methods for <see cref="BassStream"/>.
    /// </summary>
    public static class BassStreamExtension
    {
        /// <summary>
        /// Convert a <see cref="Stream"/> to <see cref="BassStream"/>.
        /// </summary>
        /// <param name="stream">Stream to wrap.</param>
        /// <returns>Converted steam.</returns>
        public static BassStream ToBassStream(this Stream stream)
        {
            return new BassStream(stream);
        }
    }
}