using System;
using System.Collections.Generic;
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

        public string MethodName => "Handle";

        public async Task InvokeAsync() => _response = await _next();

        public object ReturnValue => _response;

        public IEnumerable<IArgument> Arguments => throw new NotImplementedException();

        public IEnumerable<IArgument> Extra => throw new NotImplementedException();

        public CancellationToken CancellationToken => _cancellationToken;
    }
}
