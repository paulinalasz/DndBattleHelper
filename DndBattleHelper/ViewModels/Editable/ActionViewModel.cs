//using DndBattleHelper.Helpers;
//using DndBattleHelper.Models.ActionTypes;

//namespace DndBattleHelper.ViewModels.Editable
//{
//    public class ActionViewModel : NotifyPropertyChanged, IEditable
//    {
//        private readonly EntityAction _action;

//        public ActionViewModel(EntityAction action)
//        {
//            _action = action;
//        }

//        public string Name
//        {
//            get { return _action.Name; }
//            set
//            {
//                _action.Name = value;
//                OnPropertyChanged(nameof(Name));
//            }
//        }

//        public string Description
//        {
//            get => _action.Description;
//            set
//            {
//                _action.Description = value;
//                OnPropertyChanged(nameof(Description));
//            }
//        }
//    }
//}
