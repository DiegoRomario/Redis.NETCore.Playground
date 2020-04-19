using System;
using System.Collections.Generic;
using System.Text;

namespace Redis.NETCore.Entities
{
    public class Product
    {
        public Product(string name, double price, Category category)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Category = category;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public Category Category { get; private set; }

        public override string ToString()
        {
            return $"Id: {this.Id}\nName: {this.Name}\nPrice: {this.Price:c} ";
        }

    }
}
