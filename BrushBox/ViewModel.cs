namespace BrushBox
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;
    using Annotations;

    public class ViewModel : INotifyPropertyChanged
    {
        private SolidColorBrush _brush;
        public ViewModel()
        {
            Brush = Brushes.HotPink;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public SolidColorBrush Brush
        {
            get { return _brush; }
            set
            {
                if (Equals(value, _brush))
                {
                    return;
                }
                _brush = value;
                OnPropertyChanged();
            }
        }
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
