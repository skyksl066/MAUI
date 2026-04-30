using CommunityToolkit.Mvvm.ComponentModel;

namespace mod11.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private string title;
}
