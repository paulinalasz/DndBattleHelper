using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DndBattleHelper.Models.Enums;

namespace DndBattleHelper.Helpers
{
    public static class XpCalculator
    {
        public static int CalculateXpFromChallengeRating(ChallengeRatingLevel challengeRating)
        {
            switch (challengeRating)
            {
                case ChallengeRatingLevel.Zero:
                    return 0;
                case ChallengeRatingLevel.Eighth:
                    return 25;
                case ChallengeRatingLevel.Quater:
                    return 50;
                case ChallengeRatingLevel.Half:
                    return 100;
                case ChallengeRatingLevel.One:
                    return 200;
                case ChallengeRatingLevel.Two:
                    return 450;
                case ChallengeRatingLevel.Three:
                    return 700;
                case ChallengeRatingLevel.Four:
                    return 1100;
                case ChallengeRatingLevel.Five:
                    return 1800;
                case ChallengeRatingLevel.Six:
                    return 2300;
                case ChallengeRatingLevel.Seven:
                    return 2900;
                case ChallengeRatingLevel.Eight:
                    return 3900;
                case ChallengeRatingLevel.Nine:
                    return 5000;
                case ChallengeRatingLevel.Ten:
                    return 5900;
                case ChallengeRatingLevel.Eleven:
                    return 7200;
                case ChallengeRatingLevel.Twelve:
                    return 8400;
                case ChallengeRatingLevel.Thirteen:
                    return 10000;
                case ChallengeRatingLevel.Fourteen:
                    return 11500;
                case ChallengeRatingLevel.Fiftteen:
                    return 13000;
                case ChallengeRatingLevel.Sixteen:
                    return 15000;
                case ChallengeRatingLevel.Seventeen:
                    return 18000;
                case ChallengeRatingLevel.Eighteen:
                    return 20000;
                case ChallengeRatingLevel.Nineteen:
                    return 22000;
                case ChallengeRatingLevel.Twenty:
                    return 25000;
                case ChallengeRatingLevel.TwentyOne:
                    return 33000;
                case ChallengeRatingLevel.TwentyTwo:
                    return 41000;
                case ChallengeRatingLevel.TwentyThree:
                    return 50000;
                case ChallengeRatingLevel.TwentyFour:
                    return 62000;
                case ChallengeRatingLevel.TwentyFive:
                    return 75000;
                case ChallengeRatingLevel.TwentySix:
                    return 90000;
                case ChallengeRatingLevel.TwentySeven:
                    return 105000;
                case ChallengeRatingLevel.TwentyEight:
                    return 120000;
                case ChallengeRatingLevel.TwentyNine:
                    return 135000;
                case ChallengeRatingLevel.Thirty:
                    return 155000;
                default:
                    return -1;
            }
        }
    }
}
