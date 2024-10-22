namespace DndBattleHelper.ViewModels.Editable.Actions
{
    public class TakenActionViewModel
    {
        private string _actionName;
        private ToHitRollViewModel _toHitRollViewModel;
        public AttackDamageViewModel AttackDamageViewModel { get; }

        public TakenActionViewModel(string actionName, ToHitRollViewModel toHitRollViewModel = null, AttackDamageViewModel attackDamageViewModel = null) 
        {
            _actionName = actionName;
            _toHitRollViewModel = toHitRollViewModel;
            AttackDamageViewModel = attackDamageViewModel;
        }

        public override string ToString()
        {
            var takenActionString = $"{_actionName} taken. ";
            if (_toHitRollViewModel != null) 
            {
                takenActionString += _toHitRollViewModel.ToString();
            }

            if (AttackDamageViewModel != null)
            {
                takenActionString += AttackDamageViewModel.ToString();
            }

            return takenActionString;
        }
    }
}
