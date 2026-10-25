namespace AlerteViolence.Views;

public partial class LaunchingPage : ContentPage
{
    public LaunchingPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Task.Delay(2000); // 2 secondes pour voir le logo
        await Shell.Current.GoToAsync(nameof(EntryPage));
    }
}