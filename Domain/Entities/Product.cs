using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Product : Entity
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
            Id = Guid.NewGuid();
        }
        public Product(){}
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Guid IdCategory { get; set; }
        public Category Category { get; set; }

        public void EditProduct(string name, decimal price, Guid idcategory, Guid id)
        {
            Name = name;
            Price = price;
            Id = id;
            IdCategory = idcategory;
            Id = id;
        }

    }
}
