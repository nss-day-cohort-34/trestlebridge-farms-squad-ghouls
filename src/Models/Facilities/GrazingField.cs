using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities
{
    public class GrazingField : IFacility<IGrazing>
    {
        private int _capacity = 20;
        private Guid _id = Guid.NewGuid();

        private List<IGrazing> _animals = new List<IGrazing>();
        private List<IResource> _resources = new List<IResource>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public int GetCount()
        {
            return _animals.Count();
        }

        public void GroupAnimals()
        {
            List<IResource> animals = new List<IResource>();
            foreach (IGrazing animal in _animals)
            {
                animals.Add((IResource)animal);
            }
            var groupedAnimals = animals.GroupBy(a => a.Type).Select(a => new { type = a.Key, number = a.Count() }).ToList();
            foreach (var animal in groupedAnimals)
            {
                Console.WriteLine($"  {animal.type} Count: {animal.number}");
            }
        }
        public void GetAnimals(GrazingField grazingField)
        {
            List<IResource> animals = new List<IResource>();
            foreach (IGrazing animal in _animals)
            {
                animals.Add((IResource)animal);
            }
            var groupedAnimals = animals.GroupBy(a => a.Type).Select(a => new { type = a.Key, number = a.Count() }).ToList();
            int counter = 0;
            foreach (var animal in groupedAnimals)
            {
                counter++;
                Console.WriteLine($"{counter}. {animal.type} Count: {animal.number}");
            }
            Console.WriteLine("Which resource should we process?");
           string choice = Console.ReadLine();
           if (int.Parse(choice) <= groupedAnimals.Count()){
               Console.WriteLine($"How many cows should be processed?");
              string quantity = Console.ReadLine();
              if (int.Parse(quantity) <= groupedAnimals[int.Parse(choice) -1].number){
                  for(int i= 0; i < int.Parse(quantity); i++ ){
                     _animals.Remove(_animals[0]);
                  }

              }

           }
        }

        public void AddResource(IGrazing animal)
        {
            _animals.Add(animal);
        }

        public void AddResource(List<IGrazing> animals)
        {
            foreach (IGrazing animal in animals)
            {
                _animals.Add(animal);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Grazing field {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}