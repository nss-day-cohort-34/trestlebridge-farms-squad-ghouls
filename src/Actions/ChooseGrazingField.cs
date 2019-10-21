using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
     internal class ChooseGrazingField
    {
        public static void CollectInput (Farm farm, IGrazing animal) {
            Console.Clear();
            if (farm.AvailableGrazingFields.Count() == 0) {
                Console.WriteLine("You need to create a Grazing Field before you can purchase an animal.");
            }

            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                if (farm.GrazingFields[i].GetAnimalCount() < farm.GrazingFields[i].Capacity) {
                    Console.WriteLine ($"{i + 1}. Grazing Field ({farm.GrazingFields[i].GetAnimalCount()} animals)");
                    farm.GrazingFields[i].GroupAnimals();
                }
            }

            Console.WriteLine ();

            // How can I output the type of animal chosen here?

            if (farm.AvailableGrazingFields.Count() != 0) {
                Console.WriteLine ($"Place the animal where?");
                Console.Write ("> ");
                int choice = Int32.Parse(Console.ReadLine ());
                    if (farm.GrazingFields[choice - 1].GetAnimalCount() < farm.GrazingFields[choice - 1].Capacity)
                    {
                        farm.GrazingFields[choice - 1].AddResource(animal);
                        if (farm.GrazingFields[choice - 1].GetAnimalCount() >= farm.GrazingFields[choice -1].Capacity) {
                            farm.AvailableGrazingFields.Remove(farm.GrazingFields[choice - 1]);
                        }
                        Console.WriteLine("Animal Added To Facility");
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