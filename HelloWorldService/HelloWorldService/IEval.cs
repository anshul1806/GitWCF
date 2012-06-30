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
    public interface IEvals
    {
        [OperationContract]
        List<Eval> GetEvals();
        [OperationContract]
        void AddEval(Eval eval);
        [OperationContract]
        List<Eval> GetEvalsById(String id);
    }

    [DataContract]
    public class Eval
    {
        [DataMember]
        public String Submitter;
        [DataMember]
        public String Comments;

    }
}
