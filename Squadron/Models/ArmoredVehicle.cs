namespace Squadron.Models
{
    public class ArmoredVehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Condition { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public ArmoredVehicleType Category { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }

        public ArmoredVehicle()
        {

        }
    }
}
