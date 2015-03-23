﻿using Fullstack.Core.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Configuration;
using System.Web.Http;

namespace Fullstack.Web {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            var config = new HttpConfiguration();

            new WebApiConfig(config)
                .RegisterRoutes()
                .ConfigureFormatters();

            ConfigureTokenGenerator(app);
            ConfigureTokenConsumer(app);

            app.UseWebApi(config);
        }

        public void ConfigureTokenGenerator(IAppBuilder app) {
            app.CreatePerOwinContext<UserManager>(() => new UserManagerBuilder().Build());

            var OAuthServerOptions = new OAuthAuthorizationServerOptions() {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat("http://localhost:9015")
            };            

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);

        }

        private void ConfigureTokenConsumer(IAppBuilder app) {

            var issuer = "http://localhost:9015";
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });
        }

    }
}
