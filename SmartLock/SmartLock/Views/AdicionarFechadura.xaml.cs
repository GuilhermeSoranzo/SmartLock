using SmartLock.Model;
using SmartLock.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartLock.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdicionarFechadura : ContentPage
    {
        public AdicionarFechadura()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public AdicionarFechadura(long Id, string nam, string descric)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            nome.Text = nam;
            descricao.Text = descric;
            idFechadura.Text = Id.ToString();
        }

        private void ButtonClickedAsync(object sender, EventArgs e)
        {
            ServiceDBFechaduras database = new ServiceDBFechaduras(App.DbPath);
            Fechadura fechadura = new Fechadura();
            var id = idFechadura.Text;
            fechadura.Name = nome.Text;
            fechadura.Description = descricao.Text;
            if (id == null)
                database.Inserir(fechadura);
            else
            {
                fechadura.Id = Convert.ToInt32(id);
                database.Alterar(fechadura);
            }

            Navigation.PushAsync(new Home());
        }
    }
}