// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: MainWindow.xaml.cs
// Version: 20160218

using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Sample
{
    public partial class MainWindow : Window
    {
        private AudioFileStream fileStream;

        public MainWindow()
        {
            InitializeComponent();

            BassManager.Initialize("../../../Bass/", -1, 44100, InitializationConfig.None,
                new WindowInteropHelper(this).Handle, null);
            PluginManager.LoadPlugin(BassPlugin.BassFlac);

            fileStream = new AudioFileStream(@"E:\Music\乐园追放.OST\FLAC\31. EONIAN -English Ver.-.flac", StreamCreateFileConfig.None);
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