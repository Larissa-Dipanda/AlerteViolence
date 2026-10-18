using AlerteViolence.ViewModels;

namespace AlerteViolence.Views;

public partial class LoisPage : ContentPage
{
    public LoisPage()
    {
        InitializeComponent();
        BindingContext = new LoisViewModel();
    }
}