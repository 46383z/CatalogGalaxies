using System;

namespace CatalogGalaxies
{
    public class OtherService
    {
      
        public static void PrintStats()
        {
            Console.WriteLine("--- Stats ---");
            Console.WriteLine("Galaxies: {0}", GalaxyService.Galaxies.Count);
            Console.WriteLine("Stars: {0}", StarService.Stars.Count);
            Console.WriteLine("Planets: {0}", PlanetService.Planets.Count);
            Console.WriteLine("Moons: {0}", MoonService.Moons.Count);
            Console.WriteLine("--- End of stats ---");
        }

   
        public static void ListGalaxies()
        {
            Console.WriteLine("--- List of all researched galaxies ---");
            foreach(Galaxy galaxy in GalaxyService.Galaxies)
            {
                Console.WriteLine(galaxy.Name);
            }
            Console.WriteLine("--- End of galaxies list ---");
        }
        
       
        public static void PrintGalaxy(string galaxyName)
        {
            Console.WriteLine("--- Data for " + galaxyName + " galaxy ---");
            foreach(Galaxy galaxy in GalaxyService.Galaxies)
            {
               
                Console.WriteLine("Type: {0}", galaxy.Type.ToString());
                Console.WriteLine("Age: {0}{1}", galaxy.Age, galaxy.AgeChar);
                Console.WriteLine("Stars:");
                var stars = StarService.Stars.FindAll(s => s.GalaxyName.ToUpper() == galaxyName.ToUpper());
                foreach(Star star in stars)
                {
                   
                    Console.WriteLine("\tName: {0}", star.Name);
                    Console.WriteLine("\tClass: {0}({1}, {2}, {3}, {4})", star.Class, star.Mass, star.Size, star.Temperature, star.Luminosity);
                    Console.WriteLine("\tPlanets:");
                    var planets = PlanetService.Planets.FindAll(p => p.StarName.ToUpper() == star.Name.ToUpper());
                    foreach (Planet planet in planets)
                    {
                        
                        Console.WriteLine("\t\tName: {0}", planet.Name);
                        Console.WriteLine("\t\tType: {0}", planet.Type);
                        Console.WriteLine("\t\tSupport lift: {0}", planet.Habitable);
                        Console.WriteLine("\t\tMoons:");
                        var moons = MoonService.Moons.FindAll(m => m.PlanetName.ToUpper() == planet.Name.ToUpper());
                        foreach(Moon moon in moons) 
                        {
                           
                            Console.WriteLine("\t\t\tName: {0}", moon.Name);
                        }
                    }
                }
            }
            Console.WriteLine("--- End of data for " + galaxyName  + " galaxy ---");
        }
    }
}
