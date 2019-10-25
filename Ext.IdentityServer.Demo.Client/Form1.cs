using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ext.IdentityServer.Demo.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static async Task<DiscoveryDocumentResponse> GetDiscoveryDocument()
        {
            using (var client = new HttpClient())
            {
                var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5050");
                if (disco.IsError)
                {
                    throw new Exception(disco.Error);
                }

                return disco;
            }

        }
        private static async Task<TokenResponse> Login(string username, string password)
        {
            var client = new HttpClient();
            var disco = await GetDiscoveryDocument();

            // request token
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "ro.client",
                ClientSecret = "secret",

                UserName = username,
                Password = password,
                Scope = "backend.api"
            });

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }

            return tokenResponse;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Merhaba");
                Task<TokenResponse> task = Task.Run<TokenResponse>(async () => await Login(txtUserName.Text, txtPassword.Text));
                txtAccessToken.Text = task.Result.AccessToken;
                return;

            }
            catch (Exception exception)
            {
                txtAccessToken.Text = "Error: " + exception.InnerException.Message;
            }
        }
    }
}
