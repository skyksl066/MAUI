using System.ComponentModel;

namespace mod07.Models;

public partial class Employee : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private int _id;
    private string? _name;
    private DateTime _hireDate;
    private decimal _salary;
    public int Id 
    {
        get => _id;
        set
        {
            if (_id != value)
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }
    public string? Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
    public DateTime HireDate
    {
        get => _hireDate;
        set
        {
            if (_hireDate != value)
            {
                _hireDate = value;
                OnPropertyChanged(nameof(HireDate));
            }
        }
    }
    public decimal Salary
    {
        get => _salary;
        set
        {
            if (_salary != value)
            {
                _salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }
    }
}
