namespace Demo.ViewModels
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using PropertyChanged;

    [ImplementPropertyChanged]
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        public bool IsBusy { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string property = null)
        {
            var handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}