namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System.ComponentModel;

    using Android.Content.Res;
    using Android.Text;
    using Android.Views;
    using Android.Views.InputMethods;
    using Android.Widget;

    using Java.Lang;

    using NativeCode.Mobile.AppCompat.Extensions;
    using NativeCode.Mobile.AppCompat.Renderers.Extensions;
    using NativeCode.Mobile.AppCompat.Renderers.Helpers;
    using NativeCode.Mobile.AppCompat.Renderers.Renderers.Controls;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    public class AppCompatEntryRenderer : ViewRenderer<Entry, AppCompatEntryEditText>, ITextWatcher, TextView.IOnEditorActionListener
    {
        private ColorStateList textColorDefault;

        public AppCompatEntryRenderer()
        {
            this.AutoPackage = false;
        }

        void ITextWatcher.AfterTextChanged(IEditable s)
        {
        }

        void ITextWatcher.BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
        }

        void ITextWatcher.OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            ((IElementController)this.Element).SetValueFromRenderer(Entry.TextProperty, s.ToString());
        }

        bool TextView.IOnEditorActionListener.OnEditorAction(TextView v, ImeAction actionId, KeyEvent e)
        {
            if (actionId == ImeAction.Done)
            {
                this.Element.InvokeSendCompleted();
                this.Control.ClearFocus();
                KeyboardHelper.HideKeyboard(v);
            }

            if (actionId == ImeAction.ImeNull && e.KeyCode == Keycode.Enter)
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

            ReflectionHelper.SetFieldValue(this, "HandleKeyboardOnFocus", true);

            if (e.OldElement == null)
            {
                var control = new AppCompatEntryEditText(this.Context.GetAppCompatThemedContext());
                this.SetNativeControl(control);

                this.Control.ImeOptions = ImeAction.Done;
                this.Control.AddTextChangedListener(this);
                this.Control.SetOnEditorActionListener(this);
                this.Control.OnKeyboardBackPressed += (sender, args) => this.Control.ClearFocus();
                this.textColorDefault = this.Control.TextColors;
            }

            this.Control.Hint = this.Element.Placeholder;
            this.Control.Text = this.Element.Text;
            this.UpdateInputType();
            this.UpdateColor();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Entry.PlaceholderProperty.PropertyName)
            {
                this.Control.Hint = this.Element.Placeholder;
            }
            else if (e.PropertyName == Entry.IsPasswordProperty.PropertyName)
            {
                this.UpdateInputType();
            }
            else if (e.PropertyName == Entry.TextProperty.PropertyName)
            {
                if (this.Control.Text != this.Element.Text)
                {
                    this.Control.Text = this.Element.Text;

                    if (this.Control.IsFocused)
                    {
                        this.Control.SetSelection(this.Control.Text.Length);
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
                this.Control.SetTextColor(this.textColorDefault);
            }
            else
            {
                this.Control.SetTextColor(this.Element.TextColor.ToAndroid());
            }
        }

        private void UpdateInputType()
        {
            this.Control.InputType = KeyboardHelper.GetInputType(this.Element.Keyboard);

            if (this.Element.IsPassword && (this.Control.InputType & InputTypes.ClassText) == InputTypes.ClassText)
            {
                this.Control.InputType = this.Control.InputType | InputTypes.TextVariationPassword;
            }

            if (!this.Element.IsPassword || (this.Control.InputType & InputTypes.ClassNumber) != InputTypes.ClassNumber)
            {
                return;
            }

            this.Control.InputType = this.Control.InputType | InputTypes.DatetimeVariationDate;
        }
    }
}