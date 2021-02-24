using System;
using System.Collections.Generic;
using System.Reflection;

namespace Aspectos.DynamicProxy.Tests
{
    internal class TestLogger : IMethodLogger
    {
        public TestLogger()
        {
            Lines = new List<string>();
            LineWriter = new TestLineWriter(Lines);
        }

        public ICollection<string> Lines { get; }
        
        public ILineWriter LineWriter { get; }

        public IMethodLogBuilder Create(MethodInfo methodInfo)
        {
            return new TestLogBuilder(LineWriter, methodInfo);
        }

        private class TestLineWriter : ILineWriter
        {
            private ICollection<string> _lines;

            public TestLineWriter(ICollection<string> lines)
            {
                _lines = lines;
            }

            public void WriteLine(string line)
            {
                Console.WriteLine(line);
                _lines.Add(line);
            }
        }
    }
}
