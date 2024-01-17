using Wumble.Model;

namespace Wumble
{
    public partial class MainPage : ContentPage
    {


        Database db = new Database();
        public MainPage()
        {
            InitializeComponent();
        }


        public async void login_clicked(object sender, EventArgs e)
        {
            var userWithCredentials = await db.FindUser(Username.Text, Password.Text);
            if (userWithCredentials != null)
            {

                 await Navigation.PushAsync(new ProfilePage(userWithCredentials.Id));
            }
        }

        public async void signup_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }
    }
}