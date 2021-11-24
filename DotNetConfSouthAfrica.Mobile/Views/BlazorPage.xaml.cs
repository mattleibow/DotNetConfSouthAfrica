namespace DotNetConfSouthAfrica.Mobile.Views;

public partial class BlazorPage : ContentPage
{
    public BlazorPage(IServiceProvider services)
    {
        InitializeComponent();

        Services = services;
    }

    public IServiceProvider Services { get; }

    private void OnGoToXamlClicked(object sender, EventArgs e) =>
        Navigation.PushAsync(Services.GetService<XamlPage>());
}
