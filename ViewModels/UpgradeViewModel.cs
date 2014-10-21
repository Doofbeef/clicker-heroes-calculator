using Clicker_Heroes_Calculator.Classes;
using Clicker_Heroes_Calculator.Interfaces;
using Clicker_Heroes_Calculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clicker_Heroes_Calculator.ViewModels
{
    public class UpgradeViewModel : ObservableObject
    {
        #region Fields

        /// <summary>
        /// The Upgrade Model
        /// </summary>
        readonly IUpgrade _upgrade;
        /// <summary>
        /// The Hero Model
        /// </summary>
        readonly IHero _hero;

        #endregion //  Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UpgradeViewModel{T, T}"/> class.
        /// </summary>
        /// <param name="hero">The Hero model</param>
        /// <param name="upgrade">The Upgrade model</param>
        public UpgradeViewModel(IHero hero, IUpgrade upgrade)
        {
            if (hero == null)
                throw new ArgumentNullException("hero");
            if (upgrade == null)
                throw new ArgumentNullException("upgrade");

            _hero = hero;
            _upgrade = upgrade;

            _hero.PropertyChanged += this.OnHeroModelPropertyChanged;
        }

        #endregion //  Constructor

        #region Upgrade Properties

        public string Name
        {
            get { return _upgrade.Name; }
        }

        public string Description
        {
            get { return _upgrade.Description; }
        }

        public int HeroLevelRequired
        {
            get { return _upgrade.HeroLevelRequired; }
        }

        public bool Owned
        {
            get
            {
                return _upgrade.Owned;
            }
            set
            {
                if (value == _upgrade.Owned)
                    return;

                _upgrade.Owned = value;

                base.OnPropertyChanged("Owned");
            }
        }

        public string UpgradeFunc
        {
            get { return _upgrade.UpgradeFunction; }
        }

        public string UpgradeParam
        {
            get
            {
                if (_upgrade.UpgradeParam.Contains(','))
                    return _upgrade.UpgradeParam.Split(',')[1];
                return _upgrade.UpgradeParam;
            }
        }

        #endregion //  Upgrade Properties

        #region Presentation Properties

        #region Upgrade Panel

        /// <summary>
        /// Property that returns if the upgrade can be bought
        /// </summary>
        public bool IsBuyable
        {
            get
            {
                if (_hero.Level < HeroLevelRequired)
                {
                    Owned = false;
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Property returns the image of the upgrade
        /// </summary>
        public string UpgradeIcon
        {
            get { return String.Format(@"\Resources\Images\Icons\{0}.png", _upgrade.IconID); }
        }

        #endregion //  Upgrade Panel

        #region Popup

        /// <summary>
        /// Property return text for the popup that shows the cost of the upgrade
        /// </summary>
        public string PopupCost
        {
            get { return String.Format("Cost {0} Gold", NumberConverter.Convert(_upgrade.Cost)); }
        }

        /// <summary>
        /// Property that return text for the popup that shows the upgrade's effect
        /// </summary>
        public string Effect
        {
            get
            {
                switch (UpgradeFunc)
                {
                    case UpgradeFunction.UpgradeClickDpsPercent:
                        return String.Format("Increases your Click Damage by {0}% of your total DPS.", UpgradeParam);
                    case UpgradeFunction.UpgradeClickPercent:
                        return String.Format("Increases {0}'s Click Damage by {1}%.", _hero.Name, UpgradeParam);
                    case UpgradeFunction.UpgradeCriticalChance:
                        return String.Format("Increases your Critical Chance by {0}%.", UpgradeParam);
                    case UpgradeFunction.UpgradeCriticalDamage:
                        return String.Format("Increases your Critical Click Damage Multiplier by {0}.", UpgradeParam);
                    case UpgradeFunction.UpgradeEveryonePercent:
                        return String.Format("Increases DPS of all heroes by {0}%.", UpgradeParam);
                    case UpgradeFunction.UpgradeGetSkill:
                        return String.Format("Unlocks the '{0}' skill:", Name);
                    case UpgradeFunction.UpgradeGoldFoundPercent:
                        return String.Format("Increases all gold found by {0}%.", UpgradeParam);
                    case UpgradeFunction.UpgradeHeroPercent:
                        return String.Format("Increases {0}'s DPS by {1}%.", _hero.Name, UpgradeParam);
                    default:
                        return "ERROR";
                }
            }
        }

        #endregion //  Popup

        #endregion //  Presentation Properties

        #region Public Methods

        /// <summary>
        /// This method switches the upgrade's owned state on and off
        /// </summary>
        public void Buy()
        {
            Owned = !Owned;
        }

        #endregion //  Public Methods

        #region Commands

        public ICommand BuyCommand
        {
            get { return new RelayCommand(param => this.Buy()); }
        }

        #endregion //  Commands

        #region Event Handling Methods

        void OnHeroModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Level")
            {
                base.OnPropertyChanged("IsBuyable");
            }
        }

        #endregion // Event Handling Methods
    }
}
