using System;
using System.Collections.Generic;

namespace Aspectos
{
    public interface IMethodLogBuilder
    {
        void AddArguments(IEnumerable<IArgument> arguments);
        void AddPreStates(IEnumerable<IState>  states);
        void AddPostStates(IEnumerable<IState> states);
        void SetException(Exception ex);
        void SetReturnValue(object returnValue);
        void Write();
    }
}