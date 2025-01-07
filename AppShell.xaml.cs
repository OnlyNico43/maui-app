namespace PayBuddy;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
    }
}

public static class ShellExtensions
{
    public static readonly BindableProperty IconGlyphProperty =
        BindableProperty.CreateAttached(
            "IconGlyph",
            typeof(string),
            typeof(ShellExtensions),
            default(string));

    public static string GetIconGlyph(BindableObject view) =>
        (string)view.GetValue(IconGlyphProperty);

    public static void SetIconGlyph(BindableObject view, string value) =>
        view.SetValue(IconGlyphProperty, value);
}