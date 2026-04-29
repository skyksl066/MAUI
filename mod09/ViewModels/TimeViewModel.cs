using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mod09.ViewModels
{
    public partial class TimeViewModel : ObservableObject
    {
        [ObservableProperty]
        private DateTime time;
        public TimeViewModel()
        {
            Time = DateTime.Now;
        }
    }

}
