namespace aspnet_core_api.Models
{
    using System;

    public class Notification
    {
        public int id { get; set; }
        public string img { get; set; }
        public string title { get; set; }
        public DateTime date { get; set; }
    }
}