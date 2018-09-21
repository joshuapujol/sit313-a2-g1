using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SIT313A2.Droid
{
    [Activity(Label = "CustomUrlScemeInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[]
    {
        Intent.ActionView
    },
    categories = new[]
    {
        Intent.CategoryDefault, Intent.CategoryBrowsable
    },
    DataSchemes = new[]
    {
        "com.googleusercontent.apps.328235103549-ksb2egpk7a498lljo4obcl9mmlgh9eij:/oauth2redirect"
    },
    DataPath = "/oauth2redirect")]
    public class CustomUrlSchemeInterceptorActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var uri = new Uri(Intent.Data.ToString());
            AuthenState.Authenticator.OnPageLoading(uri);
            Finish();
        }
    }
}