//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace Mite
{
    /// <summary>
    /// Exception which wrappes all HTTP-errors of mite (status codes 400 - 500)
    /// </summary>
    [Serializable]
    public class MiteException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MiteException"/> class.
        /// </summary>
        public MiteException()
        {
            Errors = new List<MiteError>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MiteException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public MiteException(string message)
            : base(message)
        {
            Errors = new List<MiteError>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MiteException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public MiteException(string message, Exception innerException)
            : base(message, innerException)
        {
            Errors = new List<MiteError>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MiteException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="info"/> parameter is null.
        /// </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">
        /// The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0).
        /// </exception>
        protected MiteException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Errors = new List<MiteError>();
        }

        /// <summary>
        /// Gets or sets the list of errors.
        /// </summary>
        /// <value>The errors.</value>
        public IList<MiteError> Errors { get; set; }

        internal static MiteException CreateFromResponse(string response, Exception innerException)
        {
            MiteException miteException;

            if (response.StartsWith(@"<?xml version=""1.0"" encoding=""UTF-8""?>"))
            {
                miteException = new MiteException(innerException.Message, innerException);

                XmlDocument xmlDocument = new XmlDocument();

                xmlDocument.LoadXml(response);

                XmlNodeList errorNodes = xmlDocument.SelectNodes("/errors/error");

                foreach (XmlNode errorNode in errorNodes)
                {
                    MiteError miteError = new MiteError(errorNode.InnerText);
                    XmlAttribute propertyAttribute = errorNode.Attributes["on"];

                    if (propertyAttribute != null)
                    {
                        miteError.Property = propertyAttribute.Value;
                    }

                    miteException.Errors.Add(miteError);
                }
            }
            else
            {
                miteException = new MiteException(response, innerException);
            }
            
            return miteException;
        }
    }
}