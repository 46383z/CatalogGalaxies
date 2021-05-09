using System;
using System.Collections.Generic;

namespace CatalogGalaxies
{
    public class MoonService
    {
       
        public static List<Moon> Moons { get; set; } = new List<Moon>();

        
        public static void AddMoon(string name, string planetName)
        {
            if (!PlanetService.Planets.Exists(p => p.Name.ToUpper() == planetName.ToUpper()))
            {
                throw new Exception("Invalid Planet Name!!");
            }
           
            Moon Moon = new Moon()
            {
                Name = name,
                PlanetName = planetName,
            };

            Moons.Add(Moon);
        }
    }
}
