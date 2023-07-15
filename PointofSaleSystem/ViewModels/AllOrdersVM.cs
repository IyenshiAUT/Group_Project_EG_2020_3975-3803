using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointofSaleSystem;
using PointofSaleSystem.Windows;
using PointofSaleSystem.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace PointofSaleSystem.ViewModels
{
    public partial class AllOrdersVM:ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Models.Order> orders;

        public AllOrdersVM()
        {
            Orders = new ObservableCollection<Models.Order>();

            using(var dbm = new DatabaseContext())
            {
                var list = dbm.Orders.ToList();

                foreach (var order in list)
                {
                    Orders.Add(order);
                }
            }
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
    }
}
