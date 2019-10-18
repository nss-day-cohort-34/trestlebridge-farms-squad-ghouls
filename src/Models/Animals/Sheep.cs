using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Actions
{
    internal class Sheep : IResource, IGrazing
    {
        private Guid _id = Guid.NewGuid();
        private string _shortId {
            get {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }
        public string Type { get; } = "Sheep";
        public double GrassPerDay { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }


        public void Graze()
        {
            throw new System.NotImplementedException();
        }
         public override string ToString () {
            return $"Sheep {this._shortId}. Baaaa!";
        }
    }
}