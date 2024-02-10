
namespace GuitarApp
{
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
                Type.ELECTRIC,
                6);

            List<Guitar> matchedGuitars = inventory.Search(whatErinLikes);
            if (matchedGuitars != null)
            {
                Console.WriteLine("Erin, you might like these guitars: ");
                foreach (var guitar in matchedGuitars)
                {
                    var guitarSpec = guitar.GetSpec();
                    Console.WriteLine($" We have a {guitarSpec.GetBuilder().ToLowerCaseString()} " +
                        $"{guitarSpec.GetModel()} " +
                        $"{guitarSpec.GetNumStrings()}-string "+
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
            inventory.AddGuitar("V95693", 1499.95, new GuitarSpec("Stratocastor", Builder.FENDER,
                                 Wood.ALDER, Wood.ALDER, Type.ELECTRIC, 6));
            inventory.AddGuitar("V9512", 1549.95, new GuitarSpec("Stratocastor", Builder.FENDER,
                                 Wood.ALDER, Wood.ALDER, Type.ELECTRIC, 6));
        }
    }
}
