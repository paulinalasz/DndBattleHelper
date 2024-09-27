using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DndBattleHelper.ViewModels
{
    public class EntityActionViewModel
    {
        private readonly TargetArmourClassProvider _targetArmourClassProvider;

        public string Name { get; set; }
        public string Description { get; set; }
        public ActionCost Type { get; set; }

        // Can have multiple damage rolls of different type for the same action
        public List<DamageRollViewModel> DamageRolls { get; set; }

        //But only one To Hit Modifier
        public Modifier ToHit { get; set; }

        public EntityActionViewModel(EntityAction entityAction, TargetArmourClassProvider targetArmourClass)
        {
            Name = entityAction.Name;
            Description = entityAction.Description; 
            Type = entityAction.Type;
            ToHit = entityAction.ToHit;

            DamageRolls = new List<DamageRollViewModel>();

            foreach(var damageRoll in  entityAction.DamageRolls) 
            {
                DamageRolls.Add(new DamageRollViewModel(damageRoll));
            }

            _targetArmourClassProvider = targetArmourClass;
        }

        public Action ActionTaken;

        private ICommand _rollDamageCommand;
        public ICommand RollDamageCommand => _rollDamageCommand ?? (_rollDamageCommand = new CommandHandler(() => RollDamage(), () => { return true; }));

        public AttackDamageViewModel MostRecentDamageRolled { get; set; }

        public void RollDamage(ToHitRoll toHitRoll = null)
        {
            var damageRolled = new ObservableCollection<Damage>();

            foreach(var damageRoll in DamageRolls)
            {
                damageRolled.Add(damageRoll.RollDamage());
            }

            MostRecentDamageRolled = new AttackDamageViewModel(Name, toHitRoll, damageRolled);
            ActionTaken?.Invoke();
        }

        private ICommand _rollToHitAndDamageCommand;
        public ICommand RollToHitAndDamageCommand => _rollToHitAndDamageCommand ?? (_rollToHitAndDamageCommand = new CommandHandler(() => RollToHitAndDamage(_targetArmourClassProvider.TargetArmourClass), () => { return true; }));

        private ToHitRoll DoesAttackHit(int armourClass)
        {
            Random rand = new Random();

            var roll = rand.Next(1, 21);

            var withModifier = roll + ToHit.ToInt();

            if (withModifier >= armourClass)
            {
                return new ToHitRoll(true, roll, withModifier);
            }

            return new ToHitRoll(false, roll, withModifier);
        }

        public void RollToHitAndDamage(int armourClass)
        {
            Random rand = new Random();

            var toHitRoll = DoesAttackHit(armourClass);

            if (!toHitRoll.DidAttackHit)
            {
                MostRecentDamageRolled = new AttackDamageViewModel(Name, toHitRoll);
                ActionTaken?.Invoke();
                return;
            }

            RollDamage(toHitRoll);
        }
    }
}
