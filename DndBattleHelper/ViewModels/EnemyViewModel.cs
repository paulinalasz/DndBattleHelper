using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public abstract class EnemyViewModel : EntityViewModel
    {
        private readonly Enemy _enemy;

        public EnemyViewModel(Enemy enemy) 
            : base(enemy)
        {
            _enemy = enemy;

            Name = enemy.Name;
            Initiative = enemy.Initiative;
            ArmourClass = enemy.ArmourClass;
            Health = enemy.Health;
            Speed = enemy.Speed;
            Strength = enemy.Strength;
            Dexterity = enemy.Dexterity;
            Constitution = enemy.Constitution;
            Intelligence = enemy.Intelligence;
            Wisdom = enemy.Wisdom;
            Charisma = enemy.Charisma;
        }

        public int ArmourClass
        {
            get { return _enemy.ArmourClass; }
            set
            {
                _enemy.ArmourClass = value;
                OnPropertyChanged(nameof(ArmourClass));
            }
        }

        public int Speed
        {
            get { return _enemy.Speed; }
            set
            {
                _enemy.Speed = value;
                OnPropertyChanged(nameof(Speed));
            }
        }

        public int Strength
        {
            get { return _enemy.Strength; }
            set
            {
                _enemy.Strength = value;
                OnPropertyChanged(nameof(Strength));
            }
        }

        public int Dexterity
        {
            get { return _enemy.Dexterity; }
            set
            {
                _enemy.Dexterity = value;
                OnPropertyChanged(nameof(Dexterity));
            }
        }

        public int Constitution
        {
            get { return _enemy.Constitution; }
            set
            {
                _enemy.Constitution = value;
                OnPropertyChanged(nameof(Constitution));
            }
        }

        public int Intelligence
        {
            get { return _enemy.Intelligence; }
            set
            {
                _enemy.Intelligence = value;
                OnPropertyChanged(nameof(Intelligence));
            }
        }

        public int Wisdom
        {
            get { return _enemy.Wisdom; }
            set
            {
                _enemy.Wisdom = value;
                OnPropertyChanged(nameof(Wisdom));
            }
        }

        public int Charisma
        {
            get { return _enemy.Charisma; }
            set
            {
                _enemy.Charisma = value;
                OnPropertyChanged(nameof(Charisma));
            }
        }

        public override Enemy CopyModel()
        {
            return _enemy.Copy();
        }
    }
}
