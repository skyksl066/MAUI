using CommunityToolkit.Mvvm.ComponentModel;

namespace mod08.ViewModels;

public partial class Lab03ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private string _title;
}
