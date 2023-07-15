using PointofSaleSystem.Models;
using PointofSaleSystem.ViewModels;

namespace TestBusinessProcess
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Bill_Calculation()
        {
            //OrderVM vm= new OrderVM();
            List<Bill> billList= new List<Bill>();
            billList.Add(new Bill("Mango", 30, 5));
            billList.Add(new Bill("Banana", 20, 15));
            BillCalculation billCalculation = new BillCalculation(billList);
            
            Assert.Equal(450,billCalculation.BillCal);
        }
    }
}