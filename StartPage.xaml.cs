namespace TARpv23_MobiileApp;

public partial class StartPage : ContentPage
{
	public List<ContentPage> lehed=new List<ContentPage>() { new TextPage(),new FigurePage()};
	public List<string> tekstid=new List<string>{"Tee lahti TekstPage", "Tee lahti FigurePage"};
	ScrollView sv;
	VerticalStackLayout vsl;
	
	public StartPage()
	{
		Title = "Avaleht";
		
		vsl = new VerticalStackLayout { BackgroundColor = Color.FromRgb(150, 100, 20) };
		for(int i = 0; i < tekstid.Count;i++)
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

    private async void Lehte_avamine(object? sender, EventArgs e)
    {
        Button btn = (Button)sender;
		await Navigation.PushAsync(lehed[btn.ZIndex]);
    }
}