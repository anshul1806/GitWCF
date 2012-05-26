using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EvalServiceLibrary
{
   [DataContract]
    public class Eval
    {
        [DataMember]
        public String Submitter { get; set; }
        [DataMember]
        public String comments { get; set; }
        [DataMember]
        public DateTime TimeSent { get; set; }
    }
}
