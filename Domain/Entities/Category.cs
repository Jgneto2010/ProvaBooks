using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Category : Entity
    {
        public Category(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }
        public Category(){}
        public string Name { get; private set; }
        public List<Product> Products { get; set; }

        public void EditCategory(string name)
        {
            Name = name;
        }
    }

}

