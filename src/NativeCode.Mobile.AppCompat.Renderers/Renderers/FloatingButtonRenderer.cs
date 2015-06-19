using NativeCode.Mobile.AppCompat.Controls;
using NativeCode.Mobile.AppCompat.Renderers.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FloatingButton), typeof(FloatingButtonRenderer))]

namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System;

    using Android.App;
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
            if (element != null)
            {
                var oldElement = this.Element;
                var newElement = element;

                this.Element = element;
                this.Tracker = new VisualElementTracker(this);

                this.OnElementChanged(new VisualElementChangedEventArgs(oldElement, newElement));

                this.AddView(this.Control);
            }
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

            if (this.Control == null)
            {
                this.Control = this.CreateFloatingActionButton();
                this.Control.Clickable = true;
                this.Control.SetOnClickListener(new OnClickListener(x => this.FloatingButton.ExecuteCommand()));

                this.UpdateIcon();
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
    }
}