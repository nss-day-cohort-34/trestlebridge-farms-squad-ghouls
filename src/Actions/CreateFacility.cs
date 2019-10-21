using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class CreateFacility {
        public static void CollectInput (Farm farm) {
            Console.WriteLine ("1. Grazing field");
            Console.WriteLine ("2. Chicken House");
            Console.WriteLine ("3. Duck House");
            Console.WriteLine ("4. Plowed field");
            Console.WriteLine ("5. Natural field");


            Console.WriteLine ();
            Console.WriteLine ("Choose what you want to create");

            Console.Write ("> ");
            string input = Console.ReadLine ();

            switch (Int32.Parse(input))
            {
                case 1:
                    farm.AddGrazingField(new GrazingField());
                    Console.WriteLine("A New Grazing Field Has Been Added");
                    Console.WriteLine();
                    Console.WriteLine($"You Have {farm.GrazingFields.Count()} Grazing Field(s)");
                    break;
                case 2:
                    farm.AddChickenHouse(new ChickenHouse());
                    Console.WriteLine("A New Chicken house Has Been Added");
                    Console.WriteLine();
                    Console.WriteLine($"You Have {farm.ChickenHouses.Count()} Chicken House(s)");
                    break;
                case 3:
                    farm.AddDuckHouse(new DuckHouse());

                    Console.WriteLine("A New Duck house Has Been Added");
                    Console.WriteLine();
                    Console.WriteLine($"You Have {farm.DuckHouses.Count()} Duck House(s)");
                    break;
                case 4:
                    farm.AddPlowedField(new PlowedField());
                    Console.WriteLine("A New Plowed Field Has Been Added");
                    Console.WriteLine();
                    Console.WriteLine($"You Have {farm.PlowedFields.Count()} Plowed Field(s)");
                    break;
                case 5:
                    farm.AddNaturalField(new NaturalField());
                    Console.WriteLine("A New Natural Field Has Been Added");
                    Console.WriteLine();
                    Console.WriteLine($"You Have {farm.NaturalFields.Count()} Natural Field(s)");
                    break;
                default:
                    break;
            }
        }
    }
}