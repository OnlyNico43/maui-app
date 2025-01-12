namespace PayBuddy;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    private async void OnGitHubClicked(object sender, EventArgs e)
    {
        try
        {
            Uri uri = new Uri("https://github.com/OnlyNico43/maui-app");
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Could not open the link", "OK");
        }
    }
}