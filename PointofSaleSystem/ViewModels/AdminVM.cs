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
    public partial class AdminVM
    {
        public string u3;
        public string un2 { get;set; }

        public AdminVM()
        {

        }
        [RelayCommand]
        public void ChangePasswordAdmin1()
        {
            u3 = un2;
            ChangePasswordAdminVM changePasswordAdminVM = new ChangePasswordAdminVM
            {
                userNameChange = u3,
            };
            ChangePasswordAdmin changePasswordAdmin = new ChangePasswordAdmin
            {
                DataContext= changePasswordAdminVM,
            };
            changePasswordAdmin.ShowDialog();
        }

        [RelayCommand]
        public void AddUser1() 
        {
            AddUserVM addUserVM = new AddUserVM();
            AddUser addUser = new AddUser
            {
                DataContext = addUserVM,
            };
            addUser.ShowDialog();
        }

        [RelayCommand]
        public void RemoveUser1()
        {
            RemoveUserVM removeUserVM = new RemoveUserVM();
            RemoveUser removeUser = new RemoveUser
            {
                DataContext= removeUserVM,
            };
            removeUser.ShowDialog();

        }

        [RelayCommand]
        public void LogOutC()
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
