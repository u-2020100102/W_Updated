using Wumble.Model;

namespace Wumble;

public partial class SignupPage : ContentPage
{
    Database db = new Database();
	public SignupPage()
	{
		InitializeComponent();
	}

   
    public async void Signupnow_clicked(object sender, EventArgs e)
    {
        Random r = new Random();
        int n = r.Next();
        var user = new User()
        {
            Name = Username.Text,
            Email = Email.Text,
            Password = Password.Text,
            Permission = Picker.SelectedIndex == 0 ? "Parent" : "Child",
            IdentityNumber = n,
            longitude = 0,
            latitude = 0,
        };

        Console.WriteLine(user);

        await db.AddUser(user);
        await Navigation.PushAsync(new MainPage());

    }
}