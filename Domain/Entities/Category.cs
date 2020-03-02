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
        }
        public Category(){}
        public string Name { get; private set; }
    }

}

