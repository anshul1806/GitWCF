using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace HelloWorldService
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class EvaluationService :IEvals
    {
        List<Eval> allevals =  new List<Eval>();
        public List<Eval> GetEvals()
        {
            return allevals;
        }

        public void AddEval(Eval eval)
        {
            allevals.Add(eval);
        }

        public List<Eval> GetEvalsById(string id)
        {
            return allevals.FindAll(x=>x.Submitter.Contains(id));
        }
    }
}
