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
        private AudioNetworkStream networkStream;

        public MainWindow()
        {
            InitializeComponent();

            BassManager.Initialize("../../../Bass/", -1, 44100, InitializationConfig.None,
                new WindowInteropHelper(this).Handle, null);

            networkStream = new AudioNetworkStream("http://lounge-office.rautemusik.fm", StreamCreateUrlConfig.None);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            networkStream.Play();
        }

        private void Afs_StatusChanged(object sender, ChannelStatusChangedEventArgs args)
        {
            Debug.WriteLine(args.Status);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            networkStream.Stop();
        }
    }
}