using CommunityToolkit.Mvvm.Input;
using NFC_App.Model;
using NFC_App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFC_App.ViewModel
{
    public partial class HomeViewModel : ObservableObject
    {
        public ObservableCollection<ItemModel> Items { get; set; } = DataServices.Items;
        [RelayCommand]
        async void GoBack()
        {
            await Shell.Current.GoToAsync("/.", true);
        }
    }
}
