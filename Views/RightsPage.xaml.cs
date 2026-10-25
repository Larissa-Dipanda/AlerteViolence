using AlerteViolence.ViewModels;

namespace AlerteViolence.Views;

public partial class RightsPage : ContentPage
{
    public RightsPage()
    {
        InitializeComponent();
        // On lie la page au ViewModel qui contient la liste des lois et la commande
        BindingContext = new LoisViewModel();
    }

    //  Cette méthode est OBLIGATOIRE car elle est appelée par le bouton "Quitter l'app" dans le XAML
    private async void OnQuickExitClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//EndingPage");
    }
}