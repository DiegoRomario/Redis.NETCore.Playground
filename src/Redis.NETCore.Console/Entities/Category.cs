using System;
using System.Collections.Generic;
using System.Text;

namespace Redis.NETCore.Entities
{
    public class Category
    {
        public Category(string description)
        {
            Id = Guid.NewGuid();
            Description = description;
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }

        public override string ToString()
        {
            return $"Id: {this.Id.ToString()}\nDescription: {this.Description} ";
        }

    }
}
