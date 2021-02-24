using System;

namespace Aspectos.Attributes
{
    public class AspectAttribute : Attribute, IAspectProvider
    {
        public AspectAttribute(Type aspectType)
        {
            if(!typeof(IAspect).IsAssignableFrom(aspectType))
                throw new AspectAttributeException("The type used in AspectAttribute must inherit the IAspect interface.", aspectType);
            
            if(aspectType.GetConstructor(new Type[0]) == null)
                throw new AspectAttributeException("The type used in AspectAttribute must have a parameterless constructor.", aspectType);

            AspectType = aspectType;
        }

        public Type AspectType { get; }

        public IAspect GetAspect() => (IAspect)Activator.CreateInstance(AspectType);
    }
}
