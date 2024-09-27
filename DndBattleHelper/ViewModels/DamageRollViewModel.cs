using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using System.Windows.Input;

namespace DndBattleHelper.ViewModels
{
    public class DamageRollViewModel
    {
        public int NumberOfDice { get; set; }
        public int DiceBase { get; set; }
        public Modifier DamageModifier { get; set; }
        public DamageType DamageType { get; set; }

        private DamageRoll _damageRoll;

        public DamageRollViewModel(DamageRoll damageRoll)
        {
            _damageRoll = damageRoll;

            NumberOfDice = damageRoll.NumberOfDice;
            DiceBase = damageRoll.DiceBase;
            DamageModifier = damageRoll.DamageModifier;
            DamageType = damageRoll.DamageType;
        }

        public Damage RollDamage()
        {
            return _damageRoll.RollDamage();
        }
    }
}
