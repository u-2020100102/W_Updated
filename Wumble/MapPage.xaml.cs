namespace Wumble;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
		// For now, we will be using only one location

		InitializeComponent();
		webView.Source = "https://www.bing.com/maps?cp=41.085154%7E29.045104&lvl=22.0"; 

    }
}