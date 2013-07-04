//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
namespace Mite
{
    internal interface IWebAdapter
    {
        string SendGetRequest(string url);
        string SendPostRequest(string url);
        string SendPostRequest(string url, string data);
        string SendPutRequest(string url, string data);
        string SendDeleteRequest(string url);
    }
}