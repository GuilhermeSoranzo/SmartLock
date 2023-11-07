using SmartLock.Model;
using SmartLock.Service;
using SmartLock.ViewModel;
using SmartLock.Views;
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
    public partial class Home : ContentPage
    {
        ServiceDBFechaduras database = new ServiceDBFechaduras(App.DbPath);

        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ListaHomeViewModel();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;

            // this assumes your List is bound to a List<Club>
            Fechadura fechadura = (Fechadura)lv.SelectedItem;

            Navigation.PushAsync(new AbertoFechado(fechadura.Name));
            
        }

        public void BtnAddFechadura(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdicionarFechadura());
        }

        private void ButtonDelete(object sender, EventArgs e)
        {
            var teste = sender as ImageButton;
            var values = (Fechadura)teste.BindingContext;
            Device.BeginInvokeOnMainThread(async () => {
                var result = await this.DisplayAlert("Alerta!", "Você deseja continuar com a exclusão da fechadura?", "Sim", "Não");
                if (result)
                {
                    database.RemoverFechadura(values.Id);
                    BindingContext = new ListaHomeViewModel();
                }
            });
        }
        
        private void ButtonEdit(object sender, EventArgs e)
        {

        }
    }
}