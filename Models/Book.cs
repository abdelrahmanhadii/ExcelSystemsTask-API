using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Book
    {
        public int ID { get; set; }
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }
        [MinLength(5), MaxLength(200)]
        public string Description { get; set; }
        [MinLength(3), MaxLength(15)]
        public string Author { get; set; }
        public DateTime PublishingDate { get; set; }
        [MinLength(1)]
        public double Price { get; set; }
    }
}
