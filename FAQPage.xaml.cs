namespace PayBuddy;

public partial class FAQPage : ContentPage
{
    private Dictionary<string, VerticalStackLayout> buttonToAnswerMapping;

    public FAQPage()
    {
        InitializeComponent();
        SetupAnswerMapping();
    }

    private void SetupAnswerMapping()
    {
        buttonToAnswerMapping = new Dictionary<string, VerticalStackLayout>
        {
            { "SecurityButton", SecurityAnswer },
            { "LimitsButton", LimitsAnswer },
            { "FeesButton", FeesAnswer },
            { "PasswordButton", PasswordAnswer },
            { "UnauthorizedButton", UnauthorizedAnswer }
        };
    }

    private void OnToggleClicked(object sender, EventArgs e)
    {
        if (sender is Button button && buttonToAnswerMapping.TryGetValue(button.StyleId, out var answerSection))
        {
            // Toggle visibility
            answerSection.IsVisible = !answerSection.IsVisible;
            
            // Update button text
            button.Text = answerSection.IsVisible ? "-" : "+";
        }
    }
}