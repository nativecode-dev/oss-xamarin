namespace NativeCode.Mobile.AppCompat.Extensions
{
    using System;

    using Android.Content;
    using Android.Graphics;

    using NativeCode.Mobile.AppCompat.Fonts;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    /// <summary>
    /// Provides extensions for <see cref="Font" /> instances.
    /// </summary>
    public static class FontExtensions
    {
        /// <summary>
        /// Converts a <see cref="Font" /> to a <see cref="Typeface" />.
        /// </summary>
        /// <param name="font">The font.</param>
        /// <param name="context">The context.</param>
        /// <returns>Returns a <see cref="Typeface" />.</returns>
        /// <remarks><see href="https://github.com/XLabs/Xamarin-Forms-Labs" /></remarks>
        public static Typeface ToExtendedTypeface(this Font font, Context context)
        {
            var key = font.ToHashmapKey();
            var typeface = TypefaceCache.SharedCache.RetrieveTypeface(key);

            if (typeface == null && !string.IsNullOrEmpty(font.FontFamily))
            {
                var filename = font.FontFamily;

                if (filename.LastIndexOf(".", StringComparison.Ordinal) != filename.Length - 4)
                {
                    filename = string.Format("{0}.ttf", filename);
                }

                try
                {
                    var path = "fonts/" + filename;
                    typeface = Typeface.CreateFromAsset(context.Assets, path);
                }
                catch
                {
                    try
                    {
                        typeface = Typeface.CreateFromFile("fonts/" + filename);
                    }
                    catch
                    {
                        // TODO: Figure out what logging should look like here, because
                        // this is a completely separate library with no reference to Core.
                    }
                }
            }

            if (typeface == null)
            {
                typeface = font.ToTypeface();
            }

            if (typeface == null)
            {
                typeface = Typeface.Default;
            }

            TypefaceCache.SharedCache.StoreTypeface(key, typeface);

            return typeface;
        }

        /// <summary>
        /// Converts a <see cref="Font"/> size to a <see cref="float"/>.
        /// </summary>
        /// <param name="font">The font.</param>
        /// <returns>Returns a <see cref="float"/>.</returns>
        public static float ToTextSize(this Font font)
        {
            return font.ToScaledPixel() * Forms.Context.Resources.DisplayMetrics.Density;
        }

        private static string ToHashmapKey(this Font font)
        {
            return string.Format("{0}.{1}.{2}.{3}", font.FontFamily, font.FontSize, font.NamedSize, (int)font.FontAttributes);
        }
    }
}