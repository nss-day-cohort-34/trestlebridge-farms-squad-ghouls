using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
     public class ChoosePlowedField
    {
        public static void CollectInput (Farm farm, ISeedProducing plant) {
            Console.Clear();
            if (farm.AvailablePlowedFields.Count() == 0) {
                Console.WriteLine("You need to create a Plowed Field before you can purchase a plant.");
            }

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                if (farm.PlowedFields[i].GetCount() < farm.PlowedFields[i].Capacity) {
                    Console.WriteLine ($"{i + 1}. Plowed Field ({farm.PlowedFields[i].GetCount()} plants)");
                    farm.PlowedFields[i].GroupPlants();
                }
            }

            Console.WriteLine ();

            // How can I output the type of animal chosen here?

            if (farm.AvailablePlowedFields.Count() != 0) {
                Console.WriteLine ($"Place the plant where?");
                Console.Write ("> ");
                int choice = Int32.Parse(Console.ReadLine ());
                    if (farm.PlowedFields[choice - 1].GetCount() < farm.PlowedFields[choice - 1].Capacity)
                    {
                        farm.PlowedFields[choice - 1].AddResource(plant);
                        if (farm.PlowedFields[choice - 1].GetCount() >= farm.PlowedFields[choice -1].Capacity) {
                            farm.AvailablePlowedFields.Remove(farm.PlowedFields[choice - 1]);
                        }
                        Console.WriteLine("Plant Added To Facility");
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