using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupCoffeeProj
{
    internal class Beverages : Items
    {
        //properties
        public string DrinkType { get; set; }
        public bool Caf { get; set; }
        public bool Hot { get; set; }
        
        //contructor
        public Beverages(string _name, string _category, string _description, decimal _price, string _drinktype, bool _caf, bool _hot) : base(_name, _category, _description, _price)
        {
            DrinkType = _drinktype;
            Caf = _caf;
            Hot = _hot;
        }

        //methods
        public override string ToString()
        {
            return base.ToString() + String.Format("{0,8}{1,6}{2,6}", DrinkType, Caf, Hot);
        }
    }
}
