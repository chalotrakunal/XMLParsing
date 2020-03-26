using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SampleProjectRADONC
{
    class ParseXml
    {
        XmlDocument docxml = new XmlDocument();
        private XmlNode timeDate;
        private XmlNode hostName;
        private XmlNode userId;
        XmlNodeList testCases;
        XmlNode descrptionOfTestStepResult;
        string description;
        string testCaseMainName;
        public int testPass, testFail, testCaseCount, teststepResultFailedCount;
      
        List<int> failedTestStepResultCount= new List<int>();
        List<string> testStepResultdiscription = new List<string>();
        List<string> mainTestCaseName = new List<string>();
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
            foreach (XmlNode node in testCases)                         // iterating over no of testcases
            {
                XmlNode node1 = node.SelectSingleNode("TestStepResults");  // selecting the partical node containg TestStepResults
                int countOfPassedNode = 0;
                teststepResultFailedCount = 0;
                XmlNode testCaseName = node.SelectSingleNode("TestCaseName");
                List<String> testcase = new List<String>();            // creating list which stores the True or fail value as per according to subtestcases               
                foreach (XmlNode childnode in node1.ChildNodes)  // loop over chilnodes having passed node
                {   
                    XmlNode pass1 = childnode.SelectSingleNode("Passed");
                    descrptionOfTestStepResult = childnode.SelectSingleNode("Description");
                    string trueOrFalse=(pass1.InnerText);
                    testcase.Add(pass1.InnerText);                // adding Passed value to list as strings
                    countOfPassedNode++;                                // will count the total no of subtestcases in testcases
                    if(trueOrFalse =="False")
                    {  
                        teststepResultFailedCount++;
                        description=descrptionOfTestStepResult.InnerText;
                        testCaseMainName = testCaseName.InnerText;
                        testStepResultdiscription.Add(description);
                    }
                }
                mainTestCaseName.Add(testCaseMainName);
                failedTestStepResultCount.Add(teststepResultFailedCount);
                int flag = 0;                           // flag used for checking if all the subtestcases are True
                foreach (var abc in testcase)           //iterating over list 
                {
                    if (abc.Equals("True"))
                        flag++;
                }
                if (countOfPassedNode == flag)     //comparing whether all the subtest cases are passed with have true value
                    testPass++;
                else                      // else it will fail here
                    testFail++;
            }
        }
        public void DisplayResults()
        {
            Console.WriteLine("Host Name :" + hostName.InnerText);      // Print on Hostname.
            Console.WriteLine("Executed Date and Time :" + timeDate.InnerText);  // Print on console DateTime.
            Console.WriteLine("Executed by userID :" + userId.InnerText);          // print UserId.
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("Results: ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("Total Number of Testcases:" + testCaseCount);    // print testCaseCount.
            Console.WriteLine("Total Number of Testcases Passed:" + testPass + "/" +testCaseCount);  // print the total no of test cases passed.
            Console.WriteLine("Total Number of Testcases Failed:" + testFail + "/" +testCaseCount);  // print Total Number of Testcases Failed.

            //Console.WriteLine(mainTestCaseName.Count+" " +teststepResultFailedCount+" "+mainTestCaseName.Count);
            //foreach (string testCaseName in mainTestCaseName)
            //{
            //    Console.WriteLine("Name of main test case: " + testCaseName);
            //}
            //foreach (string discription in testStepResultdiscription)
            //{
            //    Console.WriteLine("Discription of test step result: " + discription);
            //}
            //foreach (int count in failedTestStepResultCount)
            //{
            //    Console.WriteLine("No of test step result failed: " + count);
            //}
        }
        class ExecutXml
        {
            static void Main(string[] args)
            {
                ParseXml document = new ParseXml();
                document.ReadXmlDetails();   // calling ReadXmlDetails. 
                document.XmlComputeLogic();  // callimg XmlReadingLogic.
                document.DisplayResults();      // calling DisplayXml.
            }
        }

    }
}