namespace ApartmentRestKanne
{
    public class Apartment
    {
        private int id;
        private int price;
        private string location;
        private int postalCode;
        private int size;
        private int noRoom;
        private bool washingMachine;
        private bool dishwasher;

        

        public int Id { get => id; set => id = value; }
        public int Price { get => price; set => price = value; }
        public string Location { get => location; set => location = value; }
        public int PostalCode { get => postalCode; set => postalCode = value; }
        public int Size { get => size; set => size = value; }
        public int NoRoom { get => noRoom; set => noRoom = value; }
        public bool WashingMachine { get => washingMachine; set => washingMachine = value; }
        public bool Dishwasher { get => dishwasher; set => dishwasher = value; }
    }
}