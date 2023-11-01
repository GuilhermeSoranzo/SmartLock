using Amazon.S3;
using Amazon.S3.Transfer;
using SmartLock.Service;
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
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void ButtonClickedAsync(object sender, EventArgs e)
        {

            var s3 = new AmazonS3Client("ASIA2IVKB6WV5W6BH36V", "Hra2l6IN0CfssdlUlwB2HXOrVfjqJPrVZn/osyVr", "us-east-1");

            var fileTransferUtil = new TransferUtility(s3);
            var filePath = "C://Documentos/download.png";

            var fileTransferUtilityRequest = new TransferUtilityUploadRequest
            {
                BucketName = "xamarian-smart-lock",
                FilePath = filePath,
                StorageClass = S3StorageClass.StandardInfrequentAccess,
                PartSize = 6291456,
                Key = "teste-imagem",
                CannedACL = S3CannedACL.PublicRead
            };

            await fileTransferUtil.UploadAsync(fileTransferUtilityRequest);

            ServiceDBUser database = new ServiceDBUser(App.DbPath);
            if (database.AutorizarLogin(login.Text, senha.Text))
            {
                await Navigation.PushAsync(new Home());
            }
            else
            {
                DisplayAlert("Resultado", "Usuário não encontrado!", "OK");
            }
        }

        private void ClickedCadastro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastro());
        }
    }
}