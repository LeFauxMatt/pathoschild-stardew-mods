namespace Pathoschild.Stardew.CentralStation.Framework.Constants;

/// <summary>The general constants defined for Central Station.</summary>
internal class Constant
{
    /// <summary>The unique mod ID for Central Station.</summary>
    public const string ModId = "Pathoschild.CentralStation";

    /// <summary>The unique ID for the Central Station location.</summary>
    public const string CentralStationLocationId = $"{Constant.ModId}_CentralStation";

    /// <summary>The map property name which adds a ticket machine automatically to a map.</summary>
    public const string TicketMachineMapProperty = $"{Constant.ModId}_TicketMachine";

    /// <summary>The map property which performs an internal sub-action identified by a <see cref="MapSubActions"/> value.</summary>
    public const string InternalAction = Constant.ModId;

    /// <summary>The map property which opens a destination menu.</summary>
    public const string TicketsAction = "CentralStation";
}
