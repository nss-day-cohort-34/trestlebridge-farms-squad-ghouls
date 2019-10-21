using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
     public class ChooseSunflowerField
    {
        public static void CollectInput (Farm farm, ISeedProducing plant) {
            Console.Clear();
            if (farm.AvailableSunflowerFields.Count() == 0) {
                Console.WriteLine("You need to create a Plowed Field or a Natural Field before you can purchase a sunflower.");
            }

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                if (farm.PlowedFields[i].GetCount() < farm.PlowedFields[i].Capacity) {
                    Console.WriteLine ($"{i + 1}. Plowed Field ({farm.PlowedFields[i].GetCount()} plants)");
                    farm.PlowedFields[i].GroupPlants();
                }
            }

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                if (farm.NaturalFields[i].GetCount() < farm.NaturalFields[i].Capacity) {
                    Console.WriteLine ($"{i + 1 + farm.PlowedFields.Count()}. Natural Field ({farm.NaturalFields[i].GetCount()} plants)");
                    farm.NaturalFields[i].GroupPlants();
                }
            }

            Console.WriteLine ();


 Console.WriteLine ();


            if (farm.AvailableSunflowerFields.Count() != 0) {
                Console.WriteLine ($"Place the sunflower where?");
                Console.Write ("> ");
                int choice = Int32.Parse(Console.ReadLine ());
                    if (farm.SunflowerFields[choice - 1].GetCount() < farm.SunflowerFields[choice - 1].Capacity)
                    {
                        farm.SunflowerFields[choice - 1].AddResource(plant);
                        if (farm.SunflowerFields[choice - 1].GetCount() >= farm.SunflowerFields[choice -1].Capacity) {
                            farm.AvailableSunflowerFields.Remove(farm.SunflowerFields[choice - 1]);
                        }
                        Console.WriteLine($"Sunflower Added To {farm.SunflowerFields[choice - 1].GetType().ToString().Split(".")[3].Replace("Field", " Field")} ");
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