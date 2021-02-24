using System;
using System.Runtime.Serialization;

namespace Aspectos.Attributes
{
    [Serializable]
    public class AspectAttributeException : Exception
    {
        internal AspectAttributeException(string message, Type aspectType)
            : base(GetMessage(message, aspectType)) { }

        internal AspectAttributeException(string message, Type aspectType, Exception inner)
            : base(GetMessage(message, aspectType), inner) { }

        protected AspectAttributeException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        private static string GetMessage(string message, Type type)
        {
            return message + Environment.NewLine + "Type: " + type.Name;
        }
    }
}
