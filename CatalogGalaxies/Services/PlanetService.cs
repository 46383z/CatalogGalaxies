using System;
using System.Collections.Generic;

namespace CatalogGalaxies
{
    public class PlanetService
    {
        
        public static List<Planet> Planets { get; set; } = new List<Planet>();

        public static void AddPlanet(string name, string starName, string type, string habitable)
        {
            if (!StarService.Stars.Exists(s => s.Name.ToUpper() == starName.ToUpper()))
            {
                throw new Exception("Invalid Star Name!!");
            }

            object typeResult = PlanetType.GiantPlanet;
            if (!Enum.TryParse(typeof(PlanetType), type, true, out typeResult))
            {
                throw new Exception("Invalid Planet Type!!");
            }

            bool habitableResult = false;
            if (!Boolean.TryParse(habitable, out habitableResult))
            {
                throw new Exception("Invalid Habitable!!");
            }

            
            Planet planet = new Planet()
            {
                Name = name,
                StarName = starName,
                Type = (PlanetType)Enum.Parse(typeof(PlanetType), type, true),
                Habitable = Convert.ToBoolean(habitable)
            };

            Planets.Add(planet);
        }
    }
}