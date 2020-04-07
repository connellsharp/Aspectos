using System;

namespace Aspectos
{
    public interface IArgument
    {
        string ParamName { get; }

        Type ParamType { get; }

        object GetValue();
    }
}