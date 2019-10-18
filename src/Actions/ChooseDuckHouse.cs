using System;
using System.Linq;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    internal class ChooseDuckHouse
    {
        public static void CollectInput (Farm farm, Duck duck) {
            Console.Clear();
            if (farm.AvailableDuckHouses.Count() == 0) {
                Console.WriteLine("You need to create a Duck House before you can purchase a duck.");
            }

            for (int i = 0; i < farm.DuckHouses.Count; i++)
            {
                if (farm.DuckHouses[i].GetDuckCount() < farm.DuckHouses[i].Capacity) {
                    Console.WriteLine ($"{i + 1}. Duck House ({farm.DuckHouses[i].GetDuckCount()} ducks)");
                }
            }

            Console.WriteLine ();

            // How can I output the type of animal chosen here?

            if (farm.DuckHouses.Count() != 0) {
                Console.WriteLine ($"Place the Duck where?");
                Console.Write ("> ");
                int choice = Int32.Parse(Console.ReadLine ());
                bool atCapacity = true;
                while (atCapacity == true)
                {
                    if (farm.DuckHouses[choice - 1].GetDuckCount() < farm.DuckHouses[choice - 1].Capacity)
                    {
                        atCapacity = false;
                        farm.DuckHouses[choice - 1].AddResource(duck);
                        if (farm.DuckHouses[choice - 1].GetDuckCount() >= farm.DuckHouses[choice -1].Capacity) {
                            farm.AvailableDuckHouses.Remove(farm.DuckHouses[choice - 1]);
                        }
                        Console.WriteLine("Duck Added To Facility");
                    } else {
                        atCapacity = true;
                        Console.WriteLine("Too many Ducks. Choose another facility.");
                        Console.Write ("> ");
                        choice = Int32.Parse(Console.ReadLine ());
                    }
                }
        }




            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}