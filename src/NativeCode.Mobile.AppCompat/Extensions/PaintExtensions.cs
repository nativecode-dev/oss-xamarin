namespace NativeCode.Mobile.AppCompat.Extensions
{
    using Android.Graphics;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    /// <summary>
    /// Provides extensions for <see cref="Paint" /> instances.
    /// </summary>
    public static class PaintExtensions
    {
        /// <summary>
        /// Sets the <see cref="Font" /> values for a <see cref="Paint" /> instance.
        /// </summary>
        /// <param name="paint">The paint.</param>
        /// <param name="font">The font.</param>
        public static void SetFont(this Paint paint, Font font)
        {
            paint.SetTypeface(font.ToTypeface());
            paint.TextAlign = Paint.Align.Center;
            paint.TextSize = font.ToTextSize();
        }
    }
}