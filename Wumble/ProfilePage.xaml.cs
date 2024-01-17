using Wumble.Model;
using static System.Net.Mime.MediaTypeNames;

namespace Wumble;

public partial class ProfilePage : ContentPage
{

    Database db = new Database();
    User loggedUser;
    public int userId;
    public ProfilePage(int id)
    {
        InitializeComponent();
        userId = id;
        find();
    }

    public async void find()
    {
        loggedUser = await db.GetUserByID(userId);
        nameSurname.Text = loggedUser.Name;
        identityNumber.Text = "Your Identity Number: "  + loggedUser.IdentityNumber.ToString();
        role.Text = "Your role is " + loggedUser.Permission;
        int count = 1;

        foreach (char c in loggedUser.Children)
        {
            var child = await db.GetUserByID(c - '0');
            Button MyControl1 = new Button();
            MyControl1.Text = child.Name;
            MyControl1.Clicked += VisitChild_clicked;

            Grid.SetColumn(MyControl1, 0);
            Grid.SetRow(MyControl1, count);
            ChildrenGrid.Children.Add(MyControl1);

            ChildrenGrid.SetValue(Grid.ColumnProperty, count);
            count++;
        }
    }


    public async void addChild_clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddChild(loggedUser));
    }

    public async void VisitChild_clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MapPage());
    }


}