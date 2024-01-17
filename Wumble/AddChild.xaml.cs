using Wumble.Model;

namespace Wumble;

public partial class AddChild : ContentPage
{
    Database db = new Database();
    User loggedUser;
    public AddChild(User user)
    {
        InitializeComponent();
        loggedUser = user;
    }


    public void AddChild_ButtonClicked(object sender, EventArgs e)
    {
        AddChild_Clicked();
    }


    public async Task AddChild_Clicked()
    {
        var child = await db.GetChildByID(Int32.Parse(Child.Text));
        loggedUser.Children = loggedUser.Children + child.Id;
        await db.Update(loggedUser);
        await Navigation.PushAsync(new ProfilePage(loggedUser.Id));
    }
}