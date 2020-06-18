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
            TestCaseResults retTestCaseResults = new TestCaseResults();
            XmlNodeList testCaseResults = docxml.SelectNodes("//TestRun/TestCaseResults/TestCaseResult");
            foreach(XmlNode node in testCaseResults)
            {
                TestCaseResult res = GetTestCaseResult(node);
                retTestCaseResults.Add(res);
            }
            return retTestCaseResults;
        }
        private TestCaseResult GetTestCaseResult(XmlNode node)
        {
            string testCaseName = node.SelectSingleNode("TestCaseName").InnerText;
            TestCaseResult retTestCaseResult = new TestCaseResult(testCaseName);
            XmlNode testStepResultsXml = node.SelectSingleNode("TestStepResults");
            TestStepResults res = GetListOfTestStepResult(testStepResultsXml);
            retTestCaseResult.Add(res);
            return retTestCaseResult;
        }
        private TestStepResults GetListOfTestStepResult(XmlNode node)
        {
            TestStepResults listOfTestStepResult = new TestStepResults();
            XmlNodeList testStepResultNodes = node.ChildNodes;
            foreach(XmlNode resNode in testStepResultNodes)
            {
                string desc = resNode.SelectSingleNode("Description").InnerText;
                string passed = resNode.SelectSingleNode("Passed").InnerText;
                bool val = (passed == "True") ? true : false;
                TestStepResult testStepResult = new TestStepResult(desc, val);
                listOfTestStepResult.Add(testStepResult);
            }
            return listOfTestStepResult;
        }

        
    }
}