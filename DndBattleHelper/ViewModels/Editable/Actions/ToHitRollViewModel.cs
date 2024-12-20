﻿using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable.Actions
{
    public class ToHitRollViewModel
    {
        private ToHitRoll _toHitRoll;
        
        public ToHitRollViewModel(ToHitRoll toHitRoll) 
        {
            _toHitRoll = toHitRoll;
        }

        public override string ToString() 
        {
            var toHitRollString = $"Rolled to hit: {_toHitRoll.ToHitWithModifier} ";

            if (_toHitRoll.AdvantageDisadvantageRoll == 0) 
            {
                toHitRollString += $"({_toHitRoll.Roll}, {_toHitRoll.Modifier}) ";
            }
            else
            {
                toHitRollString += $"(({_toHitRoll.Roll}, {_toHitRoll.AdvantageDisadvantageRoll}), {_toHitRoll.Modifier}). ";
            }

            if (!_toHitRoll.DidAttackHit)
            {
                if (_toHitRoll.Roll == 1)
                {
                    toHitRollString += "Critical miss! ";
                }
                else
                {
                    toHitRollString += "It's a miss! ";
                }
            }
            else
            {
                if (_toHitRoll.Roll == 20)
                {
                    toHitRollString += "Critical hit! ";
                }
                else
                {
                    toHitRollString += "Hits! ";
                }
            }

            return toHitRollString;
        }
    }
}
