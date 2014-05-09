namespace BrushBox
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;
    using Annotations;

    public class ViewModel : INotifyPropertyChanged
    {
        private SolidColorBrush _brush;
        private string _someText;
        public ViewModel()
        {
            Brush = Brushes.HotPink;
            SomeText = "Text";
            ChangeColorCommand = new RelayCommand(_ =>
            {
                Brush = Equals(Brush, Brushes.HotPink) 
                    ? Brushes.Blue 
                    : Brushes.HotPink;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand ChangeColorCommand { get; private set; }
        
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

        public string SomeText
        {
            get { return _someText; }
            set
            {
                if (value == _someText)
                {
                    return;
                }
                _someText = value;
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
