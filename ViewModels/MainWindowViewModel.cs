using Clicker_Heroes_Calculator.Classes;
using Clicker_Heroes_Calculator.DataAccess;
using Clicker_Heroes_Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Clicker_Heroes_Calculator.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Fields

        /// <summary>
        /// The Data Manager
        /// </summary>
        readonly IDataManager _dataManager;
        /// <summary>
        /// The viewmodel that holds all the heroes
        /// </summary>
        private AllHeroesViewModel _heroes;

        #endregion //  Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            _dataManager = new DataManager();
        }

        #endregion //  Constructor

        #region MainWindow Properties

        public AllHeroesViewModel Heroes
        {
            get
            {
                if (_heroes == null)
                {
                    _heroes = new AllHeroesViewModel(_dataManager);
                }
                return _heroes;
            }
        }

        #endregion //  MainWindow Properties

        #region Commands

        public ICommand KeyDownCommand
        {
            get { return new RelayCommand(param => this.KeyEvent()); }
        }

        public ICommand KeyUpCommand
        {
            get { return new RelayCommand(param => this.KeyEvent()); }
        }

        #endregion //  Commands

        #region Event Handling Methods

        /// <summary>
        /// Method called when a Ctrl, Shift, or Z is pressed.
        /// </summary>
        private void KeyEvent()
        {
            Heroes.KeyEvent();
        }

        #endregion //  Event Handling Methods
    }
}
