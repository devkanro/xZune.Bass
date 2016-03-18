// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: MainWindow.xaml.cs
// Version: 20160218

using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;
using xZune.Bass.Interop.Flags;
using xZune.Bass.Tag;

namespace xZune.Bass.Sample
{
    public partial class MainWindow : Window
    {
        private AudioFileStream fileStream;
        private TagsManager tag;

        public MainWindow()
        {
            InitializeComponent();

            BassManager.Initialize("../../../Bass/", -1, 44100, InitializationConfig._3D,
                new WindowInteropHelper(this).Handle, null);
            TagsLibManager.Initialize();

            var info = BassManager.Information;
            
            PluginManager.LoadPlugin(BassPlugin.BassFlac);
            PluginManager.LoadPlugin(BassPlugin.BassApe);
            PluginManager.LoadPlugin(BassPlugin.BassWma);

            PluginManager.FreePlugin(BassPlugin.BassWma);

            fileStream = new AudioFileStream(@"E:\Music\乐园追放.OST\MP3\01 Qunka!.mp3", StreamCreateFileConfig.None);

            tag = TagsManager.CreateFormFile(@"E:\Music\乐园追放.OST\FLAC\01. Vacation 7.92.flac");
            var t = tag.FLACTagList[0];
            t.Value = "测试";

            tag.FLACTagList.Change(t);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            fileStream.Play();
        }

        private void Afs_StatusChanged(object sender, ChannelStatusChangedEventArgs args)
        {
            Debug.WriteLine(args.Status);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            fileStream.Stop();
        }
    }
}