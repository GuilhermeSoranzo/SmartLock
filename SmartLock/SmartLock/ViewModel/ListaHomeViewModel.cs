using SmartLock.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SmartLock.ViewModel
{
    public class ListaHomeViewModel
    {
        public ObservableCollection<Fechadura> FoodList { get; set; }

        public ListaHomeViewModel()
        {


            FoodList = new ObservableCollection<Fechadura>();
            FoodList.Add(new Fechadura { Name = "Entrada - Frente", Estado = "Fechada", Color="red"});
            FoodList.Add(new Fechadura { Name = "Entrada - Fundo", Estado = "Aberto", Color="green"});
            FoodList.Add(new Fechadura { Name = "Quarto - Fundo", Estado = "Aberto", Color="green"});

        }
    }
}
