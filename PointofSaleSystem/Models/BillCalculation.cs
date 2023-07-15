using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSaleSystem.Models
{
    public class BillCalculation
    {
        public int BillCal { get; set; }
        //public List<Bill> BillList { get; set; }
        public BillCalculation(List<Bill> BillList) 
        {
            int bill = 0;
            foreach (var item in BillList)
            {
                bill = bill + item.UnitPrice * item.Amount;
            }
            BillCal = bill;
            
        }
    }
}
