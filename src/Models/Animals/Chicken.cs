using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals
{
    public class Chicken : IResource, IMeatProducing
    {
        public string Type { get; } = "Chicken";
        private Guid _id = Guid.NewGuid();
        public double FeedPerDay { get; set; } = 0.9;

        private double _meatProduced = 1.7;

        private string _shortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        public double Butcher()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Chicken {this._shortId}. Cluck!";
        }
    }
}