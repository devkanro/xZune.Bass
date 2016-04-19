using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using xZune.Bass.Interop.Flags;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace xZune.Bass.Uwp.Sample
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            BassManager.Initialize("Bass/x86/bass.dll",-1,44100, InitializationConfig.None, IntPtr.Zero, null);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            HttpClient hc = new HttpClient();
            var buffer = await hc.GetBufferAsync(new Uri("http://192.168.1.61/test.mp3"));
            var stream = buffer.AsStream();

            AudioFileStream afs = new AudioFileStream(stream, StreamCreateFileUserConfig.None, StreamFileSystemType.Buffer);
            afs.Play();
        }
    }
}
