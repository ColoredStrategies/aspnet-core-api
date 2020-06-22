namespace aspnet_core_api.Models
{
    using System;
    public class Cake
    {
        public int id { get; set; }
        public string title { get; set; }
        public string img { get; set; }
        public string category { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public string statusColor { get; set; }
        public string description { get; set; }
        public int sales { get; set; }
        public int stock { get; set; }
    }
}