using System;
using System.Linq;
using System.Collections.Generic;

namespace AlerteViolence.Views;

public partial class SupportDetailsPage : ContentPage
{
    public SupportDetailsPage() { InitializeComponent(); }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var query = Shell.Current.CurrentState.Location.Query;
        if (!string.IsNullOrEmpty(query) && query.StartsWith("?"))
            query = query.Substring(1);

        var pairs = query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var p in pairs)
        {
            var kv = p.Split(new[] { '=' }, 2);
            if (kv.Length == 2 && Uri.UnescapeDataString(kv[0]) == "service")
            {
                LblService.Text = "Service: " + Uri.UnescapeDataString(kv[1]);
                break;
            }
        }
    }
    private async void OnBackClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("..");
}