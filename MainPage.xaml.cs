namespace PayBuddy;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        // Any additional code-behind logic can be added here.
    }

    private async void OnTap2PayClicked(object sender, EventArgs e)
    {
        // Navigate to PaymentPage
        try
        {
            await Shell.Current.GoToAsync("//payment");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}