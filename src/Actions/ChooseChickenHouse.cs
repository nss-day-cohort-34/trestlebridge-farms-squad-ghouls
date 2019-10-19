using System;
using System.Linq;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    internal class ChooseChickenHouse
    {
        public static void CollectInput (Farm farm, Chicken chicken) {
            Console.Clear();
            if (farm.AvailableChickenHouses.Count() == 0) {
                Console.WriteLine("You need to create a Chicken House before you can purchase a chicken.");
            }

            for (int i = 0; i < farm.ChickenHouses.Count; i++)
            {
                if (farm.ChickenHouses[i].GetChickenCount() < farm.ChickenHouses[i].Capacity) {
                    Console.WriteLine ($"{i + 1}. Chicken House ({farm.ChickenHouses[i].GetChickenCount()} Chickens)");
                }
            }

            Console.WriteLine ();

            // How can I output the type of animal chosen here?

            if (farm.AvailableChickenHouses.Count() != 0) {
                Console.WriteLine ($"Place the Chicken where?");
                Console.Write ("> ");
                int choice = Int32.Parse(Console.ReadLine ());
                    if (farm.ChickenHouses[choice - 1].GetChickenCount() < farm.ChickenHouses[choice - 1].Capacity)
                    {
                        farm.ChickenHouses[choice - 1].AddResource(chicken);
                        if (farm.ChickenHouses[choice - 1].GetChickenCount() >= farm.ChickenHouses[choice -1].Capacity) {
                            farm.AvailableChickenHouses.Remove(farm.ChickenHouses[choice - 1]);
                        }
                        Console.WriteLine("Chicken Added To Facility");
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