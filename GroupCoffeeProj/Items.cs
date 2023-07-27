using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupCoffeeProj
{
    internal class Items
    {
        //properties
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        
        public decimal Price { get; set; }


        //constructor
        public Items(string _name, string _category, string _description, decimal _price)
        {
            Name = _name;
            Category = _category;
            Description = _description;
            Price = _price;
        }

        //methods
        public override string ToString()
        {
            return  String.Format(" {0,8}{1,6}{2,6}{3,6:c}", Name, Category, Description, Price);
        }
    }
}
