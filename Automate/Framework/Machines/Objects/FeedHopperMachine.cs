using System;
using System.Linq;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Buildings;
using SObject = StardewValley.Object;

namespace Pathoschild.Stardew.Automate.Framework.Machines.Objects
{
    /// <summary>A hay hopper that accepts input and provides output.</summary>
    /// <remarks>Derived from <see cref="SObject.performObjectDropInAction"/> (search for 'Feed Hopper').</remarks>
    internal class FeedHopperMachine : BaseMachine
    {
        /*********
        ** Public methods
        *********/
        /// <summary>Construct an instance.</summary>
        /// <param name="location">The location containing the machine.</param>
        /// <param name="tile">The tile covered by the machine.</param>
        public FeedHopperMachine(GameLocation location, Vector2 tile)
            : base(location, BaseMachine.GetTileAreaFor(tile)) { }

        /// <summary>Construct an instance.</summary>
        /// <param name="silo">The silo to automate.</param>
        /// <param name="location">The location containing the machine.</param>
        public FeedHopperMachine(Building silo, GameLocation location)
            : base(location, BaseMachine.GetTileAreaFor(silo)) { }

        /// <inheritdoc />
        public override MachineState GetState()
        {
            return this.CanStoreHay(out _, out _)
                ? MachineState.Empty // 'empty' insofar as it will accept more input, not necessarily empty
                : MachineState.Disabled;
        }

        /// <inheritdoc />
        public override ITrackedStack? GetOutput()
        {
            return null;
        }

        /// <inheritdoc />
        public override bool SetInput(IStorage input)
        {
            if (!this.CanStoreHay(out GameLocation location, out int freeSpace))
                return false;

            // try to add hay until full
            bool anyPulled = false;
            foreach (ITrackedStack stack in input.GetItems().Where(p => p.Sample.QualifiedItemId == SObject.hayQID))
            {
                // pull hay
                int maxToAdd = Math.Min(stack.Count, freeSpace);
                int added = maxToAdd - location.tryToAddHay(maxToAdd);
                stack.Reduce(added);
                if (added > 0)
                    anyPulled = true;

                freeSpace -= added;
                if (freeSpace <= 0)
                    break;
            }

            return anyPulled;
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Get whether the machine can store any hay.</summary>
        /// <param name="location">The location in which hay should be stored, if applicable.</param>
        /// <param name="freeSpace">The amount of further hay which can be stored.</param>
        /// <returns>Returns whether any hay can be stored in the location.</returns>
        private bool CanStoreHay(out GameLocation location, out int freeSpace)
        {
            location = this.Location;
            int capacity = location.GetHayCapacity();

            if (capacity <= 0)
            {
                GameLocation parentLocation = location.GetParentLocation();
                capacity = parentLocation?.GetHayCapacity() ?? 0;
                if (capacity > 0)
                    location = parentLocation!;
            }

            freeSpace = capacity - location.piecesOfHay.Value;
            if (freeSpace < 0)
                freeSpace = 0;

            return freeSpace > 0;
        }
    }
}
