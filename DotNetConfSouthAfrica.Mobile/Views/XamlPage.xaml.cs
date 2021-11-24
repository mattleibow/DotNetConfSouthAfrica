namespace DotNetConfSouthAfrica.Mobile.Views;

public partial class XamlPage : ContentPage
{
    public XamlPage(WeatherViewModel vm, IServiceProvider services)
    {
        InitializeComponent();

        BindingContext = ViewModel = vm;
        Services = services;
    }

    public WeatherViewModel ViewModel { get; }

    public IServiceProvider Services { get; }

    protected override async void OnAppearing() =>
        await ViewModel.RefreshDataAsync();

    private void OnGoToBlazorClicked(object sender, EventArgs e) =>
        Navigation.PushAsync(Services.GetService<BlazorPage>());
}
