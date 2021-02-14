using BitlyAPI;
using Dasync.Collections;
using DriveMirror;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch_Uploader
{
    public partial class UploadForm : Form
    {
        static readonly string[] Scopes = {
            DriveService.Scope.Drive,
            DriveService.Scope.DriveAppdata,
            DriveService.Scope.DriveMetadata
        };

        ClientSecrets ApiCredentials;

        UserCredential UserCredentials;


        DriveService Service;

        (string File, string Name)[] Files;

        string CommonName;

        string BitlyApi;

        bool DriveReady = false;
        public UploadForm(string DriveClientID, string DriveClientSecret, string BitlyApi, (string File, string Name)[] Files, string CommonName)
        {
            InitializeComponent();
            
            ApiCredentials = new ClientSecrets();
            ApiCredentials.ClientId = DriveClientID;
            ApiCredentials.ClientSecret = DriveClientSecret;

            this.BitlyApi = BitlyApi;
            this.Files = Files;
            this.CommonName = CommonName;

            var CodeReceiver = Main.Config.PromptMode ? (ICodeReceiver)new FormCodeReceiver() : new LocalServerCodeReceiver();

            GoogleWebAuthorizationBroker.AuthorizeAsync(ApiCredentials, Scopes, "BatchUploader", System.Threading.CancellationToken.None, codeReceiver: CodeReceiver).ContinueWith((Credentials) => {
                DriveReady = true;
                UserCredentials = Credentials.Result;

                Service = new DriveService(new Google.Apis.Services.BaseClientService.Initializer() { 
                    HttpClientInitializer = UserCredentials,
                    ApplicationName = "BatchUploader"
                });
            });
        }

        private async void btnUpload_Clicked(object sender, EventArgs e)
        {
            if (!DriveReady) {
                MessageBox.Show("A API do Drive ainda não inicializou.", "Batch Uploader", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string DriveName = tbPath.Text.Split(':').First();
            string Path = new string(tbPath.Text.Skip(tbPath.Text.IndexOf(':') + 1).ToArray()).Replace("\\", "/");

            btnUpload.Enabled = false;

            Text = "Loading Drives...";

            var Drive = (Drive)(await (from x in Service.EnumDrives() where x.Name.Equals(DriveName, StringComparison.InvariantCultureIgnoreCase) select x).SingleOrNothing());

            var Directory = await Service.GetOrCreateDirectory(Path);

            List<File> DriveFiles = new List<File>();

            tbLinkList.Text = string.Empty;

            foreach (var File in Files) {
                int Tries = 0;
            Retry:;
                Tries++;
                
                if (Tries == 1)
                    Text = $"Uploading {File.Name}...";
                else
                    Text = $"Uploading {File.Name}... (Retry {Tries})";

                using (var Data = new System.IO.StreamReader(File.File).BaseStream)
                {
                    var Result = await Service.UploadFile(Data, File.Name, Directory);
                    if (Result.Progress.Status != Google.Apis.Upload.UploadStatus.Completed)
                        goto Retry;

                    var NewFile = Result.CreatedFile;

                    Text = $"Sharing {File.Name}...";
                    var SharedFile = await Service.ShareFile(NewFile);
                    var SharedLink = SharedFile.WebViewLink;

                    if (!string.IsNullOrWhiteSpace(BitlyApi))
                    {

                        Text = $"Shorting URL...";
                        var Bitly = new Bitly(BitlyApi);
                        SharedLink = await Bitly.PostShortenLink(SharedLink);

                    }

                    string Name = System.IO.Path.GetFileNameWithoutExtension(File.Name);

                    if (Name.StartsWith(CommonName, StringComparison.Ordinal))
                        Name = Name.Substring(CommonName.Length);

                    tbLinkList.Text += $"{Name.Trim()}: {(ckAnon.Checked ? "https://anon.to/?" : "")}{SharedLink}\r\n";
                }
            }

            MessageBox.Show("Upload Finished!", "Batch Uploader", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Text = "Upload";

            btnUpload.Enabled = true;
        }
    }
}
