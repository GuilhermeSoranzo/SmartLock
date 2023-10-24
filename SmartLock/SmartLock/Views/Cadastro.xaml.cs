using SmartLock.Model;
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
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());

            User newUser = new User();
            newUser.Email = email.Text;
            newUser.Senha = senha.Text;

            if (ValidateData())
            {
                ServiceDBUser database = new ServiceDBUser(App.DbPath);
                database.Inserir(newUser);
                DisplayAlert("Resultado", database.StatusMessage, "OK");
            }
        }

        private bool ValidateData()
        {
            if (!email.Text.Contains("@"))
                throw new Exception("E-mail incorreto!");
            else if (!email.Text.Contains(".com"))
                throw new Exception("E-mail incorreto!");
            else if (!senha.Text.Equals(confirmarSenha.Text))
                throw new Exception("Senhas não correspondem!");

            return true;
        }
    }
}