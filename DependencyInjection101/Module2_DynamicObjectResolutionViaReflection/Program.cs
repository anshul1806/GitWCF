using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopperClassLib;

namespace Module2_DynamicObjectResolutionViaReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Resolver resolver = new Resolver();
            resolver.Register<Shopper, Shopper>();
            resolver.Register<ICreditCard, Mastercard>();
            var shopper = resolver.Resolve<Shopper>();
            shopper.Charge();
            Console.Read();
        }
    }
}
