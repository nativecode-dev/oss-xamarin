namespace NativeCode.Mobile.AppCompat
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;

    using Android.App;
    using Android.Support.Design.Widget;
    using Android.Views;

    using NativeCode.Mobile.AppCompat.EventListeners;
    using NativeCode.Mobile.AppCompat.Helpers;

    using Xamarin.Forms.Platform.Android;

    using View = Xamarin.Forms.View;

    /// <summary>
    /// Provides a renderer for controls that should be inflated from a resource.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TNativeView">The type of the native view.</typeparam>
    public abstract class InflateViewRenderer<TView, TNativeView> : ViewRenderer<TView, TNativeView>, IDisposableContainer
        where TView : View where TNativeView : Android.Views.View
    {
        private readonly List<IDisposable> disposables = new List<IDisposable>();

        /// <summary>
        /// Gets the <see cref="Activity"/> instance.
        /// </summary>
        protected Activity Activity
        {
            get { return (Activity)this.Context; }
        }

        /// <summary>
        /// Gets the <see cref="LayoutInflater"/> instance.
        /// </summary>
        protected LayoutInflater LayoutInflater
        {
            get { return this.Activity.LayoutInflater; }
        }

        /// <summary>
        /// Registers a <see cref="IDisposable" /> for later disposal.
        /// </summary>
        /// <param name="disposable">The disposable.</param>
        public void Add(IDisposable disposable)
        {
            this.disposables.Add(disposable);
        }

        /// <summary>
        /// Registers a <see cref="IDisposable" /> for later disposal.
        /// </summary>
        /// <typeparam name="T">The type that implements <see cref="IDisposable" />.</typeparam>
        /// <param name="disposable">The disposable.</param>
        /// <returns>Returns the instance passed in.</returns>
        public T Add<T>(T disposable) where T : IDisposable
        {
            this.disposables.Add(disposable);
            return disposable;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var disposable in this.disposables)
                {
                    disposable.Dispose();
                }

                this.disposables.Clear();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Handles the click state of a view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="command">The command.</param>
        /// <param name="parameter">The parameter.</param>
        protected virtual void HandleClickListener(TNativeView view, ICommand command, object parameter)
        {
            if (command != null && command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }
        }

        /// <summary>
        /// Inflates the native control from a resource.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="group">The group.</param>
        /// <param name="attachToRoot">if set to <c>true</c> [attach to root].</param>
        /// <returns>Returns a <see cref="TNativeView" /> instance.</returns>
        /// <exception cref="System.InvalidCastException">Could not cast the View to a  + typeof(TNativeView).Name + .</exception>
        protected TNativeView InflateNativeControl(int id, ViewGroup @group = null, bool attachToRoot = false)
        {
            return this.InflateNativeControl<TNativeView>(id, @group, attachToRoot);
        }

        /// <summary>
        /// Inflates the native control from a resource.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="group">The group.</param>
        /// <param name="attachToRoot">if set to <c>true</c> [attach to root].</param>
        /// <returns>Returns a casted <see cref="View" />.</returns>
        /// <exception cref="System.InvalidCastException">Could not cast the view {0} to a {1}.</exception>
        protected T InflateNativeControl<T>(int id, ViewGroup @group = null, bool attachToRoot = false) where T : Android.Views.View
        {
            var inflated = this.LayoutInflater.Inflate(id, @group, attachToRoot);
            var view = inflated.FindViewById<FloatingActionButton>(inflated.Id);
            var native = view as T;

            if (native == null)
            {
                throw new InvalidCastException(string.Format("Could not cast the view {0} to a {1}.", view.GetType().Name, typeof(T).Name));
            }

            return native;
        }

        /// <summary>
        /// Setup click handle listener for the provided view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="command">The command.</param>
        /// <param name="parameter">The parameter.</param>
        protected void SetupClickable(TNativeView view, ICommand command, object parameter)
        {
            var listener = new OnClickListener(v => this.HandleClickListener(this.Control, command, parameter));
            this.Add(listener);

            view.Clickable = true;
            view.SetOnClickListener(listener);
        }
    }
}