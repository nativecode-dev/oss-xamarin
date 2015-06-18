namespace NativeCode.Mobile.AppCompat.Extensions
{
    using System;

    using Xamarin.Forms;

    /// <summary>
    /// Provides an exception when converting an <see cref="ImageSource"/> fails.
    /// </summary>
    public class ImageSourceConversionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSourceConversionException"/> class.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        public ImageSourceConversionException(Exception innerException) : base(CreateExceptionMessage(), innerException)
        {
        }

        private static string CreateExceptionMessage()
        {
            return "Failed to find an appropriate handler to manage the requested image source.";
        }
    }
}