using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;

namespace BailuTools.Extension;

internal sealed class FontIconExtension : MarkupExtension
{
    /// <summary>
    /// Gets or sets the <see cref="string"/> value representing the icon to display.
    /// </summary>
    public string Glyph { get; set; } = default!;

    /// <inheritdoc/>
    protected override object ProvideValue()
    {
        return new FontIcon()
        {
            Glyph = Glyph
        };
    }
}