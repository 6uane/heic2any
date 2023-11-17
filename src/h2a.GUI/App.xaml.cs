namespace h2a.GUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        (window.Width, window.Height) = (1280, 720);

        return window;
    }
}
