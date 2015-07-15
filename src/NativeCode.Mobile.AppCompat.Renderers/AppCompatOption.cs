namespace NativeCode.Mobile.AppCompat.Renderers
{
    using System;

    [Flags]
    public enum AppCompatOption
    {
        All = AppCompatButtonSupport | AppCompatEntrySupport | AppCompatMasterDetailSupport | AppCompatSpinnerSupport | AppCompatSwitchSupport | CardViewSupport | FloatingActionButtonSupport | NavigationLayoutSupport,

        None = 0,

        AppCompatButtonSupport = 1 << 0,

        AppCompatEntrySupport = 1 << 1,

        AppCompatMasterDetailSupport = 1 << 2,

        AppCompatSpinnerSupport = 1 << 3,

        AppCompatSwitchSupport = 1 << 4,

        CardViewSupport = 1 << 5,

        FloatingActionButtonSupport = 1 << 6,

        NavigationLayoutSupport = 1 << 7
    }
}