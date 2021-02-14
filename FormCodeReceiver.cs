using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch_Uploader
{
    public partial class FormCodeReceiver : Form, ICodeReceiver
    {
        Uri URL;
        string Token;
        public FormCodeReceiver()
        {
            InitializeComponent();
            Show();
            Hide();
        }

        public string RedirectUri => GoogleAuthConsts.InstalledAppRedirectUri;

        public async Task<AuthorizationCodeResponseUrl> ReceiveCodeAsync(AuthorizationCodeRequestUrl Url, CancellationToken CancellationToken)
        {
            URL = Url.Build();

            BeginInvoke(new MethodInvoker(() => {
                tbURL.Text = URL.AbsoluteUri;
                ShowDialog();
            }));

            while (string.IsNullOrWhiteSpace(Token))
                await Task.Delay(100);

            return new AuthorizationCodeResponseUrl { Code = Token };
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Token = tbCode.Text;
            Close();
        }
    }
}
