using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class CreateFacility {
        public static void CollectInput (Farm farm) {
            Console.WriteLine ("1. Grazing field");
            Console.WriteLine ("2. Plowed field");
            Console.WriteLine ("3. Chicken House");
            Console.WriteLine ("4. Duck House");


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
                case 3:
                    farm.AddChickenHouse(new ChickenHouse());
                    Console.WriteLine("A New Chicken house Has Been Added");
                    Console.WriteLine();
                    Console.WriteLine($"You Have {farm.ChickenHouses.Count()} Chicken House(s)");
                    break;
                case 4:
                    farm.AddDuckHouse(new DuckHouse());
                    Console.WriteLine("A New Duck house Has Been Added");
                    Console.WriteLine();
                    Console.WriteLine($"You Have {farm.DuckHouses.Count()} Duck House(s)");
                    break;
                default:
                    break;
            }
        }
    }
}