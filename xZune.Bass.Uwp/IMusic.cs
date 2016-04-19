// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: IMusic.cs
// Version: 20160218

namespace xZune.Bass
{
    /// <summary>
    ///     A MOD music.
    /// </summary>
    public interface IMusic : IChannel
    {
        int ActiveChannels { get; }

        int AmplificationLevel { get; set; }

        byte BPM { get; set; }

        int PanSeparation { get; set; }

        int PositionScaler { get; set; }

        byte Speed { get; set; }

        float ChannelVolume { get; set; }

        int GlobalVolume { get; set; }

        float InstrumentVolume { get; set; }

        void SetAmplificationLevelAnimate(int value, uint time);
        void SetBPMAnimate(byte value, uint time);
        void SetPanSeparationAnimate(int value, uint time);
        void SetPositionScalerAnimate(int value, uint time);
        void SetSpeedAnimate(byte value, uint time);
        void SetChannelVolumeAnimate(float value, uint time);
        void SetGlobalVolumeAnimate(int value, uint time);
        void SetInstrumentVolumeAnimate(float value, uint time);

        bool IsAmplificationLevelAnimating { get; }
        bool IsBPMAnimating { get; }
        bool IsPanSeparationAnimating { get; }
        bool IsPositionScalerAnimating { get; }
        bool IsSpeedAnimating { get; }
        bool IsChannelVolumeAnimating { get; }
        bool IsGlobalVolumeAnimating { get; }
        bool IsInstrumentVolumeAnimating { get; }
    }
}