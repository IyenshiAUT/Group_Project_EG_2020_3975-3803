using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class FoodVM:ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Models.Food> food;

        public FoodVM()
        {
            Food = new ObservableCollection<Models.Food>();

            using (var dbc = new DatabaseContext())
            {
                var list = dbc.Foods.OrderByDescending(p => p.QtySold).ToList();

                foreach (var food in list)
                {
                    Food.Add(food);
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
