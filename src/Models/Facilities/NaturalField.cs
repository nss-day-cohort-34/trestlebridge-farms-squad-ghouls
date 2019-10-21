using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities {
    public class NaturalField : IFacility<ICompostProducing>, IField, IFacility<ISeedProducing>
    {
        private int _capacity = 60;
        private Guid _id = Guid.NewGuid();

        private List<ICompostProducing> _plants = new List<ICompostProducing>();
        private List<IResource> _resources = new List<IResource>();
        private int _plantsPerRow = 6;
        private int _rows = 10;

        public double Capacity {
            get {
                return _capacity;
            }
        }

         public int PlantsInRow {
            get {
                return _plantsPerRow;
            }
        }

        public int Rows {
            get {
                return _rows;
            }
        }


        public void GroupPlants()
        {
            List<IResource> plants = new List<IResource>();
            foreach (ICompostProducing plant in _resources)
            {
                plants.Add((IResource)plant);
            }
            var groupedPlants = plants.GroupBy(p => p.Type).Select(p => new { type = p.Key, number = p.Count() }).ToList();
            foreach (var plant in groupedPlants)
            {
                Console.WriteLine($"  {plant.type} Count: {plant.number}");
            }
        }

        public void AddResource (IResource plant)
        {
            _resources.Add(plant);
        }

        public void AddResource (List<IResource> plants)
        {
            foreach (IResource plant in plants)
            {
                _resources.Add(plant);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Natural Field {shortId} has {this._plants.Count} plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }



        public int GetCount()
        {
            return _resources.Count();
        }

        public void AddResource(ISeedProducing resource)
        {
           _resources.Add((IResource)resource);
        }

        public void AddResource(List<ISeedProducing> resources)
        {
             foreach (IResource plant in resources)
            {
                _resources.Add(plant);
            }
        }

        public void AddResource(ICompostProducing resource)
        {
            _resources.Add((IResource)resource);
        }

        public void AddResource(List<ICompostProducing> resources)
        {
             foreach (IResource plant in resources)
            {
                _resources.Add(plant);
            }
        }
    }
}