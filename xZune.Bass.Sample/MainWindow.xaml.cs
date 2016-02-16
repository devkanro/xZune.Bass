// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: MainWindow.xaml.cs
// Version: 20160216

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

            AudioFileStream afs = new AudioFileStream(@"E:\Music\CloudMusic\perfume -.mp3", StreamCreateFileConfig.None);
        }
    }
}