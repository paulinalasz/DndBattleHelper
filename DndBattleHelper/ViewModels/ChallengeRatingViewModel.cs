using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.Models.Enums;

namespace DndBattleHelper.ViewModels
{
    public class ChallengeRatingViewModel : NotifyPropertyChanged
    {
        private readonly ChallengeRating _challengeRating;

        public ChallengeRatingViewModel(ChallengeRating challengeRating) 
        {
            _challengeRating = challengeRating;
        }

        public ChallengeRatingLevel SelectedChallengeRating
        {
            get { return _challengeRating.ChallengeRatingLevel; }
            set
            {
                _challengeRating.ChallengeRatingLevel = value;
                OnPropertyChanged(nameof(SelectedChallengeRating));
                OnPropertyChanged(nameof(Xp));
            }
        }

        public int Xp => _challengeRating.Xp;
    }
}
