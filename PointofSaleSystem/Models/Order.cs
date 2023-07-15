using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSaleSystem.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int Bill { get; set; }
        public DateTime Date {  get; set; }


        public Order( int bill,DateTime date)
        {
           
            Bill = bill;
            Date = date;
        }
    }
}
