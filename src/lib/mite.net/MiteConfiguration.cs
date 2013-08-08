//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Configuration;
using System.Net;

namespace Mite
{
    /// <summary>
    /// Configuration for data context
    /// </summary>
    public class MiteConfiguration
    {
        internal static MiteConfiguration CurrentConfiguration
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <value>The API key.</value>
        public string ApiKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user used for API access.
        /// </summary>
        /// <value>The user.</value>
        public string User
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password used for API access.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get;
            set;
        }

        private Uri _domain;

        /// <summary>
        /// Gets or sets the sub domain.
        /// </summary>
        /// <value>The sub domain.</value>
        public Uri Domain
        {
            get
            {
                return _domain;
            }
            set
            {
                ValidateUriScheme(value);
                _domain = value;
            }
        }

        private static void ValidateUriScheme(Uri uri)
        {
            switch ( uri.Scheme.ToUpperInvariant() )
            {
                case "HTTP":
                    throw new ArgumentException("mite is not accepting HTTP requests any more. See http://blog.yo.lk/en/2012/02/21/securing-mite-https-only", "uri");
                case "HTTPS":
                    break;
                default:
                    throw new ArgumentException("Invalid uri scheme was specified", "uri");
            }
        }

        /// <summary>
        /// Gets or sets the proxy.
        /// </summary>
        /// <value>The proxy.</value>
        public IWebProxy Proxy { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MiteConfiguration"/> class.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="apiKey">The API key.</param>
        public MiteConfiguration(Uri domain, string apiKey)
        {
            Domain = domain;
            ApiKey = apiKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MiteConfiguration"/> class.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        public MiteConfiguration(Uri domain, string user, string password)
        {
            Domain = domain;
            User = user;
            Password = password;
        }

        /// <summary>
        /// Reads the configuration from the app.config or web.config.
        /// </summary>
        /// <returns></returns>
        public static MiteConfiguration ReadFromConfig()
        {
            MiteConfiguration miteConfiguration = new MiteConfiguration(new Uri(ConfigurationManager.AppSettings["mite.url"]),
                                                            ConfigurationManager.AppSettings["mite.apikey"]);

            return miteConfiguration;
        }
    }
}