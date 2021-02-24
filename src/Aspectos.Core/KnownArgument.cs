using System.Reflection;

namespace Aspectos
{
    public class KnownArgument : IArgument
    {
        public static KnownArgument Create(ParameterInfo parameter, object value)
        {
            return new KnownArgument(parameter, value);
        }

        public KnownArgument(ParameterInfo parameter, object value)
        {
            Parameter = parameter;
            Value = value;
        }

        public ParameterInfo Parameter { get; }

        public object Value;

        public object GetValue() => Value;
    }
}
