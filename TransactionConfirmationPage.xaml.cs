namespace PayBuddy;

public partial class TransactionConfirmationPage : ContentPage
{
    private readonly Action onSuccess;
    
    public TransactionConfirmationPage(
        string recipientName,
        double amount,
        double fee,
        double totalAmount,
        string transferSpeed,
        string paymentMethod,
        DateTime transferDate,
        bool saveContact,
        Action onSuccessCallback)
    {
        InitializeComponent();
        onSuccess = onSuccessCallback;

        // Set the labels with clear, visible text
        RecipientLabel.Text = recipientName;
        AmountLabel.Text = $"Amount: ${amount:F2}";
        FeeLabel.Text = $"Fee: ${fee:F2}";
        TotalLabel.Text = $"Total to Pay: ${totalAmount:F2}";
        TransferSpeedLabel.Text = $"Transfer Speed: {transferSpeed}";
        PaymentMethodLabel.Text = $"Payment Method: {paymentMethod}";
        TransferDateLabel.Text = $"Transfer Date: {transferDate:dd/MM/yyyy}";
        SaveContactLabel.Text = $"Save Contact: {(saveContact ? "Yes" : "No")}";
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnConfirmClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Success", "Money transfer initiated successfully!", "OK");
        onSuccess?.Invoke();
        await Shell.Current.GoToAsync("//main");
    }
}