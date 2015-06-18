namespace NativeCode.Mobile.AppCompat.Extensions
{
    using System;

    using Xamarin.Forms;

    /// <summary>
    /// Provides extensions for <see cref="Color" /> instances.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Adjusts the color brightness.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="factor">The factor.</param>
        /// <returns>Returns a <see cref="Color" />.</returns>
        public static Color AdjustColorBrightness(this Color color, float factor)
        {
            // TODO: This might need to be tweaked.
            return color.WithHue(Math.Min(color.Saturation * factor, 1.0f));
        }

        /// <summary>
        /// Darkens a color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="factor">The factor.</param>
        /// <returns>Returns a <see cref="Color" />.</returns>
        public static Color DarkenColor(this Color color, float factor)
        {
            return color.AdjustColorBrightness(factor);
        }

        /// <summary>
        /// Halves the transparency value.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Returns a <see cref="Color" />.</returns>
        public static Color HalfTransparent(this Color color)
        {
            return Color.FromRgba(color.A / 2.0, color.R, color.G, color.B);
        }

        /// <summary>
        /// Lightens the color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Returns a <see cref="Color" />.</returns>
        public static Color LightenColor(this Color color)
        {
            return color.AdjustColorBrightness(1.1f);
        }

        /// <summary>
        /// Converts opacity to an alpha value.
        /// </summary>
        /// <param name="opacity">The opacity.</param>
        /// <returns>Returns a <see cref="int" />.</returns>
        public static int OpacityToAlpha(this float opacity)
        {
            return (int)(255f * opacity);
        }

        /// <summary>
        /// Converts a color to be opaque.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Returns a <see cref="Color" />.</returns>
        public static Color OpaqueColor(this Color color)
        {
            return Color.FromRgb(color.R, color.G, color.B);
        }
    }
}