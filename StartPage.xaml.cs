using TARpv23_MobiileApp.Resources.Styles;

namespace TARpv23_MobiileApp;

public partial class StartPage : ContentPage
{
    Picker picker;
    public List<ContentPage> lehed=new List<ContentPage>() { new TextPage(),new FigurePage(), new Lumememm(), new KaameraPage(),new KarussellPage(),new LanguagePage()};
	public List<string> tekstid=new List<string>{"Tee lahti TekstPage", "Tee lahti FigurePage","Lumi","Teeme foto", "Vaata karussell", "Mitmekeelne leht" };
	ScrollView sv;
	VerticalStackLayout vsl;
    
    public StartPage()
	{
        BindingContext = new ThemeViewModel();
		Title = "Avaleht";
		
		vsl = new VerticalStackLayout {  };//BackgroundColor = Color.FromRgb(150, 100, 20)
        picker = new Picker
        {
            Title = "Vali teema"
        };
        picker.ItemsSource = Enum.GetNames(typeof(Theme));
        picker.ItemsSource = new List<string>
        {
            "Tume",
            "Hele"
        };


        
        picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
        for (int i = 0; i < tekstid.Count;i++)
		{
			Button nupp = new Button
			{
				Text= tekstid[i],
				BackgroundColor=Color.FromRgb(i+10, 100, 20),
				TextColor=Color.FromRgb(150, 150, 190),
				BorderWidth=10,
				ZIndex=i,
				FontFamily= "luffio Regular 400"

            };
			vsl.Add(nupp);
            nupp.Clicked += Lehte_avamine;
		}
		sv=new ScrollView { Content=vsl};
		Content = sv;
	}
    Theme theme;
    private void Picker_SelectedIndexChanged(object? sender, EventArgs e)
    {
        
        Picker? p = sender as Picker;
        if (p != null) {
            theme = (Theme)p.SelectedIndex;};
        
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();
            switch (theme)
            {
                case Theme.Dark:
                    mergedDictionaries.Add(new DarkTheme());
                    break;
                case Theme.Light:
                default:
                    mergedDictionaries.Add(new LightTheme());
                    break;
            }
        }
        Application.Current.MainPage = new NavigationPage(new AppShell());
    }

    private async void Lehte_avamine(object? sender, EventArgs e)
    {
        Button btn = (Button)sender;
		await Navigation.PushAsync(lehed[btn.ZIndex]);
    }
}