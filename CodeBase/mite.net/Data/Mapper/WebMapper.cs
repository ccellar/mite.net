//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------

namespace Mite
{
    internal abstract class WebMapper : IWebDataMapper
    {
        public IWebAdapter WebAdapter
        {
            get;
            set;
        }
    }
}