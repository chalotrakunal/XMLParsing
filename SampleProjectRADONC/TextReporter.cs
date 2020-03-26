using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SampleProjectRADONC
{
    class TextReporter:Reporter
    {
        public override void Report(string path)
        {
            
            StringBuilder sb = new StringBuilder();
            var tesCaseResults = testRunObj.GetListofTestCaseResults().GetTestCaseResults();
            string testrun1 = "TestRun";
            sb.Append(testrun1);
            sb.AppendLine("\n");
            sb.Append("\t" + "Date&Time:" + testRunObj.GetDateTime());
            sb.AppendLine("\n");
            sb.Append("\t" + "HostName:" + testRunObj.GetHostName());
            sb.AppendLine("\n");
            sb.Append("\t" + "Date&Time:" + testRunObj.UserId());
            sb.AppendLine("\n");
            sb.Append("\t" + "\t" + "\t" + "TestCaseResults");
            sb.AppendLine("\n");
            foreach (var testCaseResult in tesCaseResults)
            {
                sb.Append("\t" + "\t" + "\t" + "\t" + "TestCaseResult");
                sb.AppendLine("\n");
                sb.Append("\t" + "\t" + "\t" + "\t" + "TestCaseName" + "\t" + testCaseResult.getTestCaseName());
                sb.AppendLine("\n");
                sb.Append("\t" + "\t" + "\t" + "\t" + "TestStepResults");
                sb.AppendLine("\n");
                foreach (var testStepresult in testCaseResult.GetAllTestStepResults().GetTestStepResults())
                {
                    sb.Append("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "TestStepResult");
                    sb.AppendLine("\n");
                    sb.Append("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "Description :" + "\t" + testStepresult.GetDescription());
                    sb.AppendLine("\n");
                    sb.Append("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "Passed :" + "\t" + testStepresult.IsPassed());
                    sb.AppendLine("\n");
                }
            }
            Console.WriteLine("Data Written to Text file");
            using (var sw1 = new StreamWriter(path+("fileText.text"), true))
            {
                if (new FileInfo(path+("fileText.text")).Length == 0)
                {
                    sw1.Write(sb.ToString());    
                }  
            }
        }
    }
}
