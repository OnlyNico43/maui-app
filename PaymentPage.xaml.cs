namespace PayBuddy;

using System.ComponentModel;
using System.Runtime.CompilerServices;

public partial class PaymentPage : ContentPage, INotifyPropertyChanged
{
    private string _statusMessage;
    private string _paymentAmount;
    private Color _nfcIconColor;
    private bool _isAmountVisible;

    public string StatusMessage
    {
        get => _statusMessage;
        set { _statusMessage = value; OnPropertyChanged(); }
    }

    public string PaymentAmount
    {
        get => _paymentAmount;
        set { _paymentAmount = value; OnPropertyChanged(); }
    }

    public Color NFCIconColor
    {
        get => _nfcIconColor;
        set { _nfcIconColor = value; OnPropertyChanged(); }
    }

    public bool IsAmountVisible
    {
        get => _isAmountVisible;
        set { _isAmountVisible = value; OnPropertyChanged(); }
    }

    public PaymentPage()
    {
        InitializeComponent();
        BindingContext = this;

        // Initial State (Payment in Progress)
        StatusMessage = "Payment in progress";
        NFCIconColor = (Color)Application.Current.Resources["Primary"];
        IsAmountVisible = false;

        // Simulate Payment Success after delay
        SimulatePayment();
    }

    private async void SimulatePayment()
    {
        // Simulate delay for payment processing
        await Task.Delay(3000);

        // Update to success state
        StatusMessage = "Payment successful";
        NFCIconColor = Colors.Green; // Use green for success
        PaymentAmount = "- $11.15";
        IsAmountVisible = true;
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//main");
    }

    // PropertyChanged implementation for data binding
    public new event PropertyChangedEventHandler PropertyChanged;
    protected new void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
