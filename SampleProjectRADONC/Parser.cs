using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectRADONC
{
    class Parser
    {
        protected TestRun _testRun;
        public TestRun GetTestRun()
        {
            return _testRun;
        }
        public void SetTestRun(TestRun temp)
        {
            _testRun = temp;
        }
        public virtual void ReadDetails(string xmlFileName)
        {
        }
    }
}
