using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class CreateBookDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublishingDate { get; set; }
        public double Price { get; set; }
    }
}
