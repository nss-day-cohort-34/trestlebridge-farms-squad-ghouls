using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities {
    public class GrazingField : IFacility<IGrazing>
    {
        private int _capacity = 20;
        private Guid _id = Guid.NewGuid();

        private List<IGrazing> _animals = new List<IGrazing>();
        private List<IResource> _resources = new List<IResource>();

        public double Capacity {
            get {
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

        public void AddResource (IGrazing animal)
        {
            _animals.Add(animal);
        }

        public void AddResource (List<IGrazing> animals)
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