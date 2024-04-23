﻿namespace Squadron.Models
{
    public class ArmoredVehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Condition { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }

        public ArmoredVehicle()
        {

        }
    }
}
