namespace NativeCode.Mobile.AppCompat.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DisposableContainer : IDisposableContainer
    {
        private readonly List<IDisposable> disposables = new List<IDisposable>();

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Add(IDisposable disposable)
        {
            this.disposables.Add(disposable);
        }

        public T Add<T>(T disposable) where T : IDisposable
        {
            this.Add((IDisposable)disposable);

            return disposable;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.disposables.Any())
            {
                foreach (var disposable in this.disposables)
                {
                    disposable.Dispose();
                }

                this.disposables.Clear();
            }
        }
    }
}