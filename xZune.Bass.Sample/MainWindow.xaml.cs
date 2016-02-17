// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: MainWindow.xaml.cs
// Version: 20160216

using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;
using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass.Sample
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BassManager.Initialize("../../../Bass/", -1, 44100, InitializationConfig.None,
                new WindowInteropHelper(this).Handle, null);

            audioSample = new AudioSample(@"E:\CloudMusic\July - Beyond The Memory.mp3", 0,0,5, SampleLoadConfig.None);
        }

        private AudioSample audioSample;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            audioSample.GetChannel(true).Play();
        }

        private void Afs_StatusChanged(object sender, ChannelStatusChangedEventArgs args)
        {
            Debug.WriteLine(args.Status);
        }                                                                                

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            audioSample.Stop();
        }
    }
}