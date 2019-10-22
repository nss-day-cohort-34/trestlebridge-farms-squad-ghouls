using System;
using System.Linq;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseDuckHouse
    {
        public static void CollectInput(Farm farm, Duck duck)
        {
            Console.Clear();
            if (farm.AvailableDuckHouses.Count() == 0)
            {
                Console.WriteLine("You need to create a Duck House before you can purchase a duck.");
            }

            for (int i = 0; i < farm.DuckHouses.Count; i++)
            {
                if (farm.DuckHouses[i].GetCount() < farm.DuckHouses[i].Capacity)
                {
                    Console.WriteLine($"{i + 1}. Duck House ({farm.DuckHouses[i].GetCount()} ducks)");
                }
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            try
            {
                if (farm.AvailableDuckHouses.Count() != 0)
                {
                    Console.WriteLine($"Place the Duck where?");
                    Console.Write("> ");
                    int choice = Int32.Parse(Console.ReadLine());
                    if (farm.DuckHouses[choice - 1].GetCount() < farm.DuckHouses[choice - 1].Capacity)
                    {
                        farm.DuckHouses[choice - 1].AddResource(duck);
                        if (farm.DuckHouses[choice - 1].GetCount() >= farm.DuckHouses[choice - 1].Capacity)
                        {
                            farm.AvailableDuckHouses.Remove(farm.DuckHouses[choice - 1]);
                        }
                        Console.WriteLine("Duck Added To Duck House");
                    }
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine($"Invalid option");
                Console.WriteLine();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Invalid Number");
                Console.WriteLine();
            }




            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}