using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShopperClassLib;
namespace Module2_DynamicObjectResolutionViaReflection
{
    public class Resolver
    {
        // credit card to for ex master card or visa type map
        Dictionary<Type, Type> resolverMap = new Dictionary<Type, Type>();
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type typeToResolve)
        {
            Type resolvedType = null;
            try
            {
                resolvedType = resolverMap[typeToResolve];
            }
            catch
            {
                throw new Exception(String.Format("coundn't not resolved type {0}", typeToResolve.FullName));
            }
            // resovle each of the types now; 
            var firstConstructor = resolvedType.GetConstructors().First();
            var constructorParameters = firstConstructor.GetParameters();
            if (constructorParameters.Count() == 0) // simplest case
            {
                return Activator.CreateInstance(resolvedType);
            }
            IList<object> parameters = new List<object>();
            foreach (var paramterToResolve in constructorParameters)
            {
                parameters.Add(Resolve(paramterToResolve.ParameterType));
            }
            return firstConstructor.Invoke(parameters.ToArray());
        }

        internal void Register<Tfrom, TTo>()
        {
            resolverMap.Add(typeof(Tfrom),typeof(TTo));
        }
    }

}
