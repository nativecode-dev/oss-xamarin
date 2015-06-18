namespace Demo.ViewModels
{
    using PropertyChanged;

    [ImplementPropertyChanged]
    public abstract class ViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        public bool IsBusy { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
    }
}