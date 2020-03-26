using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace SampleProjectRadOnc
{
    class TestResult
    {
        XmlDocument docxml = new XmlDocument();
        XmlNode timeDate;
        XmlNode hostName;
        XmlNode userId;
        XmlNodeList testCases;
        
        public int testPass, testFail, testCaseCount;


        public void ReadXmlDetails()
        {
            docxml.Load("C:\\TestRun.xml");         // loading xml from a path
            timeDate = docxml.SelectSingleNode("//TestRun/DateTime");    // extract Date&Time
            hostName = docxml.SelectSingleNode("//TestRun/HostName");    // extract HostName
            userId = docxml.SelectSingleNode("//TestRun/UserId");        // extract user_ID
            testCases = docxml.DocumentElement.SelectNodes("//TestRun/TestCaseResults/TestCaseResult");
        }
        public void XmlComputeLogic()
        {
            testCaseCount = testCases.Count;
            testPass = 0;
            testFail = 0;
            foreach (XmlNode testCase in testCases)                         // iterating over no of testcases.
            {
                var testStepResults = testCase.SelectSingleNode("TestStepResults");  // selecting the partical node containg TestStepResults.
                int flag = 0;
                //int testStepFailed = 0;
                foreach (XmlNode testStepResult in testStepResults.ChildNodes)  // loop over chilnodes having passed node.
                {
                    XmlNode nodeValue = testStepResult.SelectSingleNode("Passed");
                    string fg = nodeValue.InnerText;
                    //Console.WriteLine("fg value is" +fg);
                    if (fg == "False")
                    {
                        testFail++;
                        break;
                    }
                    else
                        flag = 1;                              // will count the total no of subtestcases in testcases.
                }
                if (flag == 1)
                   testPass++;
            }
            //if (testFail != 0)
            //{
            //    /*var testStepResults = testCase.SelectSingleNode("TestStepResults");
            //    foreach (XmlNode childnode in testStepResults.ChildNodes)  // loop over chilnodes having passed node.
            //    {

            //        XmlNode nodeValue = childnode.SelectSingleNode("Passed");
            //        string fg = nodeValue.InnerText;
            //    }*/
            //}
            
        }
        public void DisplayResults()
        {
            Console.WriteLine("Host Name :" + hostName.InnerText);      // Print on Hostname.
            Console.WriteLine("Executed Date and Time :" +timeDate.InnerText);  // Print on console DateTime.
            Console.WriteLine("Executed by userID :" +userId.InnerText);          // print UserId.
            Console.WriteLine("Results: ");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("Total Number of Testcases:" + testCaseCount);    // print testCaseCount.
            Console.WriteLine("Total Number of Testcases Passed:" + testPass + "/" + testCaseCount);  // print the total no of test cases passed.
            Console.WriteLine("Total Number of Testcases Failed:" + testFail+"/"+testCaseCount);  // print Total Number of Testcases Failed.

        }
        class ExecutXml
        {
             static void Main(string[] args)
             {
                TestResult document = new TestResult();
                document.ReadXmlDetails();   // calling ReadXmlDetails. 
                document.XmlComputeLogic();  // callimg XmlReadingLogic.
                document.DisplayResults();      // calling DisplayXml.
             }
        }
        
    }
}
