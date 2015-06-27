namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System.ComponentModel;

    using Android.Support.V7.Widget;
    using Android.Widget;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    using View = Android.Views.View;

    public class AppCompatSpinnerRenderer : InflateViewRenderer<Picker, AppCompatSpinner>, AdapterView.IOnItemSelectedListener
    {
        protected ArrayAdapter<object> Adapter { get; private set; }

        public void OnItemSelected(AdapterView parent, View view, int position, long id)
        {
            if (this.Element.SelectedIndex != position)
            {
                ((IElementController)this.Element).SetValueFromRenderer(Picker.SelectedIndexProperty, position);
            }
        }

        public void OnNothingSelected(AdapterView parent)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                var control = this.InflateNativeControl<AppCompatSpinner>(Resource.Layout.spinner);
                control.Adapter = this.Adapter = new ArrayAdapter<object>(this.Context, Android.Resource.Layout.SimpleListItemActivated1);
                control.Clickable = true;
                control.OnItemSelectedListener = this;

                this.SetNativeControl(control);

                this.UpdateItems();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Picker.SelectedIndexProperty.PropertyName)
            {
                if (this.Control.SelectedItemPosition != this.Element.SelectedIndex)
                {
                    this.Control.SetSelection(this.Element.SelectedIndex);
                }
            }
        }

        private void UpdateItems()
        {
            this.Adapter.Clear();

            foreach (var item in this.Element.Items)
            {
                this.Adapter.Add(item);
            }
        }
    }
}