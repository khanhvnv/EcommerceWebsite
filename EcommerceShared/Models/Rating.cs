using System;

namespace EcommerceShared.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Stars { get; set; }
        public string ? Review { get; set; }
    }
}
