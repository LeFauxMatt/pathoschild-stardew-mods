using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework.Graphics;
using StardewValley.TerrainFeatures;

namespace Pathoschild.Stardew.Common.Integrations.CustomBush;

/// <summary>The API provided by the Custom Bush mod.</summary>
[SuppressMessage("ReSharper", "InconsistentNaming", Justification = "The naming convention is defined by the Custom Bush mod.")]
public interface ICustomBushApi
{
    /// <summary>Try to get the custom bush model associated with the given bush.</summary>
    /// <param name="bush">The bush to check.</param>
    /// <param name="customBush">The resulting custom bush, if applicable.</param>
    /// <returns>Returns whether a custom bush was found.</returns>
    bool TryGetBush(Bush bush, [NotNullWhen(true)] out ICustomBush? customBush);

    /// <summary>Try to get the currently relevant texture for the given bush.</summary>
    /// <param name="bush">The bush.</param>
    /// <param name="texture">The bush's texture.</param>
    /// <returns>True if a custom bush is associated with the given bush and a texture is found.</returns>
    bool TryGetTexture(Bush bush, [NotNullWhen(true)] out Texture2D? texture);
}
