using System;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    internal class ChooseDuckHouse
    {
        public static void CollectInput (Farm farm, Duck duck) {
            Console.Clear();

            for (int i = 0; i < farm.DuckHouses.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Duck House");
            }

            Console.WriteLine ();

            // How can I output the type of animal chosen here?
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
                    Console.WriteLine("Duck Added To Facility");
                }
                else
                {
                    atCapacity = true;
                    Console.WriteLine("Too many Ducks. Choose another facility.");
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