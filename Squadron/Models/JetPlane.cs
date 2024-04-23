namespace Squadron.Models
{
    public class JetPlane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Condition { get; set; }
        public int Year { get; set; }
        public string Price { get; set; }
        public JetPlaneType Category { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }

        public JetPlane()
        {

        }
    }
}

