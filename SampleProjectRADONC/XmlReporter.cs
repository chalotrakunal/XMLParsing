using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SampleProjectRADONC
{
    class XmlReporter:Reporter
    {
        private XmlDocument docxml = new XmlDocument();
        public override void Report(string path)
        {
           
            var DateTime1 = testRunObj.GetDateTime();
            var HostName1 = testRunObj.GetHostName();
            var userId1 = testRunObj.UserId();
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("TestRun");
            xmlDoc.AppendChild(rootNode);
            XmlNode userNode = xmlDoc.CreateElement("DateTime");
            userNode.InnerText = DateTime1;
            rootNode.AppendChild(userNode);
            userNode = xmlDoc.CreateElement("HostName");
            userNode.InnerText = HostName1;
            rootNode.AppendChild(userNode);
            userNode = xmlDoc.CreateElement("UserID");
            userNode.InnerText = userId1;
            rootNode.AppendChild(userNode);
            userNode = xmlDoc.CreateElement("version");
            rootNode.AppendChild(userNode);
            XmlElement XmlElementTestCaseResults = xmlDoc.CreateElement("TestCaseResults");
            XmlElement xmlElementTestStepResults = xmlDoc.CreateElement("TestStepResults");
            XmlElement xmlElementTestCaseResult = xmlDoc.CreateElement("TestCaseResult");
            xmlElementTestCaseResult.AppendChild(xmlElementTestStepResults);
            var Printxml = testRunObj;
            TestCaseResults testCaseResult = testRunObj.GetListofTestCaseResults();
            var testCaseResults = testCaseResult.GetTestCaseResults();
            foreach (var testCaseresult in testCaseResults)
            {
                TestStepResults teststepresult = new TestStepResults();
                var teststepresults = testCaseresult.GetAllTestStepResults();
                userNode = xmlDoc.CreateElement("TestCaseName");
                userNode.InnerText = testCaseresult.getTestCaseName();
                xmlElementTestCaseResult.AppendChild(userNode);
                userNode = xmlDoc.CreateElement("TestCaseHash");
                userNode.InnerText = "N/A";
                xmlElementTestCaseResult.AppendChild(userNode);
                foreach (var testCaseresult1 in teststepresults.GetTestStepResults())
                {
                    XmlElement xmlElementTestStepResult = xmlDoc.CreateElement("TestStepResult");
                    userNode = xmlDoc.CreateElement("LogBeginLine");
                    userNode.InnerText = null;
                    xmlElementTestStepResult.AppendChild(userNode);
                    userNode = xmlDoc.CreateElement("Description");
                    userNode.InnerText = testCaseresult1.GetDescription();
                    xmlElementTestStepResult.AppendChild(userNode);
                    userNode = xmlDoc.CreateElement("Expected");
                    userNode.InnerText = "N/A";
                    xmlElementTestStepResult.AppendChild(userNode);
                    userNode = xmlDoc.CreateElement("Actual");
                    userNode.InnerText = "N/A";
                    xmlElementTestStepResult.AppendChild(userNode);
                    userNode = xmlDoc.CreateElement("Attachment");
                    xmlElementTestStepResult.AppendChild(userNode);
                    userNode = xmlDoc.CreateElement("Passed");
                    var fail = testCaseresult1.IsPassed();
                    userNode.InnerText = Convert.ToString(fail);
                    xmlElementTestStepResult.AppendChild(userNode);
                    userNode = xmlDoc.CreateElement("LogEndLine");
                    userNode.InnerText = "N/A";
                    xmlElementTestStepResult.AppendChild(userNode);
                    xmlElementTestStepResults.AppendChild(xmlElementTestStepResult);
                }
                XmlElementTestCaseResults.AppendChild(xmlElementTestCaseResult);
                rootNode.AppendChild(XmlElementTestCaseResults);
            }
            XmlElementTestCaseResults.AppendChild(xmlElementTestCaseResult);
            Console.WriteLine("Data Written to Xml file ");
            xmlDoc.Save(path+("Filexml.xml"));
        }
       
    }
}
