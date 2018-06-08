using System;

namespace Api.Entities
{
    public class Cemetery
    {
        public string IdCemetery { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}