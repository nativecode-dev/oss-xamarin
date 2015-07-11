namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    using Android.App;
    using Android.Content.Res;
    using Android.Support.Design.Widget;
    using Android.Views;

    using NativeCode.Mobile.AppCompat.Controls;
    using NativeCode.Mobile.AppCompat.EventListeners;
    using NativeCode.Mobile.AppCompat.Extensions;
    using NativeCode.Mobile.AppCompat.Renderers.Extensions;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    public class FloatingButtonRenderer : CoordinatorLayout, IVisualElementRenderer
    {
        private static readonly string[] ColorProperties = { FloatingButton.ColorProperty.PropertyName, FloatingButton.ColorPressedProperty.PropertyName };

        public FloatingButtonRenderer() : base(Forms.Context)
        {
        }

        public event EventHandler<VisualElementChangedEventArgs> ElementChanged;

        public VisualElement Element { get; private set; }

        public VisualElementTracker Tracker { get; private set; }

        public ViewGroup ViewGroup
        {
            get { return this; }
        }

        protected Activity Activity
        {
            get { return (Activity)this.Context; }
        }

        protected FloatingActionButton Control { get; private set; }

        protected FloatingButton FloatingButton
        {
            get { return (FloatingButton)this.Element; }
        }

        public void SetElement(VisualElement element)
        {
            var oldElement = this.Element;

            if (oldElement != null)
            {
                this.HookPropertyChanged(oldElement);
            }

            if (oldElement == null)
            {
                this.Element = element;
                this.UnhookPropertyChanged(this.Element);
                this.Tracker = new VisualElementTracker(this);

                if (this.Control == null)
                {
                    this.Control = this.CreateFloatingActionButton();
                    this.Control.Clickable = true;
                    this.Control.SetOnClickListener(new OnClickListener(x => this.FloatingButton.ExecuteCommand()));

                    this.UpdateColorState();
                    this.UpdateIcon();
                }

                this.AddView(this.Control);
            }

            this.OnElementChanged(new VisualElementChangedEventArgs(oldElement, this.Element));
        }

        public SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
        {
            this.Measure(widthConstraint, heightConstraint);
            return new SizeRequest(new Size(this.MeasuredWidth, this.MeasuredHeight));
        }

        public void UpdateLayout()
        {
            if (this.Tracker != null)
            {
                this.Tracker.UpdateLayout();
            }
        }

        protected virtual void OnElementChanged(VisualElementChangedEventArgs e)
        {
            var handler = this.ElementChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void UpdateIcon()
        {
            if (this.FloatingButton.Icon != null)
            {
                this.Control.SetImageDrawable(this.FloatingButton.Icon.ToBitmapDrawable());
            }
        }

        private FloatingActionButton CreateFloatingActionButton()
        {
            var id = this.FloatingButton.ButtonSize == FloatingButtonSize.Mini ? Resource.Layout.fab_mini : Resource.Layout.fab_normal;
            var inflated = this.Activity.LayoutInflater.Inflate(id, this, false);

            return inflated.FindViewById<FloatingActionButton>(inflated.Id);
        }

        private ColorStateList CreateColorStateList()
        {
            var states = new[] { new[] { Android.Resource.Attribute.StateEnabled }, new[] { -Android.Resource.Attribute.StateEnabled }, new[] { Android.Resource.Attribute.StatePressed } };
            var colors = new[] { (int)this.FloatingButton.Color.ToAndroid(), this.FloatingButton.Color.ToAndroid(), this.FloatingButton.ColorPressed.ToAndroid() };

            return new ColorStateList(states, colors);
        }

        private void UpdateColorState()
        {
            if (this.Control.BackgroundTintList != null)
            {
                this.Control.BackgroundTintList.Dispose();
            }

            this.Control.BackgroundTintList = this.CreateColorStateList();
        }

        private void HookPropertyChanged(INotifyPropertyChanged element)
        {
            element.PropertyChanged -= this.HandlePropertyChanged;
        }

        private void UnhookPropertyChanged(INotifyPropertyChanged element)
        {
            element.PropertyChanged += this.HandlePropertyChanged;
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ColorProperties.Contains(e.PropertyName))
            {
                this.UpdateColorState();
            }
        }
    }
}