using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using PointofSaleSystem.Models;
using PointofSaleSystem.Windows;

namespace PointofSaleSystem.ViewModels
{
    public partial class UserVM
    {
        public string u3;
        public string un2 { get; set; }

        public UserVM(){ }

        [RelayCommand]
        public void ChangePasswordUser1()
        {
            u3 = un2;
            ChangePasswordUserVM changePasswordUserVM = new ChangePasswordUserVM
            {
                   userNameChange=u3,
            };
            ChangePasswordUser changePasswordUser = new ChangePasswordUser
            { 
                    DataContext = changePasswordUserVM,
            };
            changePasswordUser.ShowDialog();
        }

        [RelayCommand]
        public void LoadOrders()
        {
            OrderVM orderVM = new OrderVM();
            Windows.Order order = new Windows.Order
            {
                DataContext = orderVM,
            };
            order.ShowDialog();
        }

        [RelayCommand]
        public void LoadFood()
        {
            FoodVM foodVM = new FoodVM();
            Windows.Food food = new Windows.Food
            {
                DataContext = foodVM,
            };
            food.ShowDialog();
        }

        [RelayCommand]
        public void LogOutU()
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
