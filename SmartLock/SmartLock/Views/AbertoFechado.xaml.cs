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
    public partial class AbertoFechado : ContentPage
    {
        public AbertoFechado()
        {
            InitializeComponent();
            BindingContext = this;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public AbertoFechado(string nomeFechadura)
        {
            InitializeComponent();
            BindingContext = this;
            Titulo.Text = nomeFechadura;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public async void btn_mymatches_mainmenu_Clicked(object sender, EventArgs e)
        {
            await btnImagem.ScaleTo(0.75, 100);
            await btnImagem.ScaleTo(1, 100);

            if(textoAbertoFechado.Text == "Aberto")
            {
                var conexao = new ConexaoESPSmartLock();
                conexao.RequestToEsp("off");
                textoAbertoFechado.Text = "Fechado";
                textoAbertoFechado.TextColor = Color.Red;
                textoDesbloquearBlock.Text = "Pressione para desbloquear";
                btnImagem.Source = "FechaduraClosed.PNG";
            }
            else if(textoAbertoFechado.Text == "Fechado")
            {
                var conexao = new ConexaoESPSmartLock();
                conexao.RequestToEsp("on");
                textoAbertoFechado.Text = "Aberto";
                textoAbertoFechado.TextColor = Color.Green;
                textoDesbloquearBlock.Text = "Pressione para bloquear";
                btnImagem.Source = "FechaduraOpen.png";
            }
        }
    }
}