using System.Linq;
using System.Threading.Tasks;

namespace Aspectos.Attributes
{
    public class AttributesAspect : IAspect
    {
        public Task InvokeAsync(IInvocationContext context)
        {
            return context.Method.GetCustomAttributes(typeof(AspectAttribute), true)
                                       .Cast<IAspectProvider>()
                                       .Select(a => a.GetAspect())
                                       .Flatten()
                                       .InvokeAsync(context);
        }
    }
}
