using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
    public class ChooseSunflowerField
    {
        public static void CollectInput(Farm farm, ISeedProducing plant)
        {
            Console.Clear();
            if (farm.AvailablePlowedFields.Count() == 0 && farm.AvailableNaturalFields.Count() == 0)
            {
                Console.WriteLine("You need to create a Plowed Field or a Natural Field before you can purchase a sunflower.");
            }

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                if (farm.PlowedFields[i].GetCount() < farm.PlowedFields[i].Capacity)
                {
                    Console.WriteLine($"{i + 1}. Plowed Field ({farm.PlowedFields[i].GetCount()} plants)");
                    farm.PlowedFields[i].GroupPlants();
                }
            }

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                if (farm.NaturalFields[i].GetCount() < farm.NaturalFields[i].Capacity)
                {
                    Console.WriteLine($"{i + 1 + farm.PlowedFields.Count()}. Natural Field ({farm.NaturalFields[i].GetCount()} plants)");
                    farm.NaturalFields[i].GroupPlants();
                }
            }

            Console.WriteLine();


            Console.WriteLine();

            try
            {


                if (farm.AvailableNaturalFields.Count() != 0 || farm.AvailablePlowedFields.Count() != 0)
                {
                    Console.WriteLine($"Place the sunflower where?");
                    Console.Write("> ");
                    int choice = Int32.Parse(Console.ReadLine());


                    if (choice <= farm.PlowedFields.Count())
                    {


                        farm.PlowedFields[choice - 1].AddResource(plant);
                        Console.WriteLine("Sunflower Added To Plowed field");
                        if (farm.PlowedFields[choice - 1].GetCount() >= farm.PlowedFields[choice - 1].Capacity)
                        {
                            farm.AvailablePlowedFields.Remove(farm.PlowedFields[choice - 1]);
                        }
                    }
                    else if (choice > farm.PlowedFields.Count())
                    {
                        farm.NaturalFields[(choice - 1) - farm.PlowedFields.Count()].AddResource(plant);
                        Console.WriteLine("Sunflower Added To Natural field");
                        if (farm.NaturalFields[(choice - 1) - farm.PlowedFields.Count].GetCount() >= farm.NaturalFields[(choice - 1) - farm.PlowedFields.Count].Capacity)
                        {
                            farm.AvailableNaturalFields.Remove(farm.NaturalFields[(choice - 1) - farm.PlowedFields.Count]);
                        }
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

        }




        /*
            Couldn't get this to work. Can you?
            Stretch goal. Only if the app is fully functional.
         */
        // farm.PurchaseResource<IGrazing>(animal, choice);

    }




}
