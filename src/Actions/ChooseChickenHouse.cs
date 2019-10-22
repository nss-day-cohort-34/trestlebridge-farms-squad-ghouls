using System;
using System.Linq;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseChickenHouse
    {
        public static void CollectInput(Farm farm, Chicken chicken)
        {
            Console.Clear();
            if (farm.AvailableChickenHouses.Count() == 0)
            {
                Console.WriteLine("You need to create a Chicken House before you can purchase a chicken.");
            }

            for (int i = 0; i < farm.ChickenHouses.Count; i++)
            {
                if (farm.ChickenHouses[i].GetCount() < farm.ChickenHouses[i].Capacity)
                {
                    Console.WriteLine($"{i + 1}. Chicken House ({farm.ChickenHouses[i].GetCount()} Chickens)");
                }
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            try
            {


                if (farm.AvailableChickenHouses.Count() != 0)
                {
                    Console.WriteLine($"Place the Chicken where?");
                    Console.Write("> ");
                    int choice = Int32.Parse(Console.ReadLine());
                    if (farm.ChickenHouses[choice - 1].GetCount() < farm.ChickenHouses[choice - 1].Capacity)
                    {
                        farm.ChickenHouses[choice - 1].AddResource(chicken);
                        if (farm.ChickenHouses[choice - 1].GetCount() >= farm.ChickenHouses[choice - 1].Capacity)
                        {
                            farm.AvailableChickenHouses.Remove(farm.ChickenHouses[choice - 1]);
                        }
                        Console.WriteLine("Chicken Added To Chicken House");
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