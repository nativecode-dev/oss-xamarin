namespace NativeCode.Mobile.AppCompat.Renderers.Helpers
{
    using Android.Views;

    internal static class MeasureSpecFactory
    {
        public static int MakeMeasureSpec(int size, MeasureSpecMode mode)
        {
            return (int)(size + mode);
        }

        public static int GetSize(int measureSpec)
        {
            return measureSpec & 1073741823;
        }
    }
}