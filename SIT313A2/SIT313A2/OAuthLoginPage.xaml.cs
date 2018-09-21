using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Diagnostics;
using Xamarin.Auth;

namespace SIT313A2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OAuthLoginPage : ContentPage
    {
        public OAuthLoginPage()
        {
            Account account;
            AccountStore store;
        }
        public OAuthLoginPage()
        {
            InitializeComponent();
            store = AccountStore.Create();
            account = store.FindAccountsForService(AppAuthenParameters.AppName).FirstOrDefault();
        }
        void OnLoginClicked(object sender, EventArgs e)
        {
            string clientId = AppAuthenParameters.AndroidClientId;
            string redirectUri = AppAuthenParameters.AndroidRedirectUrl;
            var authenticator = new OAuth2Authenticator(clientId, null, AppAuthenParameters.Scope, new Uri(AppAuthenParameters.AuthorizeUrl), new Uri(redirectUri), new Uri(AppAuthenParameters.AccessTokenUrl), null, true);
            AuthenState.Authenticator = authenticator;
            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;
            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
            async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
            {
                var authenticator = sender as OAuth2Authenticator;
                if (authenticator != null)
                {
                    authenticator.Completed -= OnAuthCompleted;
                    authenticator.Error -= OnAuthError;
                }
                UserInfo user = null;
                if (e.IsAuthenticated)
                {
                    var request = new OAuth2Request("GET", new Uri(AppAuthenParameters.UserInfoUrl), null, e.Account);
                    var response = await request.GetResponseAsync();
                    if (response != null)
                    {
                        string userJson = await response.GetResponseTextAsync();
                        user = JsonConvert.DeserializeObject<UserInfo>(userJson);
                    }
                    if (account != null)
                    {
                        store.Delete(account, AppAuthenParameters.AppName);
                    }
                    await store.SaveAsync(account = e.Account, AppAuthenParameters.AppName);
                    await DisplayAlert("Email address", user.Email, "OK");
                }
            }
        }
        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }
            Debug.WriteLine("Authentication error: " + e.Message);
        }
    }
}