using System;
using WpfApp2;
namespace WpfApp1
{
    public class Product
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public double price { get; set; }
        public int originPeriod { get; set; }
        public string origin { get; set; }
        public string height_width { get; set; }
        public string condition { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string ImagePath { get; set; }
        public string Bought_from { get; set; }
        public DateTime Bought_on { get; set; }
    }
}