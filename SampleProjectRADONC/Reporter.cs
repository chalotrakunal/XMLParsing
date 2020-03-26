using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectRADONC
{
    public class Reporter
    {
        protected TestRun testRunObj;
        public void SetReportData(TestRun testRun)
        {
            testRunObj = testRun;
        }
        public virtual void Report(string path)
        {
            
        }
    }
}
