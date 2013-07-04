//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace Mite
{
    internal interface IEntityConverter<T>
    {
        string Convert(T item);
        T Convert(string data);
        IList<T> ConvertToList(string data);
    }
}