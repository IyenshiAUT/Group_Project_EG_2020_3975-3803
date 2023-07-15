using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSaleSystem.Models
{
    public class Bill
    {

        public string FoodItem { get; set; }
        public int UnitPrice { get; set; }
        public int Amount { get; set; }

        public  int billcal { get; set; }

        public Bill(string foodItem, int unitPrice,int amount) 
        { 
            FoodItem= foodItem;
            UnitPrice= unitPrice;
            Amount= amount;
        }

        public List<Bill> BillList { get; set; }

        public int BillCount(List<Bill> BillList)
        {
            int bill = 0;
            foreach(var item in BillList)
            {
                bill=bill+item.UnitPrice*item.Amount;
            }
            billcal = bill;
            return billcal;
        }
    }
}
