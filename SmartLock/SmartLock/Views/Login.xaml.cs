using SmartLock.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartLock
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void ButtonClickedAsync(object sender, EventArgs e)
        {
            ServiceDBUser database = new ServiceDBUser(App.DbPath);
            if (database.AutorizarLogin(login.Text, senha.Text))
            {
                await Navigation.PushAsync(new Home());
            }
            else
            {
                DisplayAlert("Resultado", "Usuário não encontrado!", "OK");
            }
        }

        private void ClickedCadastro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastro());
        }
    }
}