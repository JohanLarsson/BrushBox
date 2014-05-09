namespace BrushBox
{
    using System;
    using System.ComponentModel;
    using System.Linq;
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

            var ints = new int[] { 1, 2, 3, 4 };
            int[] array = ints.Where(x => x % 2 == 0)
                              .Select(x => x * 100)
                              .ToArray();
            int i1 = EvaluateLambda(x => x * x, 2);
            int i2 = EvaluateLambda(TheLongWayWhenNotUsingLambda, 2);
            int i3 = EvaluateLambda(x => x + 5, 2);
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

        private int EvaluateLambda(Func<int, int> func, int i)
        {
            int result = func(i);
            return result;
        }

        private int TheLongWayWhenNotUsingLambda(int i)
        {
            return i * i;
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
