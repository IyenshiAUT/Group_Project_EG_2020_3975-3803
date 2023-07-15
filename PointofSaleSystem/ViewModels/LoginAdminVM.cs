using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PointofSaleSystem.Models;
using PointofSaleSystem.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PointofSaleSystem.ViewModels
{
    public partial class LoginAdminVM:ObservableObject
    {
        public string username1 { get; set; }
        public string password1 { get; set; }

        public string un;
        public string pw;

        public LoginAdminVM() { }

        [RelayCommand]
        public void LoginAdminLogin()
        {
            un = username1;
            pw = password1;
            if (un == null || un ==string.Empty)
            {
                MessageBox.Show("User Name is Required!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else if(pw == null || un==string.Empty)
            {
                MessageBox.Show("Password is Required!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else
            {
                bool v = false;
                using (var db = new DatabaseContext())
                {
                    foreach (var item in db.Admins)
                    {
                        if (un == item.UserName)
                        {
                            if (pw == item.Password)
                            {
                                v = true;
                            }
                        }
                    }
                }
                if (v == true)
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.DataContext == this)
                        {
                            window.DialogResult = true;
                            window.Close();
                        }
                    }
                    AdminVM adminVM = new AdminVM
                    {
                        un2=un,
                    };
                    Windows.Admin admin = new Windows.Admin
                    {
                        DataContext = adminVM,
                    };
                    admin.ShowDialog();
                    
                }
                if (v == false)
                {
                    MessageBox.Show("User Name or Password is Incorrect!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            
        }

        [RelayCommand]
        public void LoginAdminCancel()
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
