using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectRADONC
{
    class ReportHelper
    {
        private TestRun _testRunFailed, FailedObj, testrun;
        public TestRun SetData(TestRun obj)
        {
            testrun = obj;
            return testrun;
        }
        public TestRun GetFailedResults()
        {
            FailedObj = _testRunFailed;
            return FailedObj;
        }
        private TestRun GetFailedTestRunObj(List<TestCaseResult> failedTestCases)
        {
            _testRunFailed = new TestRun("13:23:34 3-3-2020", "INGHTBGFTR", "sdr01");
            TestCaseResults testCaseResults = new TestCaseResults();
            foreach (var testcase in failedTestCases)
            {
                TestCaseResult testcaseRes = new TestCaseResult(testcase.getTestCaseName());
                TestStepResults testStepResults = new TestStepResults();
                foreach (var testStepResult in testcase.GetAllTestStepResults().GetTestStepResults())
                {
                    bool isPassed = testStepResult.IsPassed();
                    if (!isPassed)
                    {
                        testStepResults.Add(testStepResult);
                    }
                }
                testcaseRes.Add(testStepResults);
                testCaseResults.Add(testcaseRes);
            }
            _testRunFailed.Add(testCaseResults);
            return _testRunFailed;
        }
        public void FailedResults()
        {
            var failedTestCases = GetAllFailedTestCases();
            GetFailedTestRunObj(failedTestCases);
        }
        private int GetPassedTestCases(List<TestCaseResult> failedTestCases)
        {
            var totalTestCases = testrun.GetListofTestCaseResults().GetTestCaseResults().Count;
            return totalTestCases - failedTestCases.Count;
        }
        public List<TestCaseResult> GetAllFailedTestCases()
        {
            var failedTestResults = new List<TestCaseResult>();

            var listofTestCaseResults = testrun.GetListofTestCaseResults();
            foreach (var testCaseResult in listofTestCaseResults.GetTestCaseResults())
            {
                var result = testCaseResult.IsAllTestStepResultsPassed();
                if (!result)
                {
                    failedTestResults.Add(testCaseResult);
                }
            }
            return failedTestResults;
        }
    }
}
