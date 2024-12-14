namespace DndBattleHelper.ViewModels
{
    public abstract class ViewModelBaseWithChildViewModels : ViewModelBase
    {
        public ViewModelBaseWithChildViewModels(IEnumerable<ViewModelBase> childViewModels) 
        {
            ChildViewModels = childViewModels;
        }

        public IEnumerable<ViewModelBase> ChildViewModels { get; set; }

        private bool _notifyObjectIsChanged;
        private readonly object _notifyObjectIsChangedSyncRoot = new();

        public override bool IsChanged
        {
            get
            {
                lock (_notifyObjectIsChangedSyncRoot)
                {
                    var isChanged = _notifyObjectIsChanged;

                    foreach (var childView in ChildViewModels)
                    {
                        if (childView.IsChanged)
                        {
                            isChanged = true;
                        }
                    }

                    return isChanged;
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
    }
}
