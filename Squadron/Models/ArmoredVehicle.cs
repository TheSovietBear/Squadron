namespace Squadron.Models
{
    public class ArmoredVehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Condition { get; set; }
        public int Year { get; set; }
        public string Price { get; set; }  
        public string Category { get; set; }

        public ArmoredVehicle()
        {

        }
    }
}
