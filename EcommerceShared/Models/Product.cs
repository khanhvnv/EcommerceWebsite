using System;

namespace EcommerceShared.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ? Name { get; set; }
        public string ? Description { get; set; }
        public decimal Price { get; set; }
        public string ? ImageURL { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
         // Foreign key to Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
