using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models
{
    public class Farm
    {





        public List<GrazingField> GrazingFields { get; } = new List<GrazingField>();
        public List<GrazingField> AvailableGrazingFields { get; } = new List<GrazingField>();
        public List<PlowedField> PlowedFields { get; } = new List<PlowedField>();
        public List<PlowedField> AvailablePlowedFields { get; } = new List<PlowedField>();
        public List<NaturalField> NaturalFields { get; } = new List<NaturalField>();
        public List<NaturalField> AvailableNaturalFields { get; } = new List<NaturalField>();
        public List<ChickenHouse> ChickenHouses { get; } = new List<ChickenHouse>();
        public List<ChickenHouse> AvailableChickenHouses { get; } = new List<ChickenHouse>();
        public List<DuckHouse> DuckHouses { get; } = new List<DuckHouse>();
        public List<DuckHouse> AvailableDuckHouses { get; } = new List<DuckHouse>();

    



        /*
            This method must specify the correct product interface of the
            resource being purchased.
         */
        public void PurchaseResource<T> (IResource resource, int index)
        {
            Console.WriteLine(typeof(T).ToString());
            switch (typeof(T).ToString())
            {
                case "Cow":
                    GrazingFields[index].AddResource((IGrazing)resource);
                    break;
                default:
                    break;
            }
        }

        public void AddGrazingField (GrazingField field)
        {
            GrazingFields.Add(field);
            AvailableGrazingFields.Add(field);
        }
        public void AddPlowedField (PlowedField field)
        {
            PlowedFields.Add(field);
            AvailablePlowedFields.Add(field);


        }
        public void AddNaturalField (NaturalField field)
        {
            NaturalFields.Add(field);
            AvailableNaturalFields.Add(field);


        }
        public void AddChickenHouse (ChickenHouse house)
        {
            ChickenHouses.Add(house);
            AvailableChickenHouses.Add(house);
        }
        public void AddDuckHouse (DuckHouse house)
        {
            AvailableDuckHouses.Add(house);
            DuckHouses.Add(house);
        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            GrazingFields.ForEach(gf => report.Append(gf));
            ChickenHouses.ForEach(ch => report.Append(ch));
            DuckHouses.ForEach(dh => report.Append(dh));
            NaturalFields.ForEach(dh => report.Append(dh));
            PlowedFields.ForEach(dh => report.Append(dh));


            return report.ToString();
        }
    }
}