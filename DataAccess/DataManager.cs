using Clicker_Heroes_Calculator.Interfaces;
using Clicker_Heroes_Calculator.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Resources;
using System.Xml;
using System.Xml.Linq;

namespace Clicker_Heroes_Calculator.DataAccess
{
    /// <summary>
    /// Represents a source of the data for the Clicker Heroes game in the application
    /// </summary>
    public class DataManager : IDataManager
    {
        #region Fields

        /// <summary>
        /// Relative path to Clicker Heroes' raw data file
        /// </summary>
        static string heroDataFile = "Data/raw_data_json_from_clicker_heroes.js";
        /// <summary>
        /// List of heroes
        /// </summary>
        readonly IList<Hero> _heroes;
        /// <summary>
        /// List of upgrades
        /// </summary>
        readonly IList<Upgrade> _upgrades;

        #endregion //  Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DataManager"/> class.
        /// </summary>
        public DataManager()
        {
            using (Stream stream = GetResourceStream(heroDataFile))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

                    _heroes = LoadHeroes(o);
                    _upgrades = LoadUpgrades(o);

                    o = null;
                }
            }
        }

        #endregion //  Constructor

        #region Public Methods

        /// <summary>
        /// Return a list of the heroes
        /// </summary>
        /// <returns>List of heroes</returns>
        public IList<IHero> GetHeroes()
        {
            return new List<IHero>(_heroes);
        }

        /// <summary>
        /// Return a list of a hero's upgrades
        /// </summary>
        /// <param name="id">ID of the hero</param>
        /// <returns>List of hero's upgrades</returns>
        public IList<IUpgrade> GetUpgrades(int id)
        {
            return new List<IUpgrade>(_upgrades.Where(x => x.HeroID == id).OrderBy(x => x.HeroLevelRequired).ToList());
        }

        #endregion //  Public Methods

        #region Private Helpers

        /// <summary>
        /// Returns a list of heroes from the raw data
        /// </summary>
        /// <param name="o">Clicker Heroes' raw data as a JObject</param>
        /// <returns>List of heroes</returns>
        static IList<Hero> LoadHeroes(JObject o)
        {
            return (from hero in o["heroes"].Children().Children()
                    select new Hero
                    {
                        ID = hero.Value<int>("id"),
                        Name = hero.Value<string>("name"),
                        BaseCost = (double)hero["baseCost"],
                        Description = hero.Value<string>("description").Replace(@"\", String.Empty)
                    }).ToList();
        }

        /// <summary>
        /// Returns a list of upgrades from the raw data
        /// </summary>
        /// <param name="o">Clicker Heroes' raw data as a JObject</param>
        /// <returns>List of upgrades</returns>
        static IList<Upgrade> LoadUpgrades(JObject o)
        {
            return (from upgrade in o["upgrades"].Children().Children()
                    select new Upgrade
                    {
                        ID = upgrade.Value<int>("id"),
                        Name = upgrade.Value<string>("name"),
                        HeroID = upgrade.Value<int>("heroId"),
                        HeroLevelRequired = upgrade.Value<int>("heroLevelRequired"),
                        IconID = upgrade.Value<int>("iconId"),
                        UpgradeFunction = upgrade.Value<string>("upgradeFunction"),
                        UpgradeParam = upgrade.Value<string>("upgradeParams"),
                        Cost = (double)upgrade["cost"],
                        Description = upgrade.Value<string>("description").Replace(@"\", String.Empty)
                    }).ToList();
        }

        static Stream GetResourceStream(string resourceFile)
        {
            Uri uri = new Uri(resourceFile, UriKind.RelativeOrAbsolute);

            StreamResourceInfo info = Application.GetResourceStream(uri);
            if (info == null || info.Stream == null)
                throw new ApplicationException("Missing resource file: " + resourceFile);

            return info.Stream;
        }

        #endregion //  Private Helpers
    }
}
