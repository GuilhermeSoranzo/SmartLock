using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                //await conexao.RequestToEsp("off");
                ConectBluetoothEspAsync();
                textoAbertoFechado.Text = "Fechado";
                textoAbertoFechado.TextColor = Color.Red;
                textoDesbloquearBlock.Text = "Pressione para desbloquear";
                btnImagem.Source = "FechaduraClosed.PNG";
            }
            else if(textoAbertoFechado.Text == "Fechado")
            {
                var conexao = new ConexaoESPSmartLock();
                //await conexao.RequestToEsp("on");
                ConectBluetoothEspAsync();
                textoAbertoFechado.Text = "Aberto";
                textoAbertoFechado.TextColor = Color.Green;
                textoDesbloquearBlock.Text = "Pressione para bloquear";
                btnImagem.Source = "FechaduraOpen.png";
            }
        }

        private async void ConectBluetoothEspAsync()
        {
            var ble = CrossBluetoothLE.Current;
            var adapter = CrossBluetoothLE.Current.Adapter;
            List<IDevice> deviceList = new List<IDevice>();

            adapter.DeviceDiscovered += (s, a) => deviceList.Add(a.Device);
            await adapter.StartScanningForDevicesAsync();

            try
            {
                await adapter.ConnectToDeviceAsync(deviceList.FirstOrDefault());
                var connectedDevice = adapter.ConnectedDevices.FirstOrDefault();
                var services = await connectedDevice.GetServicesAsync();
                var characteristics = await services.FirstOrDefault().GetCharacteristicsAsync();
                byte[] bytes = Encoding.ASCII.GetBytes("on");
                await characteristics.FirstOrDefault().WriteAsync(bytes);
            }
            catch (DeviceConnectionException e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}