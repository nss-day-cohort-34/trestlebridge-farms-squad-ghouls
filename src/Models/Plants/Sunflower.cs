using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Sunflower : IResource, ISeedProducing, ICompostProducing
    {
        private int _seedsProduced = 650;
        private double _compostProduced = 21.6;
        public string Type { get; } = "Sunflower";

        public int GetPlantCount()
        {
            throw new NotImplementedException();
        }

        public double Harvest () {
            return _seedsProduced;
        }

        public double Shovel() {
            return _compostProduced;
        }

        public override string ToString () {
            return $"Sunflower. Oh my!";
        }
    }
}