# [Power to the people, Cos!](http://www.imdb.com/title/tt0105435/?ref_=nv_sr_1)

Provide Material Design themes now for Xamarin.Forms apps natively without hacks! Check out the [wiki](https://github.com/nativecode-dev/oss-xamarin/wiki) for more information.

**NOTE**: As it is still very early in the project (v1.1 will be considered production ready), expect breaking changes.

[![Release](https://img.shields.io/teamcity/http/nativecode.no-ip.org:90/s/xamarin_release.svg?style=flat-square&label=release)](http://nativecode.no-ip.org:90/viewType.html?buildTypeId=xamarin_release&guest=1)
[![Development](https://img.shields.io/teamcity/http/nativecode.no-ip.org:90/s/xamarin_development.svg?style=flat-square&label=development)](http://nativecode.no-ip.org:90/viewType.html?buildTypeId=xamarin_development&guest=1)

## [AppCompat](https://www.nuget.org/packages/NativeCode.Mobile.AppCompat/) [![AppCompat](https://img.shields.io/nuget/v/NativeCode.Mobile.AppCompat.svg?style=flat-square&label=AppCompat)](https://www.nuget.org/packages/NativeCode.Mobile.AppCompat/)

Simply install the NuGet package into your Android project.

`Install-Package NativeCode.Mobile.AppCompat`

Once installed, you should replace your *FormsApplicationActivity* derived activities with *AppCompatFormsApplicationActivity*.

For instance:

```csharp
public class MainActivity : AppCompatFormsApplicationActivity
{
  protected override void OnCreate(Bundle savedInstanceState)
  {
    base.OnCreate(savedInstanceState);

    Forms.Init(this, savedInstanceState);

    this.LoadApplication(new App());
  }
}
```

You can then use the normal `Forms.Init` and `LoadApplication` methods to initialize your activities.

You should also set your **Resources/values/styles.xml** to the following:
```xml
<?xml version="1.0" encoding="utf-8"?>

<resources>
  <style name="AppTheme.Base" parent="Theme.AppCompat.Light.DarkActionBar">
    <item name="android:windowDrawsSystemBarBackgrounds">true</item>
    <item name="colorAccent">#8BC34A</item>
    <item name="colorPrimary">#03A9F4</item>
    <item name="colorPrimaryDark">#0288D1</item>
    <item name="drawerArrowStyle">@style/DrawerArrowStyle</item>
    <item name="windowActionModeOverlay">true</item>
  </style>

  <style name="AppTheme" parent="AppTheme.Base">
  </style>

  <style name="DrawerArrowStyle" parent="Widget.AppCompat.DrawerArrowToggle">
    <item name="spinBars">true</item>
    <item name="color">@android:color/white</item>
  </style>
</resources>
```

And also set **Resources/values-v21/styles.xml** to:
```xml
<?xml version="1.0" encoding="utf-8"?>

<resources>
  <style name="AppTheme" parent="AppTheme.Base">
    <item name="android:windowAllowEnterTransitionOverlap">true</item>
    <item name="android:windowAllowReturnTransitionOverlap">true</item>
    <item name="android:windowContentTransitions">true</item>
    <item name="android:windowSharedElementEnterTransition">@android:transition/move</item>
    <item name="android:windowSharedElementExitTransition">@android:transition/move</item>
  </style>
</resources>
```

## [AppCompat Controls](https://www.nuget.org/packages/NativeCode.Mobile.AppCompat.Controls/) [![AppCompat.Controls](https://img.shields.io/nuget/v/NativeCode.Mobile.AppCompat.Controls.svg?style=flat-square&label=AppCompat.Controls)](https://www.nuget.org/packages/NativeCode.Mobile.AppCompat.Controls/)

Simply install the NuGet package into your PCL project that contains your UI.
NOTE: You must install the Renderers package into your Android project.

`Install-Package NativeCode.Mobile.AppCompat.Controls`

### Available controls
- FloatingButton ([FloatingActionButton](https://developer.android.com/reference/android/support/design/widget/FloatingActionButton.html))
- IUserNotifier ([Snackbar](https://developer.android.com/reference/android/support/design/widget/Snackbar.html))

## [AppCompat Renderers](https://www.nuget.org/packages/NativeCode.Mobile.AppCompat.Renderers/) [![AppCompat.Renderers](https://img.shields.io/nuget/v/NativeCode.Mobile.AppCompat.Renderers.svg?style=flat-square&label=AppCompat.Renderers)](https://www.nuget.org/packages/NativeCode.Mobile.AppCompat.Renderers/)

Simply install the NuGet package into your Android project.

`Install-Package NativeCode.Mobile.AppCompat.Renderers`

Once installed, you will have to call `AppCompatRenderers.EnableAll` inside your OnCreate, after `Forms.Init` is called. This will register all of the AppCompat renderers to replace existing Xamarin.Forms renderers.

```csharp
public class MainActivity : AppCompatFormsApplicationActivity
{
  protected override void OnCreate(Bundle savedInstanceState)
  {
    base.OnCreate(savedInstanceState);

    Forms.Init(this, savedInstanceState);
    FormsAppCompat.EnableAll();

    this.LoadApplication(new App());
  }
}
```


### Current Renderers
- Button ([AppCompatButton](http://developer.android.com/reference/android/support/v7/widget/AppCompatButton.html))
- Entry ([AppCompatEditText](http://developer.android.com/reference/android/support/v7/widget/AppCompatEditText.html))
- Switch ([SwitchCompat](http://developer.android.com/reference/android/support/v7/widget/SwitchCompat.html))
- MasterDetailPage

## Devices Tested

### Phones
- Nexus 5 (emulator)
- Samsung Galaxy S6

![phone](screenshots/phone.gif)

### Tablets
- Samsung Tab 7
- Nexus 7

![tablet](screenshots/tablet.gif)

### LICENSE
```
   Copyright 2015 NativeCode Development

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 ```
