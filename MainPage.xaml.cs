namespace PayBuddy;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        LoadContactsAsync();

        // Define the data source
        var cardItems = new List<CardItem>
        {
            new CardItem
            {
                Title = "Balance",
                Amount = "$45,678.90",
                Description = "+20% in the last 30 days"
            },
            new CardItem
            {
                Title = "Monthly Spending",
                Amount = "$2,405",
                Description = "+33% in the last 30 days"
            },
            new CardItem
            {
                Title = "Savings",
                Amount = "$10,000",
                Description = "+10% in the last 30 days"
            }
        };

        // Set the ItemsSource for the CollectionView
        CardCollectionView.ItemsSource = cardItems;
        
        var successColor = (Color)Application.Current.Resources["Success"];
        var dangerColor = (Color)Application.Current.Resources["Danger"];
        
        var transactions = new List<Transaction>
        {
            new Transaction { Amount = "- $11.15", AmountColor = dangerColor, Description = "Coop Ryflihof" },
            new Transaction { Amount = "+ $9.20", AmountColor = successColor, Description = "Money received from H. Hills" },
            new Transaction { Amount = "- $50.45", AmountColor = dangerColor, Description = "Loeb Bern" },
            new Transaction { Amount = "- $21.95", AmountColor = dangerColor, Description = "Sprüngli Bern HB" },
            new Transaction { Amount = "- $105.70", AmountColor = dangerColor, Description = "Digitec Galaxus" }
        };

        // Set the data source
        TransactionsCollectionView.ItemsSource = transactions;
    }

    private async void OnTap2PayClicked(object sender, EventArgs e)
    {
        // Navigate to PaymentPage
        try
        {
            await Navigation.PushAsync(new PaymentPage());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void OnToTransactionsClicked(object sender, EventArgs e)
    {
        // Navigate to the defined route in properties
        try
        {
            await Shell.Current.GoToAsync("//transactions");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
    
    private async void OnAllContactsClicked(object sender, EventArgs e)
    {
        // Navigate to the defined route in properties
        try
        {
            await Shell.Current.GoToAsync("//contacts");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
    
    public class CardItem
    {
        public string Title { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
    }
    
    // Load contacts with random profile pictures
    private async Task LoadContactsAsync()
    {
        var contacts = new List<Contact>
        {
            new Contact { Name = "Helena Hills", Email = "email@fakedomain.net" },
            new Contact { Name = "Oscar Dum", Email = "email@fakedomain.net" },
            new Contact { Name = "Carlo Emilion", Email = "email@fakedomain.net" },
            new Contact { Name = "Daniel Jay Park", Email = "email@fakedomain.net" }
        };

        // Add random profile pictures
        foreach (var contact in contacts)
        {
            contact.ProfilePicture = await GetRandomProfilePictureAsync();
        }

        // Set the data source
        ContactsCollectionView.ItemsSource = contacts;
    }

    // Fetch a random profile picture
    private async Task<string> GetRandomProfilePictureAsync()
    {
        try
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://randomuser.me/api/");
            var json = JsonDocument.Parse(response);

            // Extract the profile picture URL
            var pictureUrl = json.RootElement
                .GetProperty("results")[0]
                .GetProperty("picture")
                .GetProperty("medium")
                .GetString();

            return pictureUrl;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to fetch random profile picture: {ex.Message}");
            return "default_placeholder.png"; // Use a local placeholder image in case of an error
        }
    }

    
    // Contact model
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; } // Path to profile image
    }
    
    // Transaction model
    public class Transaction
    {
        public string Amount { get; set; }
        public Color AmountColor { get; set; }
        public string Description { get; set; }
    }
}