using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using PointofSaleSystem.Models;
using PointofSaleSystem.Windows;

namespace PointofSaleSystem.ViewModels
{
    public partial class LoginUserVM
    {

        public string username1 { get; set; }
        public string password1 { get; set; }

        public string un;
        public string pw;

        public LoginUserVM() { }

        [RelayCommand]
        public void LoginUserLogin()
        {
            un = username1;
            pw = password1;
            if (un == null || un == string.Empty)
            {
                MessageBox.Show("User Name is Required!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else if (pw == null || un == string.Empty)
            {
                MessageBox.Show("Password is Required!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else
            {
                bool v = false;
                using (var db = new DatabaseContext())
                {
                    foreach (var item in db.Users)
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

                            window.Close();
                        }
                    }
                    UserVM userVM = new UserVM 
                    {
                        un2 = un,
                    };
                    Windows.User user = new Windows.User
                    {
                        DataContext = userVM,
                    };
                    user.ShowDialog();
                }
                if (v == false)
                {
                    MessageBox.Show("User Name or Password is Incorrect!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }

        }

        [RelayCommand]
        public void LoginUserCancel()
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
