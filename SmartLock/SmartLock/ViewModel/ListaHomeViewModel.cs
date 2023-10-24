using SmartLock.Model;
using SmartLock.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SmartLock.ViewModel
{
    public class ListaHomeViewModel
    {
        public ObservableCollection<Fechadura> Fechaduras { get; set; }

        public ListaHomeViewModel()
        {
            ServiceDBFechaduras database = new ServiceDBFechaduras(App.DbPath);

            Fechaduras = new ObservableCollection<Fechadura>(database.ListarFechaduras());

            //Fechaduras.Add(new Fechadura { Name = "Entrada - Frente", Estado = "Fechada", Color="red"});
            //Fechaduras.Add(new Fechadura { Name = "Entrada - Fundo", Estado = "Aberto", Color="green"});
            //Fechaduras.Add(new Fechadura { Name = "Quarto - Fundo", Estado = "Aberto", Color="green"});

        }
    }
}
