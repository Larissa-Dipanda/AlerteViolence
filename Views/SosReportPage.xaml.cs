using AlerteViolence.ViewModels;

namespace AlerteViolence.Views;

public partial class SosReportPage : ContentPage
{
    public SosReportPage()
    {
        InitializeComponent();
        BindingContext = new SosReportViewModel();
    }
}