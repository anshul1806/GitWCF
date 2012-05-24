using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldService
{
    public class HelloWorldService :IHelloService
    {
        public string HelloWorld(HelloData msg)
        {
            return String.Format("Hello {0} {1}", msg.Fname, msg.Lname);
        }
    }
}
