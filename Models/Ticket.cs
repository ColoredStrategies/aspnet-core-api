namespace aspnet_core_api.Models
{
    using System;
    public class Ticket
    {

        public int id { get; set; }
        public string title { get; set; }
        public DateTime date { get; set; }
        public string img { get; set; }
    }
}