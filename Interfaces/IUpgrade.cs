using Clicker_Heroes_Calculator.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker_Heroes_Calculator.Interfaces
{
    public interface IUpgrade : INotifyPropertyChanged
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int HeroLevelRequired { get; set; }
        bool Owned { get; set; }
        double Cost { get; set; }
        string UpgradeFunction { get; set; }
        string UpgradeParam { get; set; }
        int IconID { get; set; }
        int HeroID { get; set; }
    }
}
