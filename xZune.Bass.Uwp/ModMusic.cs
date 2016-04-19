// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ModMusic.cs
// Version: 20160218

using System;
using System.IO;
using System.Runtime.InteropServices;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Flags;
using xZune.Bass.Modules;

namespace xZune.Bass
{
    /// <summary>
    /// A MOD music.
    /// </summary>
    public class ModMusic : Channel, IMusic
    {
        protected override void ReleaseManaged()
        {

        }

        protected override void ReleaseUnmanaged()
        {
            Free();
        }

        protected override void Free()
        {
            CheckAvailable();

            ModMusicModule.MusicFreeFunction.CheckResult(ModMusicModule.MusicFreeFunction.Delegate(Handle));

            Handle = IntPtr.Zero;
            IsAvailable = false;
        }

        /// <summary>
        /// Create a MOD music form a file. 
        /// </summary>
        /// <param name="file">File name. </param>
        /// <param name="offset">File offset to load the MOD music from. </param>
        /// <param name="length">Data length... 0 = use all data up to the end of file. </param>
        /// <param name="freq">Sample rate to render/play the MOD music at... 0 = the rate specified in the <see cref="Initialize"/> call, 1 = the device's current output rate (or the <see cref="Initialize"/> rate if that is not available). </param>
        /// <param name="config">Some configures of MOD music.</param>
        public ModMusic(String file, ulong offset, uint length, uint freq, MusicLoadConfig config)
        {
            config |= MusicLoadConfig.Unicode;

            using (var fileHandle = InteropHelper.StringToPtr(file))
            {
                Handle = ModMusicModule.MusicLoadFunction.CheckResult(
                    ModMusicModule.MusicLoadFunction.Delegate(false, fileHandle.Handle, offset, length, config, freq));
            }
        }

        /// <summary>
        /// Create a MOD music form a .NET memory stream.
        /// </summary>
        /// <param name="stream">A .NET memory stream. </param>
        /// <param name="freq">Sample rate to render/play the MOD music at... 0 = the rate specified in the <see cref="Initialize"/> call, 1 = the device's current output rate (or the <see cref="Initialize"/> rate if that is not available). </param>
        /// <param name="config">Some configures of MOD music.</param>
        public ModMusic(MemoryStream stream, uint freq, MusicLoadConfig config) 
        {
            ArraySegment<byte> bufferSegment;
            byte[] buffer = stream.TryGetBuffer(out bufferSegment) ? bufferSegment.Array : stream.ToArray();

            GCHandle bufferHandle = GCHandle.Alloc(buffer);

            Handle = ModMusicModule.MusicLoadFunction.CheckResult(
                ModMusicModule.MusicLoadFunction.Delegate(true, bufferHandle.AddrOfPinnedObject(), 0,
                    (uint)stream.Length, config, freq));

            bufferHandle.Free();
        }

        /// <summary>
        /// The number of active channels in a MOD music. 
        /// </summary>
        public int ActiveChannels
        {
            get
            {
                CheckAvailable();

                return (int)((IChannelInternal) this).GetAttribute(ChannelAttribute.MusicActive);
            }
        }

        /// <summary>
        /// The amplification level of a MOD music. 0 (min) to 100 (max). The default amplification level is 50. 
        /// </summary>
        public int AmplificationLevel
        {
            get
            {
                CheckAvailable();

                return (int)((IChannelInternal)this).GetAttribute(ChannelAttribute.MusicAmplify);
            }
            set
            {
                CheckAvailable();

                ((IChannelInternal)this).SetAttribute(ChannelAttribute.MusicAmplify, value);
            }
        }

        /// <summary>
        /// The BPM of a MOD music. 1 (min) to 255 (max). 
        /// </summary>
        public byte BPM
        {
            get
            {
                CheckAvailable();

                return (byte)((IChannelInternal)this).GetAttribute(ChannelAttribute.MusicBpm);
            }
            set
            {
                CheckAvailable();

                ((IChannelInternal)this).SetAttribute(ChannelAttribute.MusicBpm, value);
            }
        }

        /// <summary>
        /// The pan separation level of a MOD music. 0 (min) to 100 (max), 50 = linear. 
        /// </summary>
        public int PanSeparation
        {
            get
            {
                CheckAvailable();

                return (int)((IChannelInternal)this).GetAttribute(ChannelAttribute.MusicPansep);
            }
            set
            {
                CheckAvailable();

                ((IChannelInternal)this).SetAttribute(ChannelAttribute.MusicPansep, value);
            }
        }

        /// <summary>
        /// The position scaler of a MOD music. 1 (min) to 256 (max). The default position scaler is 1. 
        /// </summary>
        public int PositionScaler
        {
            get
            {
                CheckAvailable();

                return (int)((IChannelInternal)this).GetAttribute(ChannelAttribute.MusicPscaler);
            }
            set
            {
                CheckAvailable();

                ((IChannelInternal)this).SetAttribute(ChannelAttribute.MusicPscaler, value);
            }
        }

        /// <summary>
        /// The speed of a MOD music. The "speed" is the number of ticks per row. Setting it to 0, stops and ends the music. Note that by changing this attribute, you are changing the playback length. 
        /// </summary>
        public byte Speed
        {
            get
            {
                CheckAvailable();

                return (byte)((IChannelInternal)this).GetAttribute(ChannelAttribute.MusicSpeed);
            }
            set
            {
                CheckAvailable();

                ((IChannelInternal)this).SetAttribute(ChannelAttribute.MusicSpeed, value);
            }
        }

        /// <summary>
        /// The volume level of a channel in a MOD music. 
        /// </summary>
        public float ChannelVolume
        {
            get
            {
                CheckAvailable();

                return (int)((IChannelInternal)this).GetAttribute(ChannelAttribute.MusicVolumeChannel);
            }
            set
            {
                CheckAvailable();

                ((IChannelInternal)this).SetAttribute(ChannelAttribute.MusicVolumeChannel, value);
            }
        }

        /// <summary>
        /// The global volume level of a MOD music. 0 (min) to 64 (max, 128 for IT format). 
        /// </summary>
        public int GlobalVolume
        {
            get
            {
                CheckAvailable();

                return (int)((IChannelInternal)this).GetAttribute(ChannelAttribute.MusicVolumeGlobal);
            }
            set
            {
                CheckAvailable();

                ((IChannelInternal)this).SetAttribute(ChannelAttribute.MusicVolumeGlobal, value);
            }
        }

        /// <summary>
        /// The volume level of an instrument in a MOD music. 
        /// </summary>
        public float InstrumentVolume
        {
            get
            {
                CheckAvailable();

                return (int)((IChannelInternal)this).GetAttribute(ChannelAttribute.MusicVolumeInstrument);
            }
            set
            {
                CheckAvailable();

                ((IChannelInternal)this).SetAttribute(ChannelAttribute.MusicVolumeInstrument, value);
            }
        }

        /// <summary>
        /// Slides a MOD music's <see cref="AmplificationLevel"/> from its current value to a new value.
        /// </summary>
        /// <param name="value">The amplification level of a MOD music. 0 (min) to 100 (max).</param>
        /// <param name="time">The length of time (in milliseconds) that it should take for the <see cref="AmplificationLevel"/> to reach the value. </param>
        public void SetAmplificationLevelAnimate(int value, uint time)
        {
            CheckAvailable();

            ((IChannelInternal) this).SlideAttribute(ChannelAttribute.MusicAmplify, value, time);
        }

        /// <summary>
        /// Slides a MOD music's <see cref="BPM"/> from its current value to a new value.
        /// </summary>
        /// <param name="value">The BPM of a MOD music. 1 (min) to 255 (max). </param>
        /// <param name="time">The length of time (in milliseconds) that it should take for the <see cref="BPM"/> to reach the value. </param>
        public void SetBPMAnimate(byte value, uint time)
        {
            CheckAvailable();

            ((IChannelInternal)this).SlideAttribute(ChannelAttribute.MusicBpm, value, time);
        }

        /// <summary>
        /// Slides a MOD music's <see cref="PanSeparation"/> from its current value to a new value.
        /// </summary>
        /// <param name="value">The pan separation level of a MOD music. 0 (min) to 100 (max), 50 = linear. </param>
        /// <param name="time">The length of time (in milliseconds) that it should take for the <see cref="PanSeparation"/> to reach the value. </param>
        public void SetPanSeparationAnimate(int value, uint time)
        {
            CheckAvailable();

            ((IChannelInternal)this).SlideAttribute(ChannelAttribute.MusicPansep, value, time);
        }

        /// <summary>
        /// Slides a MOD music's <see cref="PositionScaler"/> from its current value to a new value.
        /// </summary>
        /// <param name="value">The position scaler of a MOD music. 1 (min) to 256 (max).</param>
        /// <param name="time">The length of time (in milliseconds) that it should take for the <see cref="PositionScaler"/> to reach the value. </param>
        public void SetPositionScalerAnimate(int value, uint time)
        {
            CheckAvailable();

            ((IChannelInternal)this).SlideAttribute(ChannelAttribute.MusicPscaler, value, time);
        }

        /// <summary>
        /// Slides a MOD music's <see cref="Speed"/> from its current value to a new value.
        /// </summary>
        /// <param name="value">The speed of a MOD music. The "speed" is the number of ticks per row. Setting it to 0, stops and ends the music. Note that by changing this attribute, you are changing the playback length.</param>
        /// <param name="time">The length of time (in milliseconds) that it should take for the <see cref="Speed"/> to reach the value. </param>
        public void SetSpeedAnimate(byte value, uint time)
        {
            CheckAvailable();

            ((IChannelInternal)this).SlideAttribute(ChannelAttribute.MusicSpeed, value, time);
        }

        /// <summary>
        /// Slides a MOD music's <see cref="ChannelVolume"/> from its current value to a new value.
        /// </summary>
        /// <param name="value">The volume level of a channel in a MOD music. </param>
        /// <param name="time">The length of time (in milliseconds) that it should take for the <see cref="ChannelVolume"/> to reach the value. </param>
        public void SetChannelVolumeAnimate(float value, uint time)
        {
            CheckAvailable();

            ((IChannelInternal)this).SlideAttribute(ChannelAttribute.MusicVolumeChannel, value, time);
        }

        /// <summary>
        /// Slides a MOD music's <see cref="GlobalVolume"/> from its current value to a new value.
        /// </summary>
        /// <param name="value">The global volume level of a MOD music. 0 (min) to 64 (max, 128 for IT format). </param>
        /// <param name="time">The length of time (in milliseconds) that it should take for the <see cref="GlobalVolume"/> to reach the value. </param>
        public void SetGlobalVolumeAnimate(int value, uint time)
        {
            CheckAvailable();

            ((IChannelInternal)this).SlideAttribute(ChannelAttribute.MusicVolumeGlobal, value, time);
        }

        /// <summary>
        /// Slides a MOD music's <see cref="InstrumentVolume"/> from its current value to a new value.
        /// </summary>
        /// <param name="value">The volume level of an instrument in a MOD music. </param>
        /// <param name="time">The length of time (in milliseconds) that it should take for the <see cref="InstrumentVolume"/> to reach the value. </param>
        public void SetInstrumentVolumeAnimate(float value, uint time)
        {
            CheckAvailable();

            ((IChannelInternal)this).SlideAttribute(ChannelAttribute.MusicVolumeInstrument, value, time);
        }

        /// <summary>
        /// Checks if <see cref="AmplificationLevel"/> is sliding.
        /// </summary>
        public bool IsAmplificationLevelAnimating => ((IChannelInternal) this).IsSliding(ChannelAttribute.MusicAmplify);
        /// <summary>
        /// Checks if <see cref="BPM"/> is sliding.
        /// </summary>
        public bool IsBPMAnimating => ((IChannelInternal)this).IsSliding(ChannelAttribute.MusicBpm);
        /// <summary>
        /// Checks if <see cref="PanSeparation"/> is sliding.
        /// </summary>
        public bool IsPanSeparationAnimating => ((IChannelInternal)this).IsSliding(ChannelAttribute.MusicPansep);
        /// <summary>
        /// Checks if <see cref="PositionScaler"/> is sliding.
        /// </summary>
        public bool IsPositionScalerAnimating => ((IChannelInternal)this).IsSliding(ChannelAttribute.MusicPscaler);
        /// <summary>
        /// Checks if <see cref="Speed"/> is sliding.
        /// </summary>
        public bool IsSpeedAnimating => ((IChannelInternal)this).IsSliding(ChannelAttribute.MusicSpeed);
        /// <summary>
        /// Checks if <see cref="ChannelVolume"/> is sliding.
        /// </summary>
        public bool IsChannelVolumeAnimating => ((IChannelInternal)this).IsSliding(ChannelAttribute.MusicVolumeChannel);
        /// <summary>
        /// Checks if <see cref="GlobalVolume"/> is sliding.
        /// </summary>
        public bool IsGlobalVolumeAnimating => ((IChannelInternal)this).IsSliding(ChannelAttribute.MusicVolumeGlobal);
        /// <summary>
        /// Checks if <see cref="InstrumentVolume"/> is sliding.
        /// </summary>
        public bool IsInstrumentVolumeAnimating => ((IChannelInternal)this).IsSliding(ChannelAttribute.MusicVolumeInstrument);
    }
}