using DndBattleHelper.Helpers;
using DndBattleHelper.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndBattleHelper.Models
{
    public class ChallengeRating
    {
        public ChallengeRatingLevel ChallengeRatingLevel { get; set; }
        public int Xp => XpCalculator.CalculateXpFromChallengeRating(ChallengeRatingLevel);

        public ChallengeRating(ChallengeRatingLevel challengeRatingLevel)
        {
            ChallengeRatingLevel = challengeRatingLevel;
        }

        public ChallengeRating Copy()
        {
            return new ChallengeRating(ChallengeRatingLevel);
        }
    }
}
