using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace SampleProjectRADONC
{
    class XmlParser:Parser
    {        
        private XmlDocument docxml = new XmlDocument();
        public override void ReadDetails(string xmlFileName)
        {
            docxml.Load(xmlFileName);     
            XmlNode timeDate = docxml.SelectSingleNode("//TestRun/DateTime");    
            XmlNode hostName = docxml.SelectSingleNode("//TestRun/HostName");    
            XmlNode userId = docxml.SelectSingleNode("//TestRun/UserId");        
            _testRun = new TestRun(timeDate.InnerText, hostName.InnerText, userId.InnerText);
            var res = GetTestCaseResults();
            _testRun.Add(res);
        }
        private TestCaseResults GetTestCaseResults()
        {
            var retTestCaseResults = new TestCaseResults();
            var testCaseResults = docxml.SelectNodes("//TestRun/TestCaseResults/TestCaseResult");
            foreach(XmlNode node in testCaseResults)
            {
                var res = GetTestCaseResult(node);
                retTestCaseResults.Add(res);
            }
            return retTestCaseResults;
        }
        private TestCaseResult GetTestCaseResult(XmlNode node)
        {
            var testCaseName = node.SelectSingleNode("TestCaseName").InnerText;
            var retTestCaseResult = new TestCaseResult(testCaseName);
            var testStepResultsXml = node.SelectSingleNode("TestStepResults");
            var res = GetListOfTestStepResult(testStepResultsXml);
            retTestCaseResult.Add(res);
            return retTestCaseResult;
        }
        private TestStepResults GetListOfTestStepResult(XmlNode node)
        {
            var listOfTestStepResult = new TestStepResults();
            var testStepResultNodes = node.ChildNodes;
            foreach(XmlNode resNode in testStepResultNodes)
            {
                var desc = resNode.SelectSingleNode("Description").InnerText;
                var passed = resNode.SelectSingleNode("Passed").InnerText;
                var val = (passed == "True") ? true : false;
                var testStepResult = new TestStepResult(desc, val);
                listOfTestStepResult.Add(testStepResult);
            }
            return listOfTestStepResult;
        }

        
    }
}