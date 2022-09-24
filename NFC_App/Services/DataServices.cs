using NFC_App.Model;
using System.Collections.ObjectModel;

namespace NFC_App.Services
{
    public class DataServices
    {
        public static ObservableCollection<ItemModel> Items { get; set; }
    }
}
