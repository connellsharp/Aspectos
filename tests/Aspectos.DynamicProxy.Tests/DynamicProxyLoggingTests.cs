using Xunit;
using Castle.DynamicProxy;
using FluentAssertions;

namespace Aspectos.DynamicProxy.Tests
{
    public class DynamicProxyLoggingTests
    {
        [Fact]
        public void ProxiedObjectBehavesTheSameAsNormal()
        {
            TestLogger testLogger = new TestLogger();
            ICalculator calculator = new Calculator();
            Intercept(ref calculator, new LoggingAspect(testLogger));

            var result = calculator.Add(2, 3);

            result.Should().Be(5);
        }
        
        [Fact]
        public void ProxiedObjectLogsReturnValue()
        {
            TestLogger testLogger = new TestLogger();
            ICalculator calculator = new Calculator();
            Intercept(ref calculator, new LoggingAspect(testLogger));

            var result = calculator.Add(2, 3);

            testLogger.Lines.Should().ContainInOrder("Return value:", "    5");
        }

        private void Intercept<T>(ref T obj, params IAspect[] aspects)
            where T : class
        {
            var proxyGenerator = new ProxyGenerator();
            obj = proxyGenerator.CreateProxyWithAspects(obj, aspects);
        }

        public class Calculator : ICalculator
        {
            public int Add(int a, int b)
            {
                return a + b;
            }
        }

        public interface ICalculator
        {
            int Add(int a, int b);
        }
    }
}
