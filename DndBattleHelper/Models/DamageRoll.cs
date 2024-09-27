﻿using DndBattleHelper.Helpers;
using System.Windows.Input;

namespace DndBattleHelper.Models
{
    public class DamageRoll
    {
        public int NumberOfDice { get; set; }
        public int DiceBase { get; set; }
        public Modifier DamageModifier { get; set; }
        public DamageType DamageType { get; set; }

        public DamageRoll(int number, int diceBase, Modifier modifier, DamageType damageType)
        {
            NumberOfDice = number;
            DiceBase = diceBase;
            DamageModifier = modifier;
            DamageType = damageType;
        }

        public Damage RollDamage(bool critialHit)
        {
            Random rand = new Random();

            var damage = 0;

            for(int i = 0; i <= NumberOfDice; i++) 
            {
                damage += rand.Next(1, DiceBase + 1);
            }

            if(critialHit) 
            {
                for (int i = 0; i <= NumberOfDice; i++)
                {
                    damage += rand.Next(1, DiceBase + 1);
                }
            }

            return new Damage(damage, DamageType);

        }
    }
}
