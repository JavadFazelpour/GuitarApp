
namespace GuitarApp
{
    public class Guitar
    {
        private string serialNumber;
        private double price;
        private GuitarSpec spec;

        public Guitar(string serialNumber,
                       double price,
                       GuitarSpec guitarSpec)
        {
            this.serialNumber = serialNumber;
            this.price = price;
            this.spec = guitarSpec;
        }
        public string GetSerialNumber() => serialNumber;
        public double GetPrice() => price;
        public void SetPrice(double newPrice) => this.price = newPrice;
        public GuitarSpec GetSpec() => spec;
    }
}
