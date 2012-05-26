using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EvalServiceLibrary
{
   [ServiceContract]
    public interface IEval
    {
        [OperationContract]
        List<Eval> GetEval();
        [OperationContract]
        void SetEval(Eval eval);
    }
}
