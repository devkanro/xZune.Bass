// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: MainWindow.xaml.cs
// Version: 20160218

using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;
using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass.Sample
{
    public partial class MainWindow : Window
    {
        private ModMusic modMusic;

        public MainWindow()
        {
            InitializeComponent();

            BassManager.Initialize("../../../Bass/", -1, 44100, InitializationConfig.None,
                new WindowInteropHelper(this).Handle, null);

            modMusic = new ModMusic(@"C:\Users\higan\Downloads\CORE - Adobe CS4kg.XM", 0,0,1,MusicLoadConfig.Prescan);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            modMusic.Play();
        }

        private void Afs_StatusChanged(object sender, ChannelStatusChangedEventArgs args)
        {
            Debug.WriteLine(args.Status);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            modMusic.Stop();
        }
    }
}