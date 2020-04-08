using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Aspectos.MediatR
{
    internal class MediatrInvocationContext<TResponse> : IInvocationContext
    {
        private readonly object _request;
        private readonly CancellationToken _cancellationToken;
        private readonly RequestHandlerDelegate<TResponse> _next;
        private TResponse _response;

        public MediatrInvocationContext(object request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _request = request;
            _cancellationToken = cancellationToken;
            _next = next;
        }

        public object Instance => throw new NotImplementedException();

        public async Task InvokeAsync() => _response = await _next();

        public CancellationToken CancellationToken => _cancellationToken;

        public object ReturnValue => _response;

        public IEnumerable<IArgument> Arguments => throw new NotImplementedException();

        public MethodInfo Method => throw new NotImplementedException();

        public IEnumerable<IState> PreStates => throw new NotImplementedException();

        public IEnumerable<IState> PostStates => throw new NotImplementedException();
    }
}
