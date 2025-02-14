using System.Collections.Generic;
using ContentPatcher.Framework.Conditions;

namespace ContentPatcher.Framework.Tokens.ValueProviders;

/// <summary>A value provider which returns a string representation of the input argument.</summary>
internal class RenderValueProvider : BaseValueProvider
{
    /*********
    ** Public methods
    *********/
    /// <summary>Construct an instance.</summary>
    public RenderValueProvider()
        : base(ConditionType.Render, mayReturnMultipleValuesForRoot: false, isDeterministicForInput: true)
    {
        this.EnableInputArguments(required: false, mayReturnMultipleValues: false, maxPositionalArgs: null);
    }

    /// <inheritdoc />
    public override bool UpdateContext(IContext context)
    {
        bool changed = !this.IsReady;
        this.MarkReady(true);
        return changed;
    }

    /// <inheritdoc />
    public override IEnumerable<string> GetValues(IInputArguments input)
    {
        this.AssertInput(input);

        string value = input.HasPositionalArgs
            ? string.Join(", ", input.PositionalArgs)
            : string.Empty;

        return InvariantSets.FromValue(value);
    }
}
