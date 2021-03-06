﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using TW.Infra.CrossCutting.Identity.Configuration;
using Microsoft.Owin.Security.Facebook;
using System.Threading.Tasks;
using Microsoft.Owin.Security.DataProtection;
using TW.Infra.CrossCutting.Identity.Context;

namespace TW.PetSuite.UI.MVC
{
    public partial class Startup
    {
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }
        private const string XmlSchemaString = "http://www.w3.org/2001/XMLSchema#string";

        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and role manager to use a single instance per request
            //Usar uma única instância por request.
            app.CreatePerOwinContext(IdentityContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/NewLogin"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  

                    //OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                    //    validateInterval: TimeSpan.FromMinutes(30),
                    //    regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))

                    //A cada request. Assim que mudar o securityStamp, ele passa a não valer mais para outras instâncias.
                    OnValidateIdentity = ApplicationCookieIdentityValidator.OnValidateIdentity(
                       validateInterval: TimeSpan.FromMinutes(0),
                       regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            //Se em 5 minutos não confirmar o email por exemplo, não vai funcionar mais
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            //Lembrar qual browser está conectado.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers

            app.UseMicrosoftAccountAuthentication(
                clientId: "SEU ID",
                clientSecret: "SEU TOKEN");

            app.UseTwitterAuthentication(
               consumerKey: "SEU ID",
               consumerSecret: "SEU TOKEN");


            app.UseGoogleAuthentication(
                clientId: "SEU ID",
                clientSecret: "SEU TOKEN");


            var fao = new FacebookAuthenticationOptions
            {
                AppId = "SEU ID",
                AppSecret = "SEU TOKEN"
            };

            fao.Scope.Add("email");
            fao.Scope.Add("publish_actions");
            fao.Scope.Add("basic_info");

            fao.Provider = new FacebookAuthenticationProvider()
            {

                OnAuthenticated = (context) =>
                {
                    context.Identity.AddClaim(new System.Security.Claims.Claim("urn:facebook:access_token", context.AccessToken, XmlSchemaString, "Facebook"));
                    foreach (var x in context.User)
                    {
                        var claimType = string.Format("urn:facebook:{0}", x.Key);
                        string claimValue = x.Value.ToString();
                        if (!context.Identity.HasClaim(claimType, claimValue))
                            context.Identity.AddClaim(new System.Security.Claims.Claim(claimType, claimValue, XmlSchemaString, "Facebook"));

                    }
                    return Task.FromResult(0);
                }
            };

            fao.SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie;
            app.UseFacebookAuthentication(fao);
        }
    }
}