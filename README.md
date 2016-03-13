# xZune.Bass
xZune.Bass is a .Net wrapper of the [Bass](http://www.un4seen.com/bass.html) Library.   
  
**This project is working in progress!**  
**Now we have completed base player function. See [Quick Start](https://github.com/higankanshi/xZune.Bass#quick-start) to get more infomation.**

[![Join the chat at https://gitter.im/higankanshi/xZune.Bass](https://badges.gitter.im/higankanshi/xZune.Bass.svg)](https://gitter.im/higankanshi/xZune.Bass?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge) 

## Api Documentation

See the api documentation of [xZune.Bass](http://higan.me/xZune.Bass/api/index.html).

## Quick Start

**01.Add the references of xZune.Bass to your project.**  
```
xZune.Bass
```

**02.Initialize Bass in your code.**
```CSharp
// Use BassManager to manage Bass.

BassManager.Initialize("../../../Bass/", -1, 44100, InitializationConfig.None, new WindowInteropHelper(this).Handle, null);
// Set the Bass library path , device, sample rate, configures, window handle, and guid of DSound object to initialize Bass.
```

**02.Create an audio stream.**
```CSharp
var audioStream = new AudioFileStream(@"E:\test.mp3", StreamCreateFileConfig.None); // File stream.
// var audioStream = new AudioNetworkStream(@"http://127.0.0.1/test.mp3", StreamCreateUrlConfig.None); // Network stream.
// We also support custom .NET Steam to create an audio stream.
```

**03.Play control.**
```CSharp
audioStream.Play(); // To play audio stream.
audioStream.Pause(); // To pause audio stream.
audioStream.Stop(); // To pause audio stream.
```

**04.Create an audio sample and play it.**
```CSharp
var audioSample = new AudioFileStream(@"E:\test.mp3",0,0,5, SampleLoadConfig.None); // Create a sample form a file.
// We also support custom .NET Steam to create an audio sample, and you can set sample data to a sample.

// Create playback channel for sample.
var audioSampleChannel = audioSample.GetChannel(true);

// Play it.
audioSampleChannel.Play();

// Note: Many events is not available with SampleChannel.
```

**05.Play a MOD/MO3 music.**
```CSharp
// Create a MOD music with a file, and pre-scan it to get length and position of it.
var modMusic = new ModMusic(@"C:\Users\higan\Downloads\CORE - Adobe CS4kg.XM", 0,0,1,MusicLoadConfig.Prescan);

// Play it.
modMusic.Play();
```

**06.Events of channel.**
```CSharp
// We support many events of every channel.
// StatusChanged, PositionChanged, Ended...

// Listen a event.
audioStream.StatusChanged += AudioStreamStatusChanged;

private void AudioStreamStatusChanged(object sender, ChannelStatusChangedEventArgs args)
{
    Debug.WriteLine(args.Status);
}                                                                                
```

**07.Property of channel.**
```CSharp
// We support many properties of every channel.
// Length, Position, Status, Time...

// Get the time of a channel.
TimeSpan time = audioStream.Time;                                   
```

**08.Effect of channel.**
```CSharp
// We support some effects of channel.
// Effect need DirectX 8 support.

// Create a effect. Effect will automatically add to Channel.Effects.
ChorusEffect chorusEffect = new ChorusEffect(audioStream,0);            

// Set parameters of effect.
var parameters = new Dx8Chorus();
chorusEffect.Parameters = parameters;

// Remove effect.
audioStream.RemoveEffect(chorusEffect);
```

**09.Free and release a channel.**
```CSharp
// Every channel object is inherited form IDispose interface.
// Use Dispose() method to release all resource of channel.

// Release a channel.
audioStream.Dispose();                               
```

**10.Release Bass.**
```CSharp
// Use BassManager to manage Bass.

// Use BassManager.ReleaseAll() method before your APP closed.
BassManager.ReleaseAll();
```

## Todo List  

### Interop components (completed).
- [x] Infomation and initialization module.
- [x] Plug-in module.
- [x] Stream module.
- [x] Config module.
- [x] Channel module.
- [x] Sample module.
- [x] Recording module.
- [x] MOD/MO3 music module.
- [x] 3D & EAX module.
- [x] Effect module.
- [x] Base interop module.

### Player components (completed).
- [x] Initializer wrapper.
- [x] Stream wrapper.
- [x] Channel wrapper.
- [x] Sample wrapper.
- [x] MOD music wrapper.
- [x] Record wrapper.
- [x] Global configures wrapper.
- [x] EAX wrapper.
- [x] Effect wrapper.

### xZune.Bass.Player (working in progress).
Provide "Player - Media" relationship APIs to manage audio media, and play it.  
Like this:
```CSharp
AudioPlayer player = new AudioPlayer();
player.Load(@"c:\test.mp3");
player.Play();
player.Stop();
player.Load(@"c:\test2.xm");
```

### Plug-in components (working in progress).
- [x] Plug-in loader.
- [x] BassFlac
- [x] BassApe
- [x] BassWma
- [ ] BassAac (working in progress)
- [ ] BassAlac
- [ ] BassTta
- [ ] BassAc3
- [ ] BassTags
- [ ] BassMidi
- [ ] BassAdx
- [ ] BassAix
- [ ] BassWv
- [ ] BassScd
- [ ] BassOpus
- [ ] BassDsd
- [ ] BassSenc
- [ ] BassSmix
- [ ] BassWasApi
- [ ] BassHls
- [ ] BassFx
- [ ] BassSpx
- [ ] BassMpc
- [ ] BassPfr
- [ ] BassWaDsp
- [ ] BassVst
- [ ] BassWinamp
- [ ] BassSfx
- [ ] BassWa

## xZune Media Suit  

**[xZune.Vlc](https://github.com/higankanshi/xZune.Vlc)**  
xZune.Vlc 是一个 LibVlc 封装库的 .NET 实现,封装了大部分的 LibVlc 的功能,该项目主要是为了寻求一个在 WPF 上使用 Vlc 的完美的解决方案,xZune.Vlc 提供一个原生的 WPF 播放控件(xZune.Vlc.Wpf),该控件采用 InteropBitmap 与共享内存进行播放视频,是一个原生的 WPF 控件,不存在 HwndHost 的空域问题.  
_xZune.Vlc is an LibVlc solution for .NET, it has encapsulated most of functionalities of LibVlc. This project aims to find a perfect solution for using Vlc on WPF. xZune.Vlc provides an native WPF control(xZune.Vlc.Wpf), this control achieves video playback by utilizing InteropBitmap and shared memory. Since it’s a native WPF control, it doesn't suffer from HwndHost’s airspace issue._  

**[xZune.Visualizer](https://github.com/higankanshi/xZune.Visualizer)**  
 Zune 风格的音频可视化控件。  
A Zune-like audio visualizer component 
