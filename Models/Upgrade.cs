using Clicker_Heroes_Calculator.Classes;
using Clicker_Heroes_Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker_Heroes_Calculator.Models
{
    public class Upgrade : ObservableObject, IUpgrade
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private int _heroLevelRequired;
        public int HeroLevelRequired
        {
            get { return _heroLevelRequired; }
            set
            {
                if (value != _heroLevelRequired)
                {
                    _heroLevelRequired = value;
                    OnPropertyChanged("HeroLevelRequired");
                }
            }
        }

        private bool _owned;
        public bool Owned
        {
            get { return _owned; }
            set
            {
                if (value != _owned)
                {
                    _owned = value;
                    OnPropertyChanged("Owned");
                }
            }
        }

        private double _cost;
        public double Cost
        {
            get { return _cost; }
            set
            {
                if (value != _cost)
                {
                    _cost = value;
                    OnPropertyChanged("Cost");
                }
            }
        }

        private string _upgradeFunction;
        public string UpgradeFunction
        {
            get { return _upgradeFunction; }
            set
            {
                if (value != _upgradeFunction)
                {
                    _upgradeFunction = value;
                    OnPropertyChanged("UpgradeFunction");
                }
            }
        }

        private string _upgradeParam;
        public string UpgradeParam
        {
            get { return _upgradeParam; }
            set
            {
                if (value != _upgradeParam)
                {
                    _upgradeParam = value;
                    OnPropertyChanged("UpgradeParam");
                }
            }
        }

        private int _iconId;
        public int IconID
        {
            get { return _iconId; }
            set
            {
                if (value != _iconId)
                {
                    _iconId = value;
                    OnPropertyChanged("IconID");
                }
            }
        }

        private int _heroId;
        public int HeroID
        {
            get { return _heroId; }
            set
            {
                if (value != _heroId)
                {
                    _heroId = value;
                    OnPropertyChanged("HeroID");
                }
            }
        }
    }
}
