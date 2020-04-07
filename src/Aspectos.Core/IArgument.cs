using System;
using System.Reflection;

namespace Aspectos
{
    public interface IArgument
    {
        ParameterInfo Parameter { get; }

        object GetValue();
    }
}