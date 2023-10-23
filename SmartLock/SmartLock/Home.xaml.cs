using SmartLock.Model;
using SmartLock.ViewModel;
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
    }
}