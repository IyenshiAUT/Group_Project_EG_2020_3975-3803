using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSaleSystem.Models
{
    public class Food
    {
        public string FoodID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int UnitPrice { get; set; }
        public int QtySold { get; set; }

        public Food(string foodID, string name, string type, int unitPrice, int qtySold)
        {
            FoodID = foodID;
            Name = name;
            Type = type;
            UnitPrice = unitPrice;
            QtySold = qtySold;
        }
    }
}
