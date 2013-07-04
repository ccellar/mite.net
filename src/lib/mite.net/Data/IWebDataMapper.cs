//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
namespace Mite
{
    internal interface IWebDataMapper
    {
        IWebAdapter WebAdapter { get; set; }
    }
}