using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class ProcessResource {
        public static void CollectInput (Farm farm) {
            Console.WriteLine ("1.Meat Processor ");



            Console.WriteLine ();
            Console.WriteLine ("Choose Equipment to use.");

            Console.Write ("> ");
            string choice = Console.ReadLine ();

            switch (choice)
            {
                case "1":
                    ChooseMeatProcessor.CollectInput(farm);
                    break;


                default:
                   Console.WriteLine($"Invalid option");
                    Console.WriteLine();
                    break;
            }
        }
    }
}