using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clicker_Heroes_Calculator.Classes;
using Clicker_Heroes_Calculator.Interfaces;
using Clicker_Heroes_Calculator.Models;
using System.Numerics;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace Clicker_Heroes_Calculator.ViewModels
{
    /// <summary>
    /// This view model shapes the data for the HeroView
    /// </summary>
    public class HeroViewModel : ObservableObject
    {
        #region Fields

        /// <summary>
        /// Store for the Hero Property
        /// </summary>
        readonly IHero _hero;
        /// <summary>
        /// Store for the Data Manager
        /// </summary>
        readonly IDataManager _dataManager;
        /// <summary>
        /// Store for the collection of Upgrades
        /// </summary>
        public ObservableCollection<UpgradeViewModel> HeroUpgrades { get; private set; }

        #endregion //  Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroViewModel{T, T}"/> class.
        /// </summary>
        /// <param name="hero">The Hero Model that hold the hero's data</param>
        /// <param name="dataManager">The Data Manager to retrieve the hero's upgrade</param>
        public HeroViewModel(IHero hero, IDataManager dataManager)
        {
            if (hero == null)
                throw new ArgumentNullException("hero");

            if (dataManager == null)
                throw new ArgumentNullException("dataManager");

            _hero = hero;
            _dataManager = dataManager;

            this.CreateHeroUpgrades();
        }

        #endregion // Constructor

        #region Hero Properties

        /// <summary>
        /// The hero's name
        /// </summary>
        public string Name
        {
            get { return _hero.Name; }
        }

        /// <summary>
        /// The hero's description
        /// </summary>
        public string Description
        {
            get { return _hero.Description; }
        }

        /// <summary>
        /// The hero's level
        /// </summary>
        public int Level
        {
            get { return _hero.Level; }
            set
            {
                if (value == _hero.Level)
                    return;

                _hero.Level = value;

                base.OnPropertyChanged("CurrentDPS");
                base.OnPropertyChanged("CurrentDPSPopup");
                base.OnPropertyChanged("NextLevelDPS");
                base.OnPropertyChanged("Level");
                base.OnPropertyChanged("LevelUpButtonText");
                base.OnPropertyChanged("LevelUpCost");
                base.OnPropertyChanged("LevelMultipliersPopup");
            }
        }

        #endregion //  Hero Properties

        #region Presentation Properties

        #region Hero Panel

        /// <summary>
        /// The image of the hero
        /// </summary>
        public string HeroImage
        {
            get { return String.Format(@"\Resources\Images\Heroes\{0}.png", _hero.ID); }
        }

        /// <summary>
        /// The hero's current DPS
        /// </summary>
        public string CurrentDPS
        {
            get
            {
                return Level == 0 ? "0." : NumberConverter.Convert(calculateHeroDPS(Level));
            }
        }

        #endregion //  Hero Panel

        #region Level Up Button

        /// <summary>
        /// The first line of text on the level up button depending on what key is being held.
        /// </summary>
        public string LevelUpButtonText
        {
            get
            {
                if (Keyboard.IsKeyDown(Key.LeftShift))
                    return "x10";
                if (Keyboard.IsKeyDown(Key.Z))
                    return "x25";
                if (Keyboard.IsKeyDown(Key.LeftCtrl))
                    return "x100";
                if (Level == 0)
                    return "HIRE";
                else
                    return "LVL UP";
            }
        }

        /// <summary>
        /// The cost of the hero depending on what key is being held.
        /// </summary>
        public string LevelUpCost
        {
            get
            {
                if (Keyboard.IsKeyDown(Key.LeftShift))
                    return calculateLevelUpCost(10);
                if (Keyboard.IsKeyDown(Key.Z))
                    return calculateLevelUpCost(25);
                if (Keyboard.IsKeyDown(Key.LeftCtrl))
                    return calculateLevelUpCost(100);
                else
                    return calculateLevelUpCost(1);
            }
        }

        #endregion //  Level Up Button

        #region Popup

        /// <summary>
        /// The text for the popup that shows the hero's DPS at the next level
        /// </summary>
        public string NextLevelDPS
        {
            get
            {
                string damage = _hero.ID == 1 ? "Click Damage: " : "DPS: ";
                damage += NumberConverter.Convert(calculateHeroDPS(Level + 1));

                return Level == 0 ? damage : "Next Level:\n " + damage;
            }
        }

        /// <summary>
        /// The text for the popup that shows hero's current DPS.
        /// </summary>
        public string CurrentDPSPopup
        {
            get
            {
                string damageType = _hero.ID == 1 ? "Click Damage: " : "DPS: ";
                return Level == 0 ? "" : "Current Level\n " + damageType + NumberConverter.Convert(calculateHeroDPS(Level));
            }
        }

        /// <summary>
        /// The text for the popup that shows the hero's next two multipliers and the hero's dps at them.
        /// </summary>
        public string LevelMultipliersPopup
        {
            get
            {
                if (Level < 175 || Level >= 4100 || _hero.ID == 1)
                    return "";

                string levelMultipliers = "";

                int nextLevelMultiplier = Level + 25 - (Level % 25);

                levelMultipliers = (nextLevelMultiplier % 1000 == 0 && nextLevelMultiplier != 4000) ? levelMultipliers + "10x " : levelMultipliers + "4x ";

                levelMultipliers += String.Format("damage at level {0}:\n DPS: {1}\n", nextLevelMultiplier, NumberConverter.Convert(calculateHeroDPS(nextLevelMultiplier)));

                if (nextLevelMultiplier != 4100)
                {
                    nextLevelMultiplier += 25;

                    levelMultipliers = (nextLevelMultiplier % 1000 == 0 && nextLevelMultiplier != 4000) ? levelMultipliers + "10x " : levelMultipliers + "4x ";

                    levelMultipliers += String.Format("damage at level {0}:\n DPS: {1}", nextLevelMultiplier, NumberConverter.Convert(calculateHeroDPS(nextLevelMultiplier)));
                }

                return levelMultipliers;
            }
        }

        /// <summary>
        /// The text for the popup that shows the hero's gilded info.
        /// </summary>
        public string GildedPopup
        {
            get { return ""; }
        }

        #endregion //  Popup       

        #endregion //  Presentation Properties

        #region Public Methods

        /// <summary>
        /// This method calculates the cost to level this hero by the number specified.
        /// </summary>
        /// <param name="n">Number of levels to calculate for</param>
        /// <returns>The cost to level the hero</returns>
        public string calculateLevelUpCost(int n)
        {
            double cost = 0.0;

            if (_hero.ID == 1)
                for (int i = 0; i < n; i++)
                    cost += Math.Floor(Math.Min(20, 5 + Level + i) * Math.Pow(1.07, Level + i));
            else
                for (int i = 0; i < n; i++)
                    cost += Math.Floor(_hero.BaseCost * Math.Pow(1.07, Level + i));

            return NumberConverter.Convert(cost);
        }

        /// <summary>
        /// This method calculates the hero's dps for the number specified.
        /// </summary>
        /// <param name="level">The level to calculate the hero's dps for</param>
        /// <returns>Hero's dps at specified number</returns>
        public double calculateHeroDPS(int level)
        {
            double baseDPS = Math.Ceiling((_hero.BaseCost / 10.0) * Math.Pow((1.0 - 0.0188 * Math.Min(_hero.ID, 14.0)), _hero.ID));
            double levelMultiplier = _hero.ID == 1 ? 1.0 : Math.Pow(4, Math.Max(0, Math.Min(157, Math.Floor(level / 25d) - 7))) * Math.Pow(2.5, Math.Min(3, Math.Floor(level / 1000d)));

            return baseDPS * level * levelMultiplier * UpgradeHeroPercentMultiplier();
        }

        /// <summary>
        /// This method returns the multiplier from upgrades for this hero.
        /// </summary>
        /// <returns>The multiplier from upgrades for this hero</returns>
        public double UpgradeHeroPercentMultiplier()
        {
                double upgradeHeroPercentMultiplier = 1.0;

                foreach (UpgradeViewModel uvm in HeroUpgrades.Where(x => x.Owned == true && x.UpgradeFunc == UpgradeFunction.UpgradeHeroPercent))
                    upgradeHeroPercentMultiplier *= 1 + Convert.ToDouble(uvm.UpgradeParam) / 100;

                return upgradeHeroPercentMultiplier;
        }

        #endregion //  Public Methods

        #region Private Helpers


        /// <summary>
        /// Create the upgrades for the hero
        /// </summary>
        private void CreateHeroUpgrades()
        {
            List<UpgradeViewModel> upgrades =
                (from upgrade in _dataManager.GetUpgrades(_hero.ID)
                 select new UpgradeViewModel(_hero, upgrade)).ToList();

            foreach (UpgradeViewModel uvm in upgrades)
                uvm.PropertyChanged += this.OnUpgradeViewModelPropertyChanged;

            this.HeroUpgrades = new ObservableCollection<UpgradeViewModel>(upgrades);
        }

        /// <summary>
        /// Level up the hero depending on what key is being held down.
        /// </summary>
        private void LevelUp()
        {
            if (Keyboard.IsKeyDown(Key.LeftShift))
                this.Level += 10;
            else if (Keyboard.IsKeyDown(Key.Z))
                this.Level += 25;
            else if (Keyboard.IsKeyDown(Key.LeftCtrl))
                this.Level += 100;
            else
                this.Level += 1;
        }

        /// <summary>
        /// Delevel the hero depending on what key is being held down
        /// </summary>
        /// <param name="param"></param>
        private void DeLevelUp(object param)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift))
                this.Level = Level < 10 ? 0 : Level - 10;
            if (Keyboard.IsKeyDown(Key.Z))
                this.Level = Level < 25 ? 0 : Level - 25;
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
                this.Level = Level < 100 ? 0 : Level - 100;
            else
                this.Level = Level < 1 ? 0 : Level - 1;
        }

        #endregion //  Private Helpers

        #region Commands

        public ICommand LevelUpCommand
        {
            get { return new RelayCommand(param => this.LevelUp()); }
        }

        public ICommand DeLevelUpCommand
        {
            get { return new RelayCommand(param => this.DeLevelUp(param)); }
        }

        #endregion //  Commands

        #region Event Handling Methods

        /// <summary>
        /// This method is called when the Owned property is changed in one of
        /// the UpgradeViewModels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnUpgradeViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Owned")
            {
                base.OnPropertyChanged("CurrentDPS");
                base.OnPropertyChanged("CurrentDPSPopup");
                base.OnPropertyChanged("NextLevelDPS");
                base.OnPropertyChanged("LevelMultipliersPopup");
            }
        }

        /// <summary>
        /// Method called when a Ctrl, Shift, or Z is pressed.
        /// </summary>
        public void KeyEvent()
        {
            base.OnPropertyChanged("LevelUpButtonText");
            base.OnPropertyChanged("LevelUpCost");
        }

        #endregion // Event Handling Methods
    }
}
