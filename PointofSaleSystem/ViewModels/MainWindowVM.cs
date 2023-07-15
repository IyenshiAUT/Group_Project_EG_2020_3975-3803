using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PointofSaleSystem.Models;
using PointofSaleSystem.Windows;


namespace PointofSaleSystem.ViewModels
{
    public partial class MainWindowVM:ObservableObject
    {
        public MainWindowVM()
        {
            

        }

        [RelayCommand]
        public void LoginasAdmin()
        {
            LoginAdminVM loginAdminVM = new LoginAdminVM();
            LoginAdmin loginAdmin = new LoginAdmin
            {
                DataContext = loginAdminVM,
            };
            loginAdmin.ShowDialog();
        }

        [RelayCommand]
        public void LoginasUser()
        {
            LoginUserVM loginUserVM = new LoginUserVM();
            LoginUser loginUser = new LoginUser
            {
                DataContext =loginUserVM,
            };
            loginUser.ShowDialog();

        }
    }
        
}
