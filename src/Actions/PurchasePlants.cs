using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class PurchasePlants {
        public static void CollectInput (Farm farm) {
            Console.WriteLine ("1. Sesame");
            Console.WriteLine ("2. Sunflower");
            Console.WriteLine ("3. Wildflower");


            Console.WriteLine ();
            Console.WriteLine ("What are you buying today?");

            Console.Write ("> ");
            string choice = Console.ReadLine ();

            switch (choice)
            {
                case "1":
                    ChoosePlowedField.CollectInput(farm, new Sesame());
                    break;
                case "2":
                    ChooseSunflowerField.CollectInput(farm, new Sunflower());

                    break;
                case "3":
                    ChooseNaturalField.CollectInput(farm, new Wildflower());
                    break;
                default:
                   Console.WriteLine($"Invalid option");
                    Console.WriteLine();
                    break;
            }
        }
    }
}