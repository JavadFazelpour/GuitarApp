﻿
namespace GuitarApp
{
    public class Inventory
    {
        private List<Guitar> guitars;

        public Inventory()
        {
            guitars = new List<Guitar>();
        }
        public void AddGuitar(string serialNumber, double price, GuitarSpec guitarSpec)
        {
            Guitar guitar = new Guitar(serialNumber, price, guitarSpec);
            guitars.Add(guitar);
        }

        public Guitar GetGuitar(string serialNumber)
        {
            foreach (var item in guitars)
            {
                if (item.SerialNumber == serialNumber)
                    return item;
            }
            return null;
        }
        public List<Guitar> Search(GuitarSpec searchSpec)
        {
            List<Guitar> searchResults = new List<Guitar>();
            for (int i = 0; i < guitars.Count; i++)
            {
                if (guitars[i].Spec.Matches(searchSpec))
                    searchResults.Add(guitars[i]);
            }
            return searchResults;
        }
    }
}
