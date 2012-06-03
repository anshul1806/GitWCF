using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataLibrary
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public String Name;
        [DataMember]
        public String Type;
        [DataMember]
        public DateTime UpdateTime;
        [DataMember]
        public String Comments;
    }
}
