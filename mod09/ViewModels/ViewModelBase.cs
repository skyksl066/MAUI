using CommunityToolkit.Mvvm.ComponentModel;

namespace mod09.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private string title;
}
