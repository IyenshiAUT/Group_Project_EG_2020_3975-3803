using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PointofSaleSystem.Models;
using PointofSaleSystem.Windows;

namespace PointofSaleSystem.ViewModels
{
    public partial class OrderVM:ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Models.Order> todayOrders;

        public int todayIncome { get; set; }
        public int todayIncomeSet=0;

        public int totalIncome { get; set; }
        public int totalIncomeSet=0;

        [ObservableProperty]
        public int g1, g2, g3, g4, g5, g6, g7, g8, g9, g10, g11, g12, g13, g14, g15, g16;

        public int calculation = 0;
        public int calculatedBill { get; set; }

        public List<Bill> SelectedItems;

        public Bill b;

        public OrderVM() { LoadTodayOrders(); }

        public void LoadTodayOrders()
        {
            var list2 = new List<Models.Order>();
            var today = DateTime.Today;
            using (var db1= new DatabaseContext())
            {
                var list = db1.Orders.OrderByDescending(p=>p.Bill).ToList();
                
                foreach (var order in list)
                {
                    if(order.Date.Date==today)
                    {
                        list2.Add(order);
                        todayIncomeSet += order.Bill;
                    }
                    totalIncomeSet += order.Bill;
                }
            }
            TodayOrders = new ObservableCollection<Models.Order>(list2);
            todayIncome = todayIncomeSet;
            totalIncome = totalIncomeSet;
            
        }

        /*public int calculateBill(List<Bill> billList)
        {
            int bill = 0;
            foreach (var item in billList)
            {
                bill = bill + (item.UnitPrice * item.Amount);
            }
            return bill;
        }*/

        [RelayCommand]
        public void GenerateBill()
        {
            if ((G1 == 0) && (G2 == 0) && (G3 == 0) && (G4 == 0) && (G5 == 0) && (G6 == 0) && (G7 == 0) && (G8 == 0) && (G9 == 0) && (G10 == 0) && (G11 == 0) && (G12 == 0) && (G13 == 0) && (G14 == 0) && (G15 == 0) && (G16 == 0))
            {
                MessageBox.Show("You have selected None!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if((G1 < 0) || (G2 < 0) || (G3 < 0) || (G4 < 0) || (G5 < 0) || (G6 < 0) || (G7 < 0) || (G8 < 0) || (G9 < 0) || (G10 < 0) || (G11 < 0) || (G12 < 0) || (G13 < 0) || (G14 < 0) || (G15 < 0) || (G16 < 0))
                {
                    MessageBox.Show("Amount cannot be Negative!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            else
                
            {
                SelectedItems = new List<Bill>();
                using (var db= new DatabaseContext())
                {
                    foreach (var item in db.Foods)
                    {
                        if(G1>=0)
                        {
                            if(item.FoodID=="F1")

                            {
                                Bill bill1 = new Bill(item.Name, item.UnitPrice, G1);
                                item.QtySold += G1;
                                SelectedItems.Add(bill1);
                            }
                            
                            
                        }
                        if (G2 >= 0)
                        {

                            if (item.FoodID == "F2")

                            {
                                Bill bill2 = new Bill(item.Name, item.UnitPrice, G2);
                                item.QtySold += G2;
                                SelectedItems.Add(bill2);
                            }
                            
                        }
                        if (G3 >= 0)
                        {

                            if (item.FoodID == "F3")

                            {
                                Bill bill3 = new Bill(item.Name, item.UnitPrice, G3);
                                item.QtySold += G3;
                                SelectedItems.Add(bill3);
                            }
                            
                        }
                        if (G4 >= 0)
                        {
                            if (item.FoodID == "F4")

                            {
                                Bill bill4 = new Bill(item.Name, item.UnitPrice, G4);
                                item.QtySold += G4;
                                SelectedItems.Add(bill4);
                            }
                        }
                        if (G5 >= 0)
                        {
                            if (item.FoodID == "F5")

                            {
                                Bill bill5 = new Bill(item.Name, item.UnitPrice, G5);
                                item.QtySold += G5;
                                SelectedItems.Add(bill5);
                            }
                        }
                        if (G6 >= 0)
                        {
                            if (item.FoodID == "F6")

                            {
                                Bill bill6 = new Bill(item.Name, item.UnitPrice, G6);
                                item.QtySold += G6;
                                SelectedItems.Add(bill6);
                            }
                        }
                        if (G7 >= 0)
                        {
                            if (item.FoodID == "F7")

                            {
                                Bill bill7 = new Bill(item.Name, item.UnitPrice, G7);
                                item.QtySold += G7;
                                SelectedItems.Add(bill7);
                            }
                        }
                        if (G8 >= 0)
                        {
                            if (item.FoodID == "F8")

                            {
                                Bill bill8 = new Bill(item.Name, item.UnitPrice, G8);
                                item.QtySold += G8;
                                SelectedItems.Add(bill8);
                            }
                        }
                        if (G9 >= 0)
                        {
                            if (item.FoodID == "F9")

                            {
                                Bill bill9 = new Bill(item.Name, item.UnitPrice, G9);
                                item.QtySold += G9;
                                SelectedItems.Add(bill9);
                            }
                        }
                        if (G10 >= 0)
                        {
                            if (item.FoodID == "F10")

                            {
                                Bill bill10 = new Bill(item.Name, item.UnitPrice, G10);
                                item.QtySold += G10;
                                SelectedItems.Add(bill10);
                            }
                        }
                        if (G11 >= 0)
                        {
                            if (item.FoodID == "F11")

                            {
                                Bill bill11 = new Bill(item.Name, item.UnitPrice, G11);
                                item.QtySold += G11;
                                SelectedItems.Add(bill11);
                            }
                        }
                        if (G12 >= 0)
                        {
                            if (item.FoodID == "F12")

                            {
                                Bill bill12 = new Bill(item.Name, item.UnitPrice, G12);
                                item.QtySold += G12;
                                SelectedItems.Add(bill12);
                            }
                        }
                        if (G13 >= 0)
                        {
                            if (item.FoodID == "F13")

                            {
                                Bill bill13 = new Bill(item.Name, item.UnitPrice, G13);
                                item.QtySold += G13;
                                SelectedItems.Add(bill13);
                            }
                        }
                        if (G14 >= 0)
                        {
                            if (item.FoodID == "F14")

                            {
                                Bill bill14 = new Bill(item.Name, item.UnitPrice, G14);
                                item.QtySold += G14;
                                SelectedItems.Add(bill14);
                            }
                        }
                        if (G15 >= 0)
                        {
                            if (item.FoodID == "F15")

                            {
                                Bill bill15 = new Bill(item.Name, item.UnitPrice, G15);
                                item.QtySold += G15;
                                SelectedItems.Add(bill15);
                            }
                        }
                        if (G16 >= 0)
                        {
                            if (item.FoodID == "F16")

                            {
                                Bill bill16 = new Bill(item.Name, item.UnitPrice, G16);
                                item.QtySold += G16;
                                SelectedItems.Add(bill16);
                            }
                        }

                    }

                    BillCalculation billCalculation1 = new BillCalculation(SelectedItems);
                    calculation = billCalculation1.BillCal;
                    //calculation = calculateBill(SelectedItems);
                    var result = MessageBox.Show($"The bill : {calculation}","Bill", MessageBoxButton.OKCancel);
                    if (result==MessageBoxResult.OK)
                    {
                        Models.Order order1 = new Models.Order(calculation,DateTime.Now);
                        db.Orders.Add(order1);
                        db.SaveChanges();
                        G1 = 0;G2 = 0; G3 = 0; G4 = 0;G6 = 0;G7 = 0;G8= 0;G9 = 0;G10= 0;G11 = 0;G12= 0;G13= 0;G14= 0;G15= 0;G16 = 0;
                        calculatedBill = calculation;
                        LoadTodayOrders();
                        //todayIncome = todayIncomeSet+ calculation;
                        //totalIncome = totalIncomeSet+ calculation;
                        
                    }


                }


                
                

            }
        }

        [RelayCommand]
        public void Clear()
        {
            G1 = 0; G2 = 0; G3 = 0; G4 = 0; G6 = 0; G7 = 0; G8 = 0; G9 = 0; G10 = 0; G11 = 0; G12 = 0; G13 = 0; G14 = 0; G15 = 0; G16 = 0;
        }

        [RelayCommand]
        public void Close()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.DialogResult = true;
                    window.Close();
                }
            }
        }

        [RelayCommand]
        public void AllOrdersLoad()
        {
            AllOrdersVM allOrdersVM = new AllOrdersVM();
            AllOrders allOrders = new AllOrders
            {
                DataContext = allOrdersVM,
            };
            allOrders.ShowDialog();
        }
    }
}
