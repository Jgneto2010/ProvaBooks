using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Product : Entity
    {
        public Product(string name, decimal price, Category category)
        {
            Name = name;
            Price = price;
            Category = category;
            Id = Guid.NewGuid();
        }
        public Product(){}
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Category Category { get; set; }
        public Guid IdCategory { get; set; }
    }
}
