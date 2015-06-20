using NativeCode.Mobile.AppCompat.Controls;
using NativeCode.Mobile.AppCompat.Renderers.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Card), typeof(CardRenderer))]

namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System;
    using System.ComponentModel;

    using Android.OS;
    using Android.Support.V7.Widget;
    using Android.Views;

    using NativeCode.Mobile.AppCompat.Controls;
    using NativeCode.Mobile.AppCompat.Extensions;
    using NativeCode.Mobile.AppCompat.Renderers.Helpers;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    public class CardRenderer : CardView, IVisualElementRenderer
    {
        public CardRenderer() : base(Forms.Context.GetAppCompatThemedContext())
        {
        }

        public event EventHandler<VisualElementChangedEventArgs> ElementChanged;

        VisualElement IVisualElementRenderer.Element
        {
            get { return this.Element; }
        }

        public VisualElementTracker Tracker { get; private set; }

        public ViewGroup ViewGroup
        {
            get { return this; }
        }

        protected Card Element { get; private set; }

        protected VisualElementPackager Packager { get; private set; }

        public void SetElement(VisualElement element)
        {
            var oldElement = this.Element;
            var newElement = element;
            this.Element = (Card)element;

            if (oldElement != null)
            {
                oldElement.PropertyChanged -= this.OnElementPropertyChanged;
            }

            if (newElement != null)
            {
                newElement.PropertyChanged += this.OnElementPropertyChanged;
            }

            this.LayoutParameters = LayoutParamsHelper.MatchParentLayout();
            this.ViewGroup.RemoveAllViews();

            var lollipop = Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop;
            this.PreventCornerOverlap = !lollipop;
            this.UseCompatPadding = lollipop;

            this.Tracker = new VisualElementTracker(this);
            this.Packager = new VisualElementPackager(this);
            this.Packager.Load();

            this.OnElementChanged(new VisualElementChangedEventArgs(oldElement, newElement));

            this.UpdateBackgroundColor();
            this.UpdatePadding();
            this.UpdateRadius();
        }

        public SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
        {
            this.Measure(widthConstraint, heightConstraint);
            return new SizeRequest(new Size(widthConstraint, heightConstraint));
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

        protected virtual void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
            {
                this.UpdateBackgroundColor();
            }
            else if (e.PropertyName == Xamarin.Forms.Layout.PaddingProperty.PropertyName)
            {
                this.UpdatePadding();
            }
            else if (e.PropertyName == Card.RadiusProperty.PropertyName)
            {
                this.UpdateRadius();
            }
        }

        private void UpdateBackgroundColor()
        {
            this.SetCardBackgroundColor(this.Element.BackgroundColor.ToAndroid());
        }

        private void UpdatePadding()
        {
            var bottom = (int)this.Element.Padding.Bottom;
            var left = (int)this.Element.Padding.Left;
            var right = (int)this.Element.Padding.Right;
            var top = (int)this.Element.Padding.Top;

            this.SetContentPadding(left, top, right, bottom);
        }

        private void UpdateRadius()
        {
            this.Radius = (float)this.Element.Radius;
        }
    }
}