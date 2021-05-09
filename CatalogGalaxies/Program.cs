using System;
using System.Globalization;


namespace CatalogGalaxies
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string input = "";
             
           
            do
            {
                Console.Write("Input: ");
                input = Console.ReadLine();

                try
                {
                    if (input.ToLower().Contains("add galaxy"))
                    {
                        string name = input.Split('[')[1].Split(']')[0];
                        string type = input.Split(']')[1].Trim().Split(' ')[0];
                        string age = input.Split(']')[1].Trim().Split(' ')[1];
                        GalaxyService.AddGalaxy(name, type, age);
                    }
                    else if (input.ToLower().Contains("add star"))
                    {
                        
                        string name = input.Split('[')[2].Split(']')[0];
                        string galaxyName = input.Split('[')[1].Split(']')[0];
                        string mass = input.Split(']')[2].Trim().Split(' ')[0];
                        string size = input.Split(']')[2].Trim().Split(' ')[1];
                        string temperature = input.Split(']')[2].Trim().Split(' ')[2];
                        string luminosity = input.Split(']')[2].Trim().Split(' ')[3];
                        StarService.AddStar(name, galaxyName, mass, size, temperature, luminosity);
                    }
                    else if (input.ToLower().Contains("add planet"))
                    {
                        
                        string name = input.Split('[')[2].Split(']')[0];
                        string starName = input.Split('[')[1].Split(']')[0];
                        string type = input.Split(']')[2].Trim().Split(' ')[0];
                        string habitable = input.Split(']')[2].Trim().Split(' ')[1].ToLower() == "yes" ? "true" : "false";
                        PlanetService.AddPlanet(name, starName, type, habitable);
                    }
                    else if (input.ToLower().Contains("add moon"))
                    {
                      
                        string name = input.Split('[')[2].Split(']')[0];
                        string planetName = input.Split('[')[1].Split(']')[0];
                        MoonService.AddMoon(name, planetName);
                    }
                    else if (input.ToLower().Contains("stats"))
                    {
                        OtherService.PrintStats();
                    }
                    else if (input.ToLower().Contains("list galaxies"))
                    {
                        OtherService.ListGalaxies();
                    }
                    else if (input.ToLower().Contains("print"))
                    {
                        
                        string galaxyName = input.Split('[')[1].Split(']')[0];
                        OtherService.PrintGalaxy(galaxyName);
                    }
                    else if (input.ToLower() != "exit")
                    {
                        Console.WriteLine("Invalid input!!");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (input.ToLower() != "exit");
        }
    }
}


