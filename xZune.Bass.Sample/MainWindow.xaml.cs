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
        }

        private AudioFileStream afs;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (afs != null && afs.IsAvailable)
            {
                afs.Play();
            }
            else
            {
                afs = new AudioFileStream(@"E:\Music\CloudMusic\perfume -.mp3", StreamCreateFileConfig.None);
                afs.StatusChanged += Afs_StatusChanged;
                
                afs.Play();
            }
        }

        private void Afs_StatusChanged(object sender, ChannelStatusChangedEventArgs args)
        {
            Debug.WriteLine(args.Status);
        }                                                                                

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            afs.Pause();

        }
    }
}