using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Facilities
{
    public class DuckHouse : IFacility<Duck>
    {
        private double _capacity = 2;
        private Guid _id = Guid.NewGuid();
          public double Capacity {
            get {
                return _capacity;
            }
        }

        private List<Duck> _ducks = new List<Duck>();
        public int GetDuckCount()
        {
            return _ducks.Count();
        }
        public void AddResource(Duck duck)
        {
            _ducks.Add(duck);
        }

        public void AddResource(List<Duck> ducks)
        {
             foreach (Duck duck in ducks)
            {
                _ducks.Add(duck);
            }
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Duck House {shortId} has {this._ducks.Count} animals\n");
            this._ducks.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}