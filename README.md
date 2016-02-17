# xZune.Bass
xZune.Bass is a [Bass](http://www.un4seen.com/bass.html) library wrapper for .NET    
  
**This project is on processing!**  
**Now we have completed base player function. See [Quick Start](https://github.com/higankanshi/xZune.Bass#quick-start) to get more infomation.**

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

**02.Create a audio steam.**
```CSharp
var audioStream = new AudioFileStream(@"E:\test.mp3", StreamCreateFileConfig.None); // File stream.
// var audioStream = new AudioNetworkStream(@"http://127.0.0.1/test.mp3", StreamCreateUrlConfig.None); // Network stream.
// We also support custom .NET Steam to create a audio stream.
```

**03.Play control.**
```CSharp
audioStream.Play(); // To play audio stream.
audioStream.Pause(); // To pause audio stream.
audioStream.Stop(); // To pause audio stream.
```

**04.Events of channel.**
```CSharp
// We support many event of every channel.
// StatusChanged, PositionChanged, Ended...

// Listen a event.
audioStream.StatusChanged += AudioStreamStatusChanged;

private void AudioStreamStatusChanged(object sender, ChannelStatusChangedEventArgs args)
{
    Debug.WriteLine(args.Status);
}                                                                                
```

**05.Property of channel.**
```CSharp
// We support many properties of every channel.
// Length, Position, Status, Time...

// Get the time of a channel.
TimeSpan time = audioStream.Time;                                   
```

**06.Free and release a channel.**
```CSharp
// Every channel object is inherited form IDispose interface.
// Use Dispose() method to release all resource of channel.

// Release a channel.
audioStream.Dispose();                               
```

**07.Realease Bass.**
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

### Player components (processing).
- [x] Initializer wrapper.
- [x] Stream wrapper.
- [x] Channel wrapper.
- [ ] Sample wrapper (processing).
- [ ] Device wrapper.
- [ ] MOD music wrapper.
- [ ] Record wrapper.
- [ ] EAX wrapper.
- [ ] Effect wrapper.

### Plug-in components (waiting).
- [ ] Plug-in loader.
- [ ] BassApe
- [ ] BassFlac
- [ ] BassWma
- [ ] BassAac
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