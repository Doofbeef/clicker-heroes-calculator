using Clicker_Heroes_Calculator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker_Heroes_Calculator.Interfaces
{
    public interface IDataManager
    {
        IList<IHero> GetHeroes();
        IList<IUpgrade> GetUpgrades(int id);
    }
}
