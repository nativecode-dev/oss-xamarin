namespace NativeCode.Mobile.AppCompat.Helpers
{
    using Android.Views;

    public static class LayoutParamsHelper
    {
        public const int MatchParent = -1;

        public const int WrapContent = -2;

        public static ViewGroup.LayoutParams MatchParentLayout()
        {
            return new ViewGroup.LayoutParams(MatchParent, MatchParent);
        }

        public static ViewGroup.LayoutParams WrapContentLayout()
        {
            return new ViewGroup.LayoutParams(WrapContent, WrapContent);
        }
    }
}