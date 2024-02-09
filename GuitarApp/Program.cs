using System.Reflection.Emit;

namespace GuitarApp
{
    public enum Type
    {
        ACOUSTIC, ELECTRIC,
    }
    public static class EnumExtentions
    {
        public static string ToLowerCaseString(this Type type)
        {
            return type.ToString().ToLower();
        }
        public static string ToLowerCaseString(this Builder builder)
        {
            return builder.ToString().ToLower();
        }
        public static string ToLowerCaseString(this Wood wood)
        {
            string output = "";
            switch (wood)
            {
                case Wood.INDIAN_ROSEWOOD:
                    output = "Indian Rosewood";
                    break;
                case Wood.BRAZILAN_ROSEWOOD:
                    output = "Brazilian Rosewood";
                    break;
                case Wood.MAHOGANY:
                    output = "Mahogany";
                    break;
                case Wood.MAPLE:
                    output = "Maple";
                    break;
                case Wood.COCOBOLO:
                    output = "Cocobolo";
                    break;
                case Wood.CEDAR:
                    output = "Cedar";
                    break;
                case Wood.ADIRONDACK:
                    output = "Adirondack";
                    break;
                case Wood.ALDER:
                    output = "Alder";
                    break;
                case Wood.SITKA:
                    output = "Sitka";
                    break;
            }
            return output;
        }
    }
    public enum Wood
    {
        INDIAN_ROSEWOOD, BRAZILAN_ROSEWOOD,
        MAHOGANY, MAPLE, COCOBOLO, CEDAR,
        ADIRONDACK, ALDER, SITKA,
    }
    public enum Builder
    {
        FENDER, MARTIN, GIBSON, COLLINGS, OLSON, RYAN, PRS, ANY
    }

    public class Guitar
    {
        private string serialNumber;
        private double price;
        private GuitarSpec spec;

        public Guitar(string serialNumber,
                       double price,
                       Builder builder,
                       string model,
                       Type type,
                       Wood backWood,
                       Wood topWood)
        {
            this.serialNumber = serialNumber;
            this.price = price;
            this.spec = new GuitarSpec(model, builder, backWood, topWood, type);
        }
        public string GetSerialNumber() => serialNumber;
        public double GetPrice() => price;
        public void SetPrice(double newPrice) => this.price = newPrice;
        public GuitarSpec GetSpec()
        {
            return spec;
        }

    }
    public class GuitarSpec
    {
        private string model;
        private Builder builder;
        private Wood backWood, topWood;
        private Type type;

        public GuitarSpec(string model, Builder builder, Wood backWood, Wood topWood, Type type)
        {
            this.model = model;
            this.builder = builder;
            this.backWood = backWood;
            this.topWood = topWood;
            this.type = type;
        }

        public Builder GetBuilder() => builder;
        public string GetModel() => model;
        public Type getType() => type;
        public Wood GetBackWood() => backWood;
        public Wood GetTopWood() => topWood;
    }
    public class Inventory
    {
        private List<Guitar> guitars;

        public Inventory()
        {
            guitars = new List<Guitar>();
        }
        public void AddGuitar(string serialNumber, double price, Builder builder, string model,
                              Type type, Wood backWood, Wood topWood)
        {
            Guitar guitar = new Guitar(serialNumber, price, builder, model, type, backWood, topWood);
            guitars.Add(guitar);
        }

        public Guitar GetGuitar(string serialNumber)
        {
            foreach (var item in guitars)
            {
                if (item.GetSerialNumber() == serialNumber)
                    return item;
            }
            return null;
        }
        public List<Guitar> Search(GuitarSpec searchGuitar)
        {
            List<Guitar> searchResults = new List<Guitar>();
            for (int i = 0; i < guitars.Count; i++)
            {
                GuitarSpec guitarSpec = guitars[i].GetSpec();
                if (guitarSpec.GetBuilder().ToLowerCaseString() != searchGuitar.GetBuilder().ToLowerCaseString())
                    continue;
                if (guitarSpec.GetModel().ToLower() != searchGuitar.GetModel().ToLower())
                    continue;
                if (guitarSpec.getType().ToLowerCaseString() != searchGuitar.getType().ToLowerCaseString())
                    continue;
                if (guitarSpec.GetBackWood().ToLowerCaseString() != searchGuitar.GetBackWood().ToLowerCaseString())
                    continue;
                if (guitarSpec.GetTopWood().ToLowerCaseString() != searchGuitar.GetTopWood().ToLowerCaseString())
                    continue;
                searchResults.Add(guitars[i]);
            }
            return searchResults;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            InitializeInventory(inventory);
            GuitarSpec whatErinLikes = new GuitarSpec
                ("Stratocastor",
                Builder.FENDER,
                Wood.ALDER, Wood.ALDER,
                Type.ELECTRIC
                );
            GuitarSpec whatClientLikes = new GuitarSpec
                ("OM-18",
                Builder.MARTIN,
                Wood.MAHOGANY, Wood.ADIRONDACK,
                Type.ACOUSTIC
                );
            List<Guitar> matchedGuitars = inventory.Search(whatErinLikes);
            if (matchedGuitars != null)
            {
                Console.WriteLine("Erin, you might like these guitars: ");
                foreach (var guitar in matchedGuitars)
                {
                    var guitarSpec = guitar.GetSpec();
                    Console.WriteLine($" We have a {guitarSpec.GetBuilder().ToLowerCaseString()} " +
                        $"{guitarSpec.GetModel()} " +
                        $"{guitarSpec.getType().ToLowerCaseString()} guitar:\n   " +
                        $"{guitarSpec.GetBackWood().ToLowerCaseString()} back and sides,\n   " +
                        $"{guitarSpec.GetTopWood().ToLowerCaseString()} top.\n   " +
                        $"You can have it for only {guitar.GetPrice()} !\n ----  ");
                }
            }
            else
                Console.WriteLine("Sorry, Erin, we have nothing for you.");
        }
        private static void InitializeInventory(Inventory inventory)
        {
            inventory.AddGuitar("V95693", 1499.95, Builder.FENDER, "Stratocastor",
                                Type.ELECTRIC, Wood.ALDER, Wood.ALDER);
            inventory.AddGuitar("V9512", 1549.95, Builder.FENDER, "Stratocastor",
                                Type.ELECTRIC, Wood.ALDER, Wood.ALDER);
        }
    }
}
