using System.Reflection;

namespace Aspectos.DynamicProxy
{
    internal class Argument : IArgument
    {
        public static Argument Create(ParameterInfo parameter, object value)
        {
            return new Argument(parameter, value);
        }

        public Argument(ParameterInfo parameter, object value)
        {
            Parameter = parameter;
            Value = value;
        }

        public ParameterInfo Parameter { get; }

        public object Value;

        public object GetValue() => Value;
    }
}
