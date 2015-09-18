namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System.ComponentModel;

    using Android.Content.Res;
    using Android.Support.Design.Widget;
    using Android.Text;
    using Android.Views;
    using Android.Views.InputMethods;
    using Android.Widget;

    using NativeCode.Mobile.AppCompat.Extensions;
    using NativeCode.Mobile.AppCompat.Helpers;
    using NativeCode.Mobile.AppCompat.Renderers.Extensions;
    using NativeCode.Mobile.AppCompat.Renderers.Renderers.Controls;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    public class AppCompatEntryLayoutRenderer : ViewRenderer<Entry, TextInputLayout>, TextView.IOnEditorActionListener
    {
        private ColorStateList textColorDefault;

        public bool OnEditorAction(TextView v, ImeAction actionId, KeyEvent e)
        {
            if (actionId == ImeAction.Done || (actionId == ImeAction.ImeNull && e.KeyCode == Keycode.Enter))
            {
                this.Element.InvokeSendCompleted();
                this.Control.ClearFocus();
                KeyboardHelper.HideKeyboard(v);
            }

            return true;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                var context = this.Context.GetAppCompatThemedContext();
                var control = new TextInputLayout(context);
                control.AddView(new AppCompatEntryEditText(context));
                control.EditText.ImeOptions = ImeAction.Done;
                control.EditText.SetOnEditorActionListener(this);

                this.textColorDefault = control.EditText.TextColors;
                this.SetNativeControl(control);
            }

            this.Control.EditText.Hint = this.Element.Placeholder;
            this.Control.EditText.Text = this.Element.Text;

            this.UpdateColor();
            this.UpdateHint();
            this.UpdateInputType();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Entry.PlaceholderProperty.PropertyName)
            {
                this.UpdateHint();
            }
            else if (e.PropertyName == Entry.IsPasswordProperty.PropertyName)
            {
                this.UpdateInputType();
            }
            else if (e.PropertyName == Entry.TextProperty.PropertyName)
            {
                if (this.Control.EditText.Text != this.Element.Text)
                {
                    this.Control.EditText.Text = this.Element.Text;

                    if (this.Control.IsFocused)
                    {
                        this.Control.EditText.SetSelection(this.Control.EditText.Text.Length);
                        KeyboardHelper.ShowKeyboard(this.Control);
                    }
                }
            }
            else if (e.PropertyName == Entry.TextColorProperty.PropertyName)
            {
                this.UpdateColor();
            }
            else if (e.PropertyName == InputView.KeyboardProperty.PropertyName)
            {
                this.UpdateInputType();
            }

            base.OnElementPropertyChanged(sender, e);
        }

        private void UpdateColor()
        {
            if (this.Element.TextColor == Color.Default)
            {
                this.Control.EditText.SetTextColor(this.textColorDefault);
            }
            else
            {
                this.Control.EditText.SetTextColor(this.Element.TextColor.ToAndroid());
            }
        }

        private void UpdateHint()
        {
            this.Control.EditText.Hint = this.Element.Placeholder;
        }

        private void UpdateInputType()
        {
            this.Control.EditText.InputType = KeyboardHelper.GetInputType(this.Element.Keyboard);

            if (this.Element.IsPassword && (this.Control.EditText.InputType & InputTypes.ClassText) == InputTypes.ClassText)
            {
                this.Control.EditText.InputType = this.Control.EditText.InputType | InputTypes.TextVariationPassword;
            }

            if (!this.Element.IsPassword || (this.Control.EditText.InputType & InputTypes.ClassNumber) != InputTypes.ClassNumber)
            {
                return;
            }

            this.Control.EditText.InputType = this.Control.EditText.InputType | InputTypes.DatetimeVariationDate;
        }
    }
}