using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
    public class ChooseMeatProcessor
    {
        public static void CollectInput(Farm farm)
        {
            Console.Clear();
            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                if (farm.GrazingFields[i].GetCount() < farm.GrazingFields[i].Capacity)
                {
                    Console.WriteLine($"{i + 1}. Grazing Field ({farm.GrazingFields[i].GetCount()} animals)");

                }
                Console.WriteLine();

            }
            if (farm.GrazingFields.Count() != 0)
            {
                try
                {
                    Console.WriteLine($"Which Facility has the animals you want to process?");
                    Console.Write("> ");
                    string choice = Console.ReadLine();
                    while (choice != "")
                    {
                        if (int.Parse(choice) <= farm.GrazingFields.Count())
                        {
                            Console.Clear();
                            farm.GrazingFields[int.Parse(choice) - 1].GetAnimals(farm.GrazingFields[int.Parse(choice) - 1]);

                        }
                        
                        Console.Clear();
                        for (int i = 0; i < farm.GrazingFields.Count; i++)
                        {
                            if (farm.GrazingFields[i].GetCount() < farm.GrazingFields[i].Capacity)
                            {
                                Console.WriteLine($"{i + 1}. Grazing Field ({farm.GrazingFields[i].GetCount()} animals)");

                            }
                            Console.WriteLine();

                        }
                        Console.WriteLine($"Which Facility has the animals you want to process?");
                        Console.Write("> ");
                        choice = Console.ReadLine();
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}