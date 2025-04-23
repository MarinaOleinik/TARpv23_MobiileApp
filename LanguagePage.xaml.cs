using System.Globalization;
using TARpv23_MobiileApp.Resources.Lang;


namespace TARpv23_MobiileApp;


public partial class LanguagePage : ContentPage
{
    
    private Label label;

    public LanguagePage()
    {
        Title = "Mitmekeelne leht";

        // Tekstielement
        label = new Label
        {
            FontSize = 22,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Text = LocalizationResourceManager.Instance["HelloText"] // ← algväärtus
        };

        // Keelevaliku Picker
        var picker = new Picker
        {
            Title = "Vali keel",
            ItemsSource = new List<string> { "en", "et" },
            HorizontalOptions = LayoutOptions.Center
        };

        picker.SelectedIndexChanged += (s, e) =>
        {
            var selectedLang = (string)picker.SelectedItem;
            LocalizationResourceManager.Instance.SetCulture(selectedLang);

            // Uuenda teksti uue keele järgi
            label.Text = LocalizationResourceManager.Instance["HelloText"];
        };

        Content = new StackLayout
        {
            Padding = 30,
            Children =
                {
                    new Label
                    {
                        Text = "Vali rakenduse keel:",
                        FontSize = 18,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    picker,
                    label
                }
        };

    }
}