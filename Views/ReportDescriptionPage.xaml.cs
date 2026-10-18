using AlerteViolence.ViewModels;

namespace AlerteViolence.Views;

public partial class ReportDescriptionPage : ContentPage
{
    public ReportDescriptionPage()
    {
        InitializeComponent();
        BindingContext = new ReportDescriptionViewModel();
    }
}