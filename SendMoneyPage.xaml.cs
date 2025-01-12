namespace PayBuddy;

public partial class SendMoneyPage : ContentPage
{
    public SendMoneyPage()
    {
        InitializeComponent();
        TransferDatePicker.MinimumDate = DateTime.Today;
    }

    private string selectedTransferSpeed;

    private void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton radioButton && e.Value)
        {
            selectedTransferSpeed = radioButton.Content.ToString();
        }
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        AmountLabel.Text = $"Selected Amount: ${e.NewValue:F2}";
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(RecipientNameEntry.Text))
        {
            await DisplayAlert("Validation Error", "Recipient's name is required.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(selectedTransferSpeed))
        {
            await DisplayAlert("Validation Error", "Please select a transfer speed.", "OK");
            return;
        }

        if (PaymentMethodPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Validation Error", "Please select a payment method.", "OK");
            return;
        }

        // Calculate total amount including fees
        double amount = AmountSlider.Value;
        double fee = selectedTransferSpeed.Contains("Instant") ? amount * 0.01 : 0;
        double totalAmount = amount + fee;

        // Navigate to confirmation page
        await Navigation.PushAsync(new TransactionConfirmationPage(
            RecipientNameEntry.Text,
            amount,
            fee,
            totalAmount,
            selectedTransferSpeed,
            PaymentMethodPicker.SelectedItem.ToString(),
            TransferDatePicker.Date,
            SaveContactCheckBox.IsChecked,
            ResetForm));
    }

    private void ResetForm()
    {
        RecipientNameEntry.Text = string.Empty;
        SaveContactCheckBox.IsChecked = false;
        InstantRadioButton.IsChecked = false;
        StandardRadioButton.IsChecked = false;
        AmountSlider.Value = AmountSlider.Minimum;
        PaymentMethodPicker.SelectedIndex = -1;
        TransferDatePicker.Date = DateTime.Today;
    }
}