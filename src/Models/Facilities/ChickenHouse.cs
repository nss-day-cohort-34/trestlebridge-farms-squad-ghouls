using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Facilities {
    public class ChickenHouse : IFacility<Chicken>
    {

        private double _capacity = 15;
        private Guid _id = Guid.NewGuid();
          public double Capacity {
            get {
                return _capacity;
            }
        }

           public int GetChickenCount()
        {
            return _chickens.Count();
        }

         private List<Chicken> _chickens = new List<Chicken>();

        public void AddResource(Chicken chicken)
        {
            _chickens.Add(chicken);
        }

        public void AddResource(List<Chicken> chickens)
        {
             foreach (Chicken chicken in chickens)
            {
                _chickens.Add(chicken);
            }

        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Chicken House {shortId} has {this._chickens.Count} animals\n");
            this._chickens.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}