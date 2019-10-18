using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseGrazingField {
        public static void CollectInput (Farm farm, IGrazing animal) {
            Console.Clear();

            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Grazing Field");
            }

            Console.WriteLine ();

            // How can I output the type of animal chosen here?
            Console.WriteLine ($"Place the animal where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());

            bool atCapacity = true;
            
            while (atCapacity == true)
            {
                if (farm.GrazingFields[choice - 1].GetAnimalCount() < farm.GrazingFields[choice - 1].Capacity)
                {
                    atCapacity = false;
                    farm.GrazingFields[choice - 1].AddResource(animal);
                    Console.WriteLine("Animal Added To Facility");
                }
                else
                {
                    atCapacity = true;
                    Console.WriteLine("Too many animals. Choose another facility.");
                    Console.Write ("> ");
                    choice = Int32.Parse(Console.ReadLine ());
                }
            }
            // else return user back to list of facilities (do this after lunch)


            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}