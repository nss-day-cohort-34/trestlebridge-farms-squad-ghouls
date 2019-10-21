using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities {
    public class PlowedField : IFacility<ISeedProducing>, IField
    {
        private int _capacity = 65;
        private Guid _id = Guid.NewGuid();

        private List<ISeedProducing> _plants = new List<ISeedProducing>();
        private List<IResource> _resources = new List<IResource>();
        private int _plantsPerRow = 5;
        private int _rows = 13;

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
            foreach (ISeedProducing plant in _plants)
            {
                plants.Add((IResource)plant);
            }
            var groupedPlants = plants.GroupBy(p => p.Type).Select(p => new { type = p.Key, number = p.Count() }).ToList();
            foreach (var plant in groupedPlants)
            {
                Console.WriteLine($"  {plant.type} Count: {plant.number}");
            }
        }

        public void AddResource (ISeedProducing plant)
        {
            _plants.Add(plant);
        }

        public void AddResource (List<ISeedProducing> plants)
        {
            foreach (ISeedProducing plant in plants)
            {
                _plants.Add(plant);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Plowed Field {shortId} has {this._plants.Count} plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }


        public int GetCount()
        {
            return _plants.Count();
        }


    }
}