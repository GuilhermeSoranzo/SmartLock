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
        }

        private void ButtonClickedAsync(object sender, EventArgs e)
        {
            ServiceDBFechaduras database = new ServiceDBFechaduras(App.DbPath);
            Fechadura fechadura = new Fechadura();
            fechadura.Name = nome.Text;
            fechadura.Description = descricao.Text;
            database.Inserir(fechadura);
            Navigation.PushAsync(new Home());
        }
    }
}