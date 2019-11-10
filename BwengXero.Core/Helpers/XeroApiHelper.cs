using BwengXero.Core.Stores;
using System;
using System.Configuration;
using Xero.Api.Core;
using Xero.Api.Example.Applications.Public;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Serialization;

namespace BwengXero.Core
{
    public class XeroApiSetting
    {
        public string BaseApiUrl { get; set; }
        public Consumer Consumer { get; set; }
        public object Authenticator { get; set; }
    }

    public static class XeroApiHelper
    {
        private static XeroApiSetting _setting;

        static XeroApiHelper()
        {
            var memoryStore = new MemoryAccessTokenStore();
            var requestTokenStore = new MemoryRequestTokenStore();

            // These values will be read from Web.config first, then the defined value here
            var callbackUrl = ConfigurationManager.AppSettings["XeroApiCallBackUrl"] ?? "https://localhost:44393/Home/Authorize";
            var baseApiUrl = ConfigurationManager.AppSettings["XeroApiBaseUrl"] ?? "https://api.xero.com";
            // create different appSettings key if the tokenUrl different than baseApiUrl 
            var tokenUrl = ConfigurationManager.AppSettings["XeroApiBaseUrl"] ?? "https://api.xero.com";

            // Consumer details for Application
            var consumerKey = ConfigurationManager.AppSettings["XeroApiKey"] ?? "GLB7BJIYVFPMUFHGNBFM4RZMBUOH2F";
            var consumerSecret = ConfigurationManager.AppSettings["XeroApiSecret"] ?? "U1KBRVTA262PETIWFBUF8IOSH47OSJ";

            // Signing certificate details for Partner Applications
            //var signingCertificatePath = @"C:\Dev\your_public_privatekey.pfx";
            //var signingCertificatePassword = "Your_signing_cert_password - leave empty if you didn't set one when creating the cert";

            // Public Application Settings
            var publicConsumer = new Consumer(consumerKey, consumerSecret);

            var publicAuthenticator = new PublicMvcAuthenticator(baseApiUrl, tokenUrl, callbackUrl, memoryStore, publicConsumer, requestTokenStore);

            var publicApplicationSettings = new XeroApiSetting
            {
                BaseApiUrl = baseApiUrl,
                Consumer = publicConsumer,
                Authenticator = publicAuthenticator
            };

            // Partner Application Settings
            //var partnerConsumer = new Consumer(consumerKey, consumerSecret);

            //var partnerAuthenticator = new PartnerMvcAuthenticator(baseApiUrl, baseApiUrl, callbackUrl,
            //        memoryStore, signingCertificatePath, 
            //        partnerConsumer, requestTokenStore, signingCertificatePassword);

            //var partnerApplicationSettings = new ApplicationSettings
            //{
            //    BaseApiUrl = baseApiUrl,
            //    Consumer = partnerConsumer,
            //    Authenticator = partnerAuthenticator
            //};

            // Pick one
            // Choose what sort of application is appropriate. Comment out the above code (Partner Application Settings/Public Application Settings) that are not used.

            _setting = publicApplicationSettings;
            //_applicationSettings = partnerApplicationSettings;
        }

        public static ApiUser User()
        {
            return new ApiUser { Name = Environment.MachineName };
        }

        public static IConsumer Consumer()
        {
            return _setting.Consumer;
        }

        public static IMvcAuthenticator MvcAuthenticator()
        {
            return (IMvcAuthenticator)_setting.Authenticator;
        }

        public static IXeroCoreApi CoreApi()
        {
            if (_setting.Authenticator is IAuthenticator)
            {
                return new XeroCoreApi(_setting.BaseApiUrl, _setting.Authenticator as IAuthenticator, _setting.Consumer, User(), new DefaultMapper(), new DefaultMapper());
            }

            return null;
        }
    }
}
