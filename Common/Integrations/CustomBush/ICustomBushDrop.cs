using StardewValley;
using StardewValley.GameData;

namespace Pathoschild.Stardew.Common.Integrations.CustomBush;

/// <summary>An item produced by a Custom Bush bush.</summary>
public interface ICustomBushDrop : ISpawnItemData
{
    /// <summary>Gets the probability that the item will be produced.</summary>
    float Chance { get; }

    /// <summary>A game state query which indicates whether the item should be added. Defaults to always added.</summary>
    string? Condition { get; }

    /// <summary>An ID for this entry within the current list (not the item itself, which is <see cref="P:StardewValley.GameData.GenericSpawnItemData.ItemId" />). This only needs to be unique within the current list. For a custom entry, you should use a globally unique ID which includes your mod ID like <c>ExampleMod.Id_ItemName</c>.</summary>
    string? Id { get; }

    /// <summary>Gets the specific season when the item can be produced.</summary>
    Season? Season { get; }

    /// <summary>Gets or sets an offset to the texture sprite which the item is produced.</summary>
    public int SpriteOffset { get; }
}
