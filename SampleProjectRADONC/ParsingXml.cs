using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectRADONC
{
        public class TestStepResult
        {
            private string _description;
            private bool _passed;
            public TestStepResult(string desc, bool passed)
            {
                _description = desc;
                _passed = passed;
            }
            public string GetDescription()
            {
                return _description;
            }
            public bool IsPassed()
            {
                return _passed;
            }
        }
       public class TestStepResults
        {
            private List<TestStepResult> _results;
            public TestStepResults()
            {
              _results = new List<TestStepResult>();
            }
            public void Add(TestStepResult result)
            {
              _results.Add(result);
            }
        }
       public class TestCaseResult
       {
            private string _testCaseName;
            private TestStepResults _referTestStepResults;
            public TestCaseResult(string name)
            { 
               _testCaseName = name;
               _referTestStepResults = new TestStepResults();
            }
            public string getTestCaseName()
            {
               return _testCaseName;
            }
            public void Add(TestStepResults testStepResults)
            {
              _referTestStepResults = testStepResults;
            }
       }
        public class TestCaseResults
        {
        
            private List<TestCaseResult> _result;
            public TestCaseResults()
            {
                  _result = new List<TestCaseResult>();
            }
            public void Add(TestCaseResult result)
            {
               _result.Add(result);
            }
        }
        public class TestRun
        {
            private string _dateTime;
            private string _hostname;
            private string _userId;
            private TestCaseResults _resultRefernce;
            public TestRun(string DateTime, string HostName, string UserId)
            {
              _dateTime = DateTime;
              _hostname = HostName;
              _userId = UserId;
              _resultRefernce = new TestCaseResults();
            }
            public string GetDateTime()
            {
               return _dateTime;
            }
            public string GetHostName()
            {
               return _hostname;
            }
            public string UserId()
            {
               return _userId;
            }
            public void Add(TestCaseResults results)
            {
              _resultRefernce = results;
            }
        }
        class ExecutionOfXml
        {
            static void Main(string[] args)
            {
            var tc1Step1 = new TestStepResult("Test step 1", true);
            var tc2step2 = new TestStepResult("Test step 2", false);
            var tc3step3 = new TestStepResult("Test step 3", true);
           
            TestStepResults results = new TestStepResults();
            results.Add(tc1Step1);
            results.Add(tc2step2);
            results.Add(tc3step3);

            TestCaseResult caseresult = new TestCaseResult("a sample description");

            TestCaseResults caseresults = new TestCaseResults();

            TestRun run = new TestRun("25/2/2020","RETRER2134","12345");

        }
    }

    
}
