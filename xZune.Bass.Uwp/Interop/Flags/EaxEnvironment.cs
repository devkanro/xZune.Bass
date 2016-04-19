// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: EaxEnvironment.cs
// Version: 20160216
namespace xZune.Bass.Interop.Flags
{
    /// <summary>
    /// The EAX environment.
    /// </summary>
    public enum EaxEnvironment
    {
        Current = Internal.EaxEnvironment.None,
        Generic = Internal.EaxEnvironment.Generic,
        PaddedCell = Internal.EaxEnvironment.PaddedCell,
        Room = Internal.EaxEnvironment.Room,
        BathRoom = Internal.EaxEnvironment.BathRoom,
        LivingRoom = Internal.EaxEnvironment.LivingRoom,
        StoneRoom = Internal.EaxEnvironment.StoneRoom,
        Auditorium = Internal.EaxEnvironment.Auditorium,
        ConcertHall = Internal.EaxEnvironment.ConcertHall,
        Cave = Internal.EaxEnvironment.Cave,
        Arena = Internal.EaxEnvironment.Arena,
        Hangar = Internal.EaxEnvironment.Hangar,
        CarpetedHallway = Internal.EaxEnvironment.CarpetedHallway,
        Hallway = Internal.EaxEnvironment.Hallway,
        StoneCorridor = Internal.EaxEnvironment.StoneCorridor,
        Alley = Internal.EaxEnvironment.Alley,
        Forest = Internal.EaxEnvironment.Forest,
        City = Internal.EaxEnvironment.City,
        Mountains = Internal.EaxEnvironment.Mountains,
        Quarry = Internal.EaxEnvironment.Quarry,
        Plain = Internal.EaxEnvironment.Plain,
        Parkinglot = Internal.EaxEnvironment.Parkinglot,
        SewerPipe = Internal.EaxEnvironment.SewerPipe,
        UnderWater = Internal.EaxEnvironment.UnderWater,
        Drugged = Internal.EaxEnvironment.Drugged,
        Dizzy = Internal.EaxEnvironment.Dizzy,
        Psychotic = Internal.EaxEnvironment.Psychotic,

        Count = Internal.EaxEnvironment.Count
    }
}