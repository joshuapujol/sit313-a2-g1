using System;
using System.Collections.Generic;
using System.Text;

namespace SIT313A2
{
    public class AppAuthenParameters
    {
        // Used as a unique identifier for storage on user devices
        public static string AppName = "SIT313A2";
        // Unique ID - leave as a permanent variable
        public static string AndroidClientId = "328235103549-ksb2egpk7a498lljo4obcl9mmlgh9eij.apps.googleusercontent.com";
        // Pointers to API actions
        public static string Scope = "https://www.googleapis.com/auth/userinfo.email";
        public static string AuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
        public static string AccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
        public static string UserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";
        public static string AndroidRedirectUrl = "com.googleusercontent.apps.328235103549-ksb2egpk7a498lljo4obcl9mmlgh9eij:/oauth2redirect";
    }
}
