namespace NativeCode.Mobile.AppCompat.Renderers.Renderers.Controls
{
    using System;

    using Android.Content;
    using Android.Support.V7.Widget;
    using Android.Views;

    /// <summary>
    /// Provides a text entry control using the compatibility library.
    /// </summary>
    public class AppCompatEntryEditText : AppCompatEditText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppCompatEntryEditText"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AppCompatEntryEditText(Context context) : base(context)
        {
        }

        /// <summary>
        /// Occurs when the keyboard back button is pressed.
        /// </summary>
        public event EventHandler OnKeyboardBackPressed;

        /// <summary>
        /// Handle a key event before it is processed by any input method
        /// associated with the view hierarchy.
        /// </summary>
        /// <param name="keyCode">The value in event.getKeyCode().</param>
        /// <param name="e">Description of the key event.</param>
        /// <returns>To be added.</returns>
        /// <since version="Added in API level 3" />
        /// <remarks><para tool="javadoc-to-mdoc">Handle a key event before it is processed by any input method
        /// associated with the view hierarchy.  This can be used to intercept
        /// key events in special situations before the IME consumes them; a
        /// typical example would be handling the BACK key to update the application's
        /// UI instead of allowing the IME to see it and close itself.</para>
        /// <para tool="javadoc-to-mdoc">
        ///   <format type="text/html">
        ///     <a href="http://developer.android.com/reference/android/view/View.html#onKeyPreIme(int, android.view.KeyEvent)" target="_blank">[Android Documentation]</a>
        ///   </format>
        /// </para></remarks>
        public override bool OnKeyPreIme(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back && e.Action == KeyEventActions.Down)
            {
                var handler = this.OnKeyboardBackPressed;

                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }

            return base.OnKeyPreIme(keyCode, e);
        }
    }
}