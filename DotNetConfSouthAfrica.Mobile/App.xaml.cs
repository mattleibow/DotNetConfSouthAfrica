namespace DotNetConfSouthAfrica.Mobile;

public partial class App : Application
{
    private readonly XamlPage homePage;

    public App(XamlPage homePage)
    {
        InitializeComponent();

        this.homePage = homePage;
    }

    protected override Window CreateWindow(IActivationState activationState) =>
        new()
        {
            Page = new NavigationPage(homePage),
            Title = ".NET Conf (South Africa)"
        };
}
