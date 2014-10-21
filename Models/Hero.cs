using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clicker_Heroes_Calculator.Interfaces;
using Clicker_Heroes_Calculator.Classes;

namespace Clicker_Heroes_Calculator.Models
{
    public class Hero : ObservableObject, IHero
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

        private double _baseCost;
        public double BaseCost
        {
            get { return _baseCost; }
            set
            {
                if (value != _baseCost)
                {
                    _baseCost = value;
                    OnPropertyChanged("BaseCost");
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

        private int _level;
        public int Level
        {
            get { return _level; }
            set
            {
                if (value != _level)
                {
                    _level = value;
                    OnPropertyChanged("Level");
                }
            }
        }
    }
}
