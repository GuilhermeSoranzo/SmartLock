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
        }

        private async void ButtonClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home());
        }

        private void ClickedCadastro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastro());
        }
    }
}