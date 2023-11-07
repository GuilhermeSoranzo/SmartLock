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

            var s3 = new AmazonS3Client("ASIA2IVKB6WV5W6BH36V", "Hra2l6IN0CfssdlUlwB2HXOrVfjqJPrVZn/osyVr", "FwoGZXIvYXdzEOD//////////wEaDLVkOOCfaMG5HeHKUiK+AaJQ+iHmRfBC8Raikr0jNKrdEvRwu6/Xj97SfW168Rjc6Q5V4UKgaqsuQQHf45HXhVBowfM0NCZHs2HmGGCq+ID/Xo0nhSlHu2pHjap56ck7vdjtb0CdQ3awGgA5Nx57WkpKQFUGdmnGTjbKifHNBMb1viGkl40KuAm5k3N43Enre9qzmvfSHRR3KTmpPjw/poy8w2hVt6qhg+3FKi6AQNPXcEBwNxrmi6gYUPEuLw6PMzghbCyxjmFHLv5+eyYosIaGqgYyLfpyZHIJjB4reUyn0PI0h9IjFZDum7UuFmU9zR+YhnWIU6y6TXxzvVRLDAeWdQ==", Amazon.RegionEndpoint.USEast1);

            var fileTransferUtil = new TransferUtility(s3);
            string dbName = "dbSmartLock.db3";
            string dbPath = GetLocalFilePath(dbName);
            var filePath = dbPath;

            //var fileTransferUtilityRequest = new TransferUtilityUploadRequest
            //{
            //    BucketName = "xamarian-smart-lock",
            //    FilePath = filePath,
            //    StorageClass = S3StorageClass.StandardInfrequentAccess,
            //    PartSize = 6291456,
            //    Key = "teste-imagem",
            //    CannedACL = S3CannedACL.PublicRead
            //};

            //await fileTransferUtil.UploadAsync(fileTransferUtilityRequest);

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

        public static string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
        }
    }
}