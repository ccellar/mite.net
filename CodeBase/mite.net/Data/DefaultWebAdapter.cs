//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace Mite
{
    /// <summary>
    /// Base class of all mite connectors
    /// </summary>
    internal class DefaultWebAdapter : IWebAdapter
    {
        private static string _userAgent;

        //--------------------------------------------------------------------------
        /// <summary>
        /// Sends a HTTP get request.
        /// </summary>
        /// <param name="url">The url to which the request is send.</param>
        /// <returns>The response.</returns>
        public string SendGetRequest(string url)
        {
            Trace.Assert(!string.IsNullOrEmpty(url));
            Trace.WriteLine("Start GetRequest");

            HttpWebRequest request = CreateRequest(url);
            request.Method = "GET";

            // Get response  
            using ( HttpWebResponse response = (HttpWebResponse)request.GetResponse() )
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string answer = reader.ReadToEnd();

                Trace.WriteLine(answer);

                Trace.WriteLine("End GetRequest");

                return answer;
            }
        }

        private static HttpWebRequest CreateRequest(string url)
        {
            string requestUrl = MiteConfiguration.CurrentConfiguration.Domain + url;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);

            if (MiteConfiguration.CurrentConfiguration.Proxy != null)
            {
                request.Proxy = MiteConfiguration.CurrentConfiguration.Proxy;
            }

            request.UserAgent = UserAgent;

            if ( !string.IsNullOrEmpty(MiteConfiguration.CurrentConfiguration.ApiKey) )
            {
                request.Headers.Add("X-MiteApiKey", MiteConfiguration.CurrentConfiguration.ApiKey);
            }
            else
            {
                request.Credentials = new NetworkCredential
                {
                    UserName = MiteConfiguration.CurrentConfiguration.User,
                    Password = MiteConfiguration.CurrentConfiguration.Password
                };
            }

            request.ContentType = "application/xml";

            return request;
        }

        protected static string UserAgent
        {
            get
            {
                if ( string.IsNullOrEmpty(_userAgent) )
                {
                    string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    string product = "mite.net";
                    string host = Environment.OSVersion.VersionString;

                    _userAgent = string.Format(CultureInfo.InvariantCulture, "{0}/{1} ({2})", product, version, host);
                }

                return _userAgent;
            }
        }

        //--------------------------------------------------------------------------
        /// <summary>
        /// Sends a HTTP post request.
        /// </summary>
        /// <param name="url">The url to which the request is send.</param>
        /// <param name="data">The data which is posted.</param>
        /// <returns>The response.</returns>
        public string SendPostRequest(string url, string data)
        {
            try
            {
                HttpWebRequest request = CreateRequest(url);
                request.Method = "POST";
                request.ContentType = "application/xml";

                byte[] byteData = Encoding.UTF8.GetBytes(data);
                request.ContentLength = byteData.Length;

                using ( Stream postStream = request.GetRequestStream() )
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                // Get response  
                using ( HttpWebResponse response = (HttpWebResponse)request.GetResponse() )
                {
                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    string res = reader.ReadToEnd();

                    Trace.WriteLine(res);

                    Trace.WriteLine("End PostRequest");

                    return res;
                }
            }
            catch ( WebException webException )
            {
                StreamReader reader = new StreamReader(webException.Response.GetResponseStream());
                string res = reader.ReadToEnd();

                throw MiteException.CreateFromResponse(res, webException);
            }
        }

        //--------------------------------------------------------------------------
        /// <summary>
        /// Sends a HTTP post request.
        /// </summary>
        /// <param name="url">The url to which the request is send.</param>
        /// <returns>The response.</returns>
        public string SendPostRequest(string url)
        {
            HttpWebRequest request = CreateRequest(url);

            request.Method = "POST";
            request.ContentLength = 0;

            // Get response  
            using ( HttpWebResponse response = (HttpWebResponse) request.GetResponse() )
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string res = reader.ReadToEnd();

                Trace.WriteLine(res);

                Trace.WriteLine("End PostRequest");

                return res;
            }
        }

        //--------------------------------------------------------------------------
        /// <summary>
        /// Sends a put request.
        /// </summary>
        /// <param name="url">The url to which the request is send.</param>
        /// <param name="data">The data which is put.</param>
        /// <returns>The response.</returns>
        public string SendPutRequest(string url, string data)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = CreateRequest(url);

            request.Method = "PUT";
            request.ContentLength = byteData.Length;

            using ( Stream putStream = request.GetRequestStream() )
            {
                putStream.Write(byteData, 0, byteData.Length);
            }

            try
            {
                // Get response  
                using ( HttpWebResponse response = (HttpWebResponse) request.GetResponse() )
                {
                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    string res = reader.ReadToEnd();

                    Trace.WriteLine(res);

                    Trace.WriteLine("End PutRequest");

                    return res;
                }
            }
            catch ( WebException exception )
            {
                StreamReader reader = new StreamReader(exception.Response.GetResponseStream());
                string res = reader.ReadToEnd();

                throw MiteException.CreateFromResponse(res, exception);
            }
        }

        //--------------------------------------------------------------------------
        /// <summary>
        /// Sends a HTTP delete request.
        /// </summary>
        /// <param name="url">The url to which the request is send.</param>
        /// <returns>The response.</returns>
        public string SendDeleteRequest(string url)
        {
            HttpWebRequest request = CreateRequest(url);
            request.Method = "DELETE";

            using ( HttpWebResponse response = (HttpWebResponse) request.GetResponse() )
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string answer = reader.ReadToEnd();

                Trace.WriteLine(answer);

                Trace.WriteLine("End DeleteRequest");

                return answer;
            }
        }
    }
}