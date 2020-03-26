using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectRADONC
{
    public class TestStepResult                     //done..
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
    public class TestStepResults                // done
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
        public List<TestStepResult> GetTestStepResults()
        {
            return _results;
        }
    }
    public class TestCaseResult                    //done
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
        public TestStepResults GetAllTestStepResults()
        {
            return _referTestStepResults;
        }
        public bool IsAllTestStepResultsPassed()
        {
            bool result = true;
            var listOfTestSteps = _referTestStepResults.GetTestStepResults();
            foreach (var testStepResult in listOfTestSteps)
            {
                result &= testStepResult.IsPassed();
            }
            return result;
        }
    }
    public class TestCaseResults    //done
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
        public List<TestCaseResult> GetTestCaseResults()
        {
            return _result;
        }
        public bool IsAllTestCasesPassed()
        {
            bool result = true;
            foreach (var testCaseResult in _result)
            {
                result &= testCaseResult.IsAllTestStepResultsPassed();
            }
            return result;
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
        public TestCaseResults GetListofTestCaseResults()
        {
            return _resultRefernce;
        }
    }
}
