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
    public partial class RemoveUserVM
    {
        public string UserNameRemove { get; set; }
        public string UserPasswordRemove { get; set; }
        public string unRemove;
        public string pwRemove;

        public RemoveUserVM() { }

        [RelayCommand]
        public void RemoveUserExsist() 
        {
            unRemove = UserNameRemove;
            pwRemove = UserPasswordRemove;

            if((unRemove == null)||(unRemove==String.Empty))
            {
                MessageBox.Show("User Name is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if((pwRemove == null)||(pwRemove==String.Empty))
            {
                MessageBox.Show("Password is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                using (var db3=new DatabaseContext())
                {
                    foreach(var item in db3.Users)
                    {
                        if(item.UserName == unRemove)
                        {
                            if(item.Password == pwRemove)
                            {
                                var Result= MessageBox.Show("Are you sure to remove the {unRemove}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if(Result == MessageBoxResult.Yes)
                                {
                                    db3.Remove(item);
                                    db3.SaveChanges();
                                    MessageBox.Show("User was Removed Successfully", "Remove User is Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                                    foreach (Window window in Application.Current.Windows)
                                    {
                                        if (window.DataContext == this)
                                        {
                                            window.DialogResult = true;
                                            window.Close();
                                        }
                                    }

                                }
                                if(Result==MessageBoxResult.No)
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
                        else MessageBox.Show("There is NO User Found with provided Details", "Remove User is Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    

                }
            }
        }

        [RelayCommand]
        public void RemoveUserCancel()
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
