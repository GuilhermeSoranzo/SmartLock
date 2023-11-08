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

            var s3 = new AmazonS3Client("ASIA2IVKB6WVVQYDL7VB", "dSeg+cct93S9YlQuGaaqgV/qwECKkg/46rVRDkKW", "FwoGZXIvYXdzEHEaDHqZejwrmc6+ekIUliK+AYrw3DTYyz7Dp60dmPGsz0TEmP2nm9bKKg/MYQjQ0DlJvvJLSI51U7HRN5bXPTEQ2MOEHffUiUsLQBf6mGTJv67bpdHbaduRcCmVk7ETTYnDE5FhZgjokGhjT6Z2Z1CFeYJ4GINHaXUf7JkbqiCCKLReARpSZXMbXc1ysecqMPZFPbUtdV4G/if2nzK6gFvWCdMMyEnJWKCUzFG8/oAdH3X+EXwedp2BZPnFMK1oLl5Bm2p4KhIAx+7tZwIWVU4o7+elqgYyLUELLv+aB2FrfIQ8GB3Ns14hhsE0qxykyz/AiaB/SWVu58q7OfNexFPCBP0M0g==", Amazon.RegionEndpoint.USEast1);

            var fileTransferUtil = new TransferUtility(s3);
            string dbName = "dbSmartLock.db3";
            string dbPath = GetLocalFilePath(dbName);
            var filePath = dbPath;

            var fileTransferUtilityRequest = new TransferUtilityUploadRequest
            {
                BucketName = "bucket-smart-lock-senai",
                FilePath = filePath,
                StorageClass = S3StorageClass.StandardInfrequentAccess,
                PartSize = 6291456,
                Key = $"BKP- {login.Text}-{DateTime.Now}",
                CannedACL = S3CannedACL.PublicRead
            };


            ServiceDBUser database = new ServiceDBUser(App.DbPath);
            if (database.AutorizarLogin(login.Text, senha.Text))
            {
                await Navigation.PushAsync(new Home());
                //await fileTransferUtil.UploadAsync(fileTransferUtilityRequest);
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