using Xamarin.Forms;

namespace Demo.Shared.UI
{
    internal class LoginPage : ContentPage
    {
        public LoginPage()
        {
            var user = new Editor() { BackgroundColor = Color.Black };
            var password = new Editor() { BackgroundColor = Color.Black };

            var loginButton = new Button() { Text = "Logar" };
            loginButton.Clicked += async (sender, args) =>
            {
                await DisplayAlert("Login", string.Format("Olá {0}", user.Text), "OK");

                await Navigation.PushAsync(new MainPage());
            };

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = {
                    new Label() {  Text = "Email:"},
                    user,
                    new Label() {  Text = "Senha:"},
                    password,
                   loginButton
                }
            };
        }

    }
}