using System; 
using System.Collections.Generic;
using System.Globalization;

namespace CatalogGalaxies
{
    public class GalaxyService
    {
        
        public static List<Galaxy> Galaxies { get; set; } = new List<Galaxy>();

        
        public static void AddGalaxy(string name, string type, string age)
        {
            object typeResult = GalaxyType.Elliptical;
            if (!Enum.TryParse(typeof(GalaxyType), type, true, out typeResult))
            {
                throw new Exception("Invalid Galaxy Type!!");
            }

            double ageResult = 0;
            if (!(double.TryParse(age.Substring(0, age.Length - 2), out ageResult) && (age.ToUpper()[age.Length - 1] == 'M' || age.ToUpper()[age.Length - 1] ==  'B')))
            {
                throw new Exception("Invalid Age!!");
            }

            
            Galaxy galaxy = new Galaxy()
            {
                Name = name,
                Age = Convert.ToDouble(age.Substring(0, age.Length - 1), CultureInfo.InvariantCulture),
                AgeChar = age.ToUpper()[age.Length - 1],
                Type = (GalaxyType)Enum.Parse(typeof(GalaxyType), type, true)
            };

            Galaxies.Add(galaxy);
        }
    }
}
