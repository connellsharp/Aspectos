using System;
using System.Collections.Generic;
using System.Reflection;

namespace Aspectos.DynamicProxy.Tests
{
    internal class TestLogBuilder : IMethodLogBuilder
    {
        public TestLogBuilder(MethodInfo methodInfo)
        {
        }

        public ICollection<string> Lines { get; } = new List<string>();

        private void WriteLine(string line) => Console.WriteLine(line);

        public void AddArguments(IEnumerable<IArgument> arguments)
        {
            WriteLine("Arguments:");

            foreach(var argument in arguments)
            {
                WriteLine($"    {argument.Parameter.Name}: {argument.GetValue()}");
            }
        }

        public void AddPostStates(IEnumerable<IState> states)
        {
            WriteLine("Post states:");

            foreach(var state in states)
            {
                WriteLine($"    {state.Key}: {state.GetValue()}");
            }
        }

        public void AddPreStates(IEnumerable<IState> states)
        {
            WriteLine("Pre states:");

            foreach(var state in states)
            {
                WriteLine($"    {state.Key}: {state.GetValue()}");
            }
        }

        public void SetException(Exception ex)
        {
            WriteLine("Exception:");
            WriteLine($"    {ex.GetType().Name}");
            WriteLine($"    {ex.Message}");
        }

        public void SetReturnValue(object returnValue)
        {
            WriteLine("Return value:");
            WriteLine($"    {returnValue}");
        }

        public void Write()
        {
        }
    }
}
