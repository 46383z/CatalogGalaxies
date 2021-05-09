using System;
using System.Collections.Generic;

namespace CatalogGalaxies
{
    public class StarService
    {
      
        public static List<Star> Stars { get; set; } = new List<Star>();

        public static void AddStar(string name, string galaxyName, string mass, string size, string temperature, string luminosity)
        {
            if (!GalaxyService.Galaxies.Exists(g => g.Name.ToUpper() == galaxyName.ToUpper()))
            {
                throw new Exception("Invalid Galaxy Name!!");
            }

            double result = 0;
            if (!double.TryParse(mass, out result))
            {
                throw new Exception("Invalid Mass!!");
            }

            if (!double.TryParse(size, out result))
            {
                throw new Exception("Invalid Size!!");
            }

            int tempResult = 0;
            if (!int.TryParse(temperature, out tempResult))
            {
                throw new Exception("Invalid Temperature!!");
            }

            if (!double.TryParse(luminosity, out result))
            {
                throw new Exception("Invalid Luminosity!!");
            }

            
            StarClass starClass = GetStarClass(Convert.ToDouble(mass), Convert.ToDouble(size), Convert.ToInt32(temperature), Convert.ToDouble(luminosity));

           
            Star star = new Star()
            {
                Name = name,
                GalaxyName = galaxyName,
                Class = starClass,
                Mass = Convert.ToDouble(mass),
                Size = Convert.ToDouble(size),
                Temperature = Convert.ToInt32(temperature),
                Luminosity = Convert.ToDouble(luminosity),
            };

            Stars.Add(star);
        }

        
        private static StarClass GetStarClass(double mass, double size, int temperature, double luminosity)
        {
            StarClass starClass = StarClass.A;

            if (temperature >= 30000 && luminosity >= 30000 && mass >= 16 && size >= 6.6)
            {
                starClass = StarClass.O;
            }
            else if ((temperature >= 10000 && temperature <= 30000) && (luminosity >= 25 && luminosity <= 30000) && (mass >= 2.1 && mass <= 16) && (size >= 1.8 && size <= 6.6))
            {
                starClass = StarClass.B;
            }
            else if ((temperature >= 7500 && temperature <= 10000) && (luminosity >= 5 && luminosity <= 25) && (mass >= 1.4 && mass <= 2.1) && (size >= 1.4 && size <= 1.8))
            {
                starClass = StarClass.A;
            }
            else if ((temperature >= 6000 && temperature <= 7500) && (luminosity >= 1.5 && luminosity <= 5) && (mass >= 1.04 && mass <= 1.4) && (size >= 1.15 && size <= 1.4))
            {
                starClass = StarClass.F;
            }
            else if ((temperature >= 5200 && temperature <= 6000) && (luminosity >= 0.6 && luminosity <= 1.5) && (mass >= 0.8 && mass <= 1.04) && (size >= 0.96 && size <= 1.15))
            {
                starClass = StarClass.G;
            }
            else if ((temperature >= 3700 && temperature <= 5200) && (luminosity >= 0.08 && luminosity <= 0.6) && (mass >= 0.45 && mass <= 0.8) && (size >= 0.7 && size <= 0.96))
            {
                starClass = StarClass.K;
            }
            else if ((temperature >= 2400 && temperature <= 3700) && luminosity <= 0.08 && (mass >= 0.08 && mass <= 0.45) && size <= 0.7)
            {
                starClass = StarClass.M;
            }

            return starClass;
        }
    }
}
