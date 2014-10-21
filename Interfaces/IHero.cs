using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clicker_Heroes_Calculator.Classes;
using System.Windows.Controls;
using System.ComponentModel;

namespace Clicker_Heroes_Calculator.Interfaces
{
    public interface IHero : INotifyPropertyChanged
    {
        int ID { get; set; }
        string Name { get; set; }
        double BaseCost { get; set; }
        string Description { get; set; }
        int Level { get; set; }
    }
}
