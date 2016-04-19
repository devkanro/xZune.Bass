// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Effect.cs
// Version: 20160220

using System;
using System.Runtime.InteropServices;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Flags;
using xZune.Bass.Modules;

namespace xZune.Bass
{
    public abstract class Effect : HandleObject
    {
        public Effect(Channel channel, int priority)
        {
            Channel = channel;
            Handle = ChannelModule.ChannelSetFXFunction.CheckResult(ChannelModule.ChannelSetFXFunction.Delegate(Channel.Handle,
                Type, priority));
            Channel._effects.Add(this);
            IsAvailable = true;
        }

        /// <summary>
        /// Type of effect.
        /// </summary>
        public virtual FxType Type { get; }

        /// <summary>
        /// Effect channel.
        /// </summary>
        public Channel Channel { get; private set; }
        
        /// <summary>
        /// Resets the state of an effect. 
        /// </summary>
        /// <remarks>
        /// This function flushes the internal buffers of the effects. Effects are automatically reset by <see cref="Channel.Position"/>, except when called from a "mixtime" SYNCPROC. 
        /// </remarks>
        public void Reset()
        {
            CheckAvailable();
            EffectModule.FXResetFunction.CheckResult(EffectModule.FXResetFunction.Delegate(Handle));
        }

        internal void Deattch()
        {
            Channel._effects.Remove(this);
            ChannelModule.ChannelRemoveFXFunction.CheckResult(
                ChannelModule.ChannelRemoveFXFunction.Delegate(Channel.Handle, Handle));
            Channel = null;
            Dispose();
            IsAvailable = false;
        }

        protected override void ReleaseManaged()
        {

        }

        protected override void ReleaseUnmanaged()
        {
            Handle = IntPtr.Zero;
        }
    }

    public interface IChorusEffect
    {
        Dx8Chorus Parameters { get; set; }
    }

    public interface ICompressionEffect
    {
        Dx8Compression Parameters { get; set; }
    }

    public interface IDistortionEffect
    {
        Dx8Distortion Parameters { get; set; }
    }

    public interface IEchoEffect
    {
        Dx8Echo Parameters { get; set; }
    }

    public interface IFlangerEffect
    {
        Dx8Flanger Parameters { get; set; }
    }

    public interface IGargleEffect
    {
        Dx8Gargle Parameters { get; set; }
    }

    public interface II3DL2Effect
    {
        Dx8I3Dl2 Parameters { get; set; }
    }

    public interface IParametricEffect
    {
        Dx8ParametricEqualizer Parameters { get; set; }
    }

    public interface IReverbEffect
    {
        Dx8Reverb Parameters { get; set; }
    }

    public class ChorusEffect : Effect, IChorusEffect
    {
        private Dx8Chorus _parameters;
        private GCHandle _parametersHandle;

        public ChorusEffect(Channel channel, int priority) : base(channel,priority)
        {
            _parameters = new Dx8Chorus();
            _parametersHandle = GCHandle.Alloc(_parameters, GCHandleType.Pinned);
        }

        public override FxType Type => FxType.Dx8Chorus;

        public Dx8Chorus Parameters
        {
            get
            {
                EffectModule.FXGetParametersFunction.CheckResult(EffectModule.FXGetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
                return _parameters;
            }
            set
            {
                _parameters = value;
                EffectModule.FXSetParametersFunction.CheckResult(EffectModule.FXSetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
            }
        }
    }

    public class CompressionEffect : Effect, ICompressionEffect
    {
        private Dx8Compression _parameters;
        private GCHandle _parametersHandle;

        public CompressionEffect(Channel channel, int priority) : base(channel,priority)
        {
            _parameters = new Dx8Compression();
            _parametersHandle = GCHandle.Alloc(_parameters, GCHandleType.Pinned);
        }

        public override FxType Type => FxType.Dx8Compressor;

        public Dx8Compression Parameters
        {
            get
            {
                EffectModule.FXGetParametersFunction.CheckResult(EffectModule.FXGetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
                return _parameters;
            }
            set
            {
                _parameters = value;
                EffectModule.FXSetParametersFunction.CheckResult(EffectModule.FXSetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
            }
        }
    }

    public class DistortionEffect : Effect, IDistortionEffect
    {
        private Dx8Distortion _parameters;
        private GCHandle _parametersHandle;

        public DistortionEffect(Channel channel, int priority) : base(channel,priority)
        {
            _parameters = new Dx8Distortion();
            _parametersHandle = GCHandle.Alloc(_parameters, GCHandleType.Pinned);
        }

        public override FxType Type => FxType.Dx8Distortion;

        public Dx8Distortion Parameters
        {
            get
            {
                EffectModule.FXGetParametersFunction.CheckResult(EffectModule.FXGetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
                return _parameters;
            }
            set
            {
                _parameters = value;
                EffectModule.FXSetParametersFunction.CheckResult(EffectModule.FXSetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
            }
        }
    }

    public class EchoEffect : Effect, IEchoEffect
    {
        private Dx8Echo _parameters;
        private GCHandle _parametersHandle;

        public EchoEffect(Channel channel, int priority) : base(channel,priority)
        {
            _parameters = new Dx8Echo();
            _parametersHandle = GCHandle.Alloc(_parameters, GCHandleType.Pinned);
        }

        public override FxType Type => FxType.Dx8Echo;

        public Dx8Echo Parameters
        {
            get
            {
                EffectModule.FXGetParametersFunction.CheckResult(EffectModule.FXGetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
                return _parameters;
            }
            set
            {
                _parameters = value;
                EffectModule.FXSetParametersFunction.CheckResult(EffectModule.FXSetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
            }
        }
    }

    public class FlangerEffect : Effect, IFlangerEffect
    {
        private Dx8Flanger _parameters;
        private GCHandle _parametersHandle;

        public FlangerEffect(Channel channel, int priority) : base(channel,priority)
        {
            _parameters = new Dx8Flanger();
            _parametersHandle = GCHandle.Alloc(_parameters, GCHandleType.Pinned);
        }

        public override FxType Type => FxType.Dx8Flanger;

        public Dx8Flanger Parameters
        {
            get
            {
                EffectModule.FXGetParametersFunction.CheckResult(EffectModule.FXGetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
                return _parameters;
            }
            set
            {
                _parameters = value;
                EffectModule.FXSetParametersFunction.CheckResult(EffectModule.FXSetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
            }
        }
    }

    public class GargleEffect : Effect, IGargleEffect
    {
        private Dx8Gargle _parameters;
        private GCHandle _parametersHandle;

        public GargleEffect(Channel channel, int priority) : base(channel,priority)
        {
            _parameters = new Dx8Gargle();
            _parametersHandle = GCHandle.Alloc(_parameters, GCHandleType.Pinned);
        }

        public override FxType Type => FxType.Dx8Gargle;

        public Dx8Gargle Parameters
        {
            get
            {
                EffectModule.FXGetParametersFunction.CheckResult(EffectModule.FXGetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
                return _parameters;
            }
            set
            {
                _parameters = value;
                EffectModule.FXSetParametersFunction.CheckResult(EffectModule.FXSetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
            }
        }
    }

    public class I3DL2Effect : Effect, II3DL2Effect
    {
        private Dx8I3Dl2 _parameters;
        private GCHandle _parametersHandle;

        public I3DL2Effect(Channel channel, int priority) : base(channel,priority)
        {
            _parameters = new Dx8I3Dl2();
            _parametersHandle = GCHandle.Alloc(_parameters, GCHandleType.Pinned);
        }

        public override FxType Type => FxType.Dx8I3Dl2Reverb;

        public Dx8I3Dl2 Parameters
        {
            get
            {
                EffectModule.FXGetParametersFunction.CheckResult(EffectModule.FXGetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
                return _parameters;
            }
            set
            {
                _parameters = value;
                EffectModule.FXSetParametersFunction.CheckResult(EffectModule.FXSetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
            }
        }
    }

    public class ParametricEffect : Effect, IParametricEffect
    {
        private Dx8ParametricEqualizer _parameters;
        private GCHandle _parametersHandle;

        public ParametricEffect(Channel channel, int priority) : base(channel,priority)
        {
            _parameters = new Dx8ParametricEqualizer();
            _parametersHandle = GCHandle.Alloc(_parameters, GCHandleType.Pinned);
        }

        public override FxType Type => FxType.Dx8Parameq;

        public Dx8ParametricEqualizer Parameters
        {
            get
            {
                EffectModule.FXGetParametersFunction.CheckResult(EffectModule.FXGetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
                return _parameters;
            }
            set
            {
                _parameters = value;
                EffectModule.FXSetParametersFunction.CheckResult(EffectModule.FXSetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
            }
        }
    }

    public class ReverbEffect : Effect, IReverbEffect
    {
        private Dx8Reverb _parameters;
        private GCHandle _parametersHandle;

        public ReverbEffect(Channel channel, int priority) : base(channel,priority)
        {
            _parameters = new Dx8Reverb();
            _parametersHandle = GCHandle.Alloc(_parameters, GCHandleType.Pinned);
        }

        public override FxType Type => FxType.Dx8Reverb;

        public Dx8Reverb Parameters
        {
            get
            {
                EffectModule.FXGetParametersFunction.CheckResult(EffectModule.FXGetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
                return _parameters;
            }
            set
            {
                _parameters = value;
                EffectModule.FXSetParametersFunction.CheckResult(EffectModule.FXSetParametersFunction.Delegate(Handle,
                    _parametersHandle.AddrOfPinnedObject()));
            }
        }
    }
}