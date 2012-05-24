using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldService
{
    [ServiceContract]
    public interface IHelloService
    {
       [OperationContract]
       String HelloWorld(HelloData helloMsg);
    }
    
    [DataContract]
    public class HelloData
    {
        [DataMember]
        public String Fname;
        [DataMember]
        public String Lname;
    }
}
