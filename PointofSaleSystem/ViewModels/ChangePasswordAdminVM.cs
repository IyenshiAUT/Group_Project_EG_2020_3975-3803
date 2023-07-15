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
    public partial class ChangePasswordAdminVM
    {
        public string userNameChange { get; set; }
        public string userNameC;
        string pwCurrent;
        string pwChange;
        string pwChangeRe;
        public string passwordCurrent { get; set; }
        public string passwordChange { get; set; }
        public string passwordChangeRe { get;set; }

        public ChangePasswordAdminVM() { }

        [RelayCommand]
        public void Save1()
        {
            
            pwCurrent = passwordCurrent;
            pwChange=passwordChange;
            pwChangeRe=passwordChangeRe;
            if((pwCurrent==null)||(pwCurrent==String.Empty))
            {
                MessageBox.Show("Current Password is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if((pwChange == null) || (pwChange == String.Empty))
            {
                MessageBox.Show("New Password is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if((pwChangeRe == null) || (pwChangeRe == String.Empty))
            {
                MessageBox.Show("New Password is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if(pwChange!=passwordChangeRe)
                {
                    MessageBox.Show("New Passwords You entered are not Matching", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    userNameC = userNameChange;
                    using (var db=new DatabaseContext())
                    {
                        foreach(var item in db.Admins)
                        {
                            if(item.UserName == userNameC)
                            {
                                item.Password = pwChange;
                                db.SaveChanges();
                                MessageBox.Show("Save Password is Successful!", "Save Password-Successful", MessageBoxButton.OK, MessageBoxImage.Information);
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
                }
            }
        }

        [RelayCommand]
        public void Cancel1()
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
