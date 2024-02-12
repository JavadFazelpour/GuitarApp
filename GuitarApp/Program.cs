
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
                Builders.FENDER,
                Wood.ALDER, Wood.ALDER,
                Types.ELECTRIC,
                6);

            List<Guitar> matchedGuitars = inventory.Search(whatErinLikes);
            if (matchedGuitars != null)
            {
                Console.WriteLine("Erin, you might like these guitars: ");
                foreach (var guitar in matchedGuitars)
                {
                    var guitarSpec = guitar.Spec;
                    //  May be it's better to have this string in a method in the GuitarSpec calss
                    //for better encapsulation
                    Console.WriteLine($" We have a {guitarSpec}" +
                        $"You can have it for only {guitar.Price} !\n ----  ");
                }
            }
            else
                Console.WriteLine("Sorry, Erin, we have nothing for you.");
        }
        private static void InitializeInventory(Inventory inventory)
        {
            inventory.AddGuitar("V95693", 1499.95, new GuitarSpec("Stratocastor", Builders.FENDER,
                                 Wood.ALDER, Wood.ALDER, Types.ELECTRIC, 6));
            inventory.AddGuitar("V9512", 1549.95, new GuitarSpec("Stratocastor", Builders.FENDER,
                                 Wood.ALDER, Wood.ALDER, Types.ELECTRIC, 6));
        }
    }
}
