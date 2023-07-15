using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PointofSaleSystem.Models;
using PointofSaleSystem.Windows;

namespace PointofSaleSystem.ViewModels
{
    public partial class AddUserVM:ObservableObject
    {
        public string UserNameNew { get; set; } 
        public string PasswordNew { get; set; }
        public string saveUserName;
        public string savePassword;
        public AddUserVM() { }

        [RelayCommand]
        public void SaveUser()
        {
            saveUserName = UserNameNew;
            savePassword = PasswordNew;

            if ((saveUserName == null)||(saveUserName==String.Empty)) 
            {
                MessageBox.Show("User Name is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if ((savePassword == null)||(savePassword==String.Empty))
            {
                MessageBox.Show("Password is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Models.User user = new Models.User 
                { 
                    UserName = saveUserName,
                    Password = savePassword
                };

                using (var db2=new DatabaseContext())
                {
                    db2.Users.Add(user);
                    db2.SaveChanges();
                }
                MessageBox.Show("New User was Added", "Add User is Successful", MessageBoxButton.OK, MessageBoxImage.Information);
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

        [RelayCommand]
        public void CancelAddUser()
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
