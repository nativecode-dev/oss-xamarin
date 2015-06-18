namespace NativeCode.Mobile.AppCompat.Fonts
{
    using Android.Graphics;

    /// <summary>
    /// Provides an interface to cache types.
    /// </summary>
    /// <remarks><see href="https://github.com/XLabs/Xamarin-Forms-Labs" /></remarks>
    public interface ITypefaceCache
    {
        /// <summary>
        /// Removes a cached typeface.
        /// </summary>
        /// <param name="key">The key.</param>
        void RemoveTypeface(string key);

        /// <summary>
        /// Retrieves a cached typeface.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Returns a <see cref="Typeface" />.</returns>
        Typeface RetrieveTypeface(string key);

        /// <summary>
        /// Stores the typeface.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="typeface">The typeface.</param>
        void StoreTypeface(string key, Typeface typeface);
    }
}