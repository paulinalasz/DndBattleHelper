using System.ComponentModel;

namespace DndBattleHelper.Helpers
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IChangeTracking
    {
        protected ViewModelBase()
        {
            PropertyChanged += new PropertyChangedEventHandler(OnNotifiedPropertyChanged);
        }

        private void OnNotifiedPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e != null && !string.Equals(e.PropertyName, "IsChanged", StringComparison.Ordinal))
            {
                IsChanged = true;
            }
        }

        private bool _notifyObjectIsChanged;
        private readonly object _notifyObjectIsChangedSyncRoot = new();

        public bool IsChanged
        {
            get
            {
                lock (_notifyObjectIsChangedSyncRoot)
                {
                    return _notifyObjectIsChanged;
                }
            }

            protected set
            {
                lock (_notifyObjectIsChangedSyncRoot)
                {
                    if (!Equals(_notifyObjectIsChanged, value))
                    {
                        _notifyObjectIsChanged = value;

                        OnPropertyChanged("IsChanged");
                    }
                }
            }
        }

        public void AcceptChanges()
        {
            IsChanged = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged(params string[] propertyNames)
        {
            if (propertyNames == null)
            {
                throw new ArgumentNullException("propertyNames");
            }

            foreach (var propertyName in propertyNames)
            {
                OnPropertyChanged(propertyName);
            }
        }
    }
}
