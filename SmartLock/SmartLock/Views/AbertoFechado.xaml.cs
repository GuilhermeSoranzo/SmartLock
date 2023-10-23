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
            await btn_mymatches_mainmenu.ScaleTo(0.75, 100);
            await btn_mymatches_mainmenu.ScaleTo(1, 100);

            var conexao = new ConexaoESPSmartLock();
            conexao.RequestToEsp();
        }
    }
}