using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFC_App.Model
{
    public partial class ItemModel : ObservableObject
    {
        [ObservableProperty]
        string title;
        [ObservableProperty]
        string abaut;
        [ObservableProperty]
        DateTime dateTimeCreate;
        [ObservableProperty]
        DateTime dateTimeDelay;
        [ObservableProperty]
        string keyRFID;
    }
}
