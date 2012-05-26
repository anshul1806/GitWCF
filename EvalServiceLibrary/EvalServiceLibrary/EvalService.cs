using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace EvalServiceLibrary
{
   [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class EvalService :IEval
    {
        public List<Eval> evals=  new List<Eval>();
       
        public void SetEval(Eval eval)
        {
            evals.Add(eval);
        }
        public List<Eval> GetEval()
        {
            return evals;
        }
    }
}
