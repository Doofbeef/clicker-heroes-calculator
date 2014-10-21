using Clicker_Heroes_Calculator.Classes;
using Clicker_Heroes_Calculator.DataAccess;
using Clicker_Heroes_Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Clicker_Heroes_Calculator.ViewModels
{
    public class AllHeroesViewModel
    {
        #region Fields

        /// <summary>
        /// The Data Manager
        /// </summary>
        readonly IDataManager _dataManager;
        /// <summary>
        /// The collection of heroes
        /// </summary>
        public ObservableCollection<HeroViewModel> AllHeroes { get; private set; }

        #endregion //  Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AllHeroesViewModel{T}"/> class.
        /// </summary>
        /// <param name="dataManager">The Data Manager to retrieve the heroes</param>
        public AllHeroesViewModel(IDataManager dataManager)
        {
            if (dataManager == null)
                throw new ArgumentNullException("dataManager");

            _dataManager = dataManager;

            // Populate the AllHeroes collection with HeroViewModels.
            this.CreateAllHeroes();    
        }

        #endregion //  Constructor

        #region Private Helpers

        /// <summary>
        /// Create all the heroes from the Data Manager
        /// </summary>
        private void CreateAllHeroes()
        {
            List<HeroViewModel> all =
                (from hero in _dataManager.GetHeroes()
                 select new HeroViewModel(hero, _dataManager)).ToList();

            this.AllHeroes = new ObservableCollection<HeroViewModel>(all);
        }

        #endregion //  Private Helpers

        #region Event Handling Methods

        /// <summary>
        /// Method called when a Ctrl, Shift, or Z is pressed.
        /// </summary>
        public void KeyEvent()
        {
            foreach (HeroViewModel hvm in AllHeroes)
                hvm.KeyEvent();
        }

        #endregion //  Event Handling Methods
    }
}
