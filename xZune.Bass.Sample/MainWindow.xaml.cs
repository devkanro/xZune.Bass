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

            BassManager.Initialize("../../../Bass/", -1, 44100, InitializationConfig._3D,
                new WindowInteropHelper(this).Handle, null);
            var info = BassManager.Information;

            PluginManager.LoadPlugin(BassPlugin.BassFlac);
            PluginManager.LoadPlugin(BassPlugin.BassApe);
            PluginManager.LoadPlugin(BassPlugin.BassWma);

            fileStream = new AudioFileStream(@"E:\Music\CloudMusic\perfume -.mp3", StreamCreateFileConfig.None);
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