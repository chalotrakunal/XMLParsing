using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace SampleProjectRADONC
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = string.Empty;
            TextFileRead filereadinput = new TextFileRead();
            filereadinput.ReadFileContent("C:\\RadOnc\\Input.txt");
            string fileContentInput = filereadinput.GetTextFileContent().ToLower();
           // Console.WriteLine(fileContentInput);
            Parser parser;
            if (fileContentInput == "xml")
            {
                parser = new XmlParser();
                inputFileName = "C:\\TestRun.xml";
            }
            else
            {
                parser = new JsonParser();
                inputFileName = "C:\\RadOnc\\JsonReport.json";                
            }
            parser.ReadDetails(inputFileName);
            ReportHelper helper = new ReportHelper();
            var testRun = parser.GetTestRun();
            helper.SetData(testRun);
            helper.FailedResults();
            var obj = helper.GetFailedResults();
            Dictionary<String, Reporter> dictoutput = new Dictionary<string, Reporter>();
            dictoutput.Add("json", new JsonReporter());
            dictoutput.Add("text", new TextReporter());
            dictoutput.Add("xml", new XmlReporter());
            foreach (var item in dictoutput)
                item.Value.SetReportData(obj);
            TextFileRead filereadoutput = new TextFileRead();
            filereadoutput.ReadFileContent("C:\\RadOnc\\TextDoc.txt");
            string fileContent = filereadoutput.GetTextFileContent().ToLower();
            string[] words = fileContent.Split('#');
            if (words.Length==0)
                Console.WriteLine("File content is Null please enter the text");
            else
            {
                foreach (var word in words)
                {
                    var check = word.Trim();
                    if (dictoutput.ContainsKey(check))
                    {
                        var object1 = dictoutput[check];
                        object1.Report("C:\\RadOnc\\FileStore\\");
                    }
                }
            }
        }
    }
}
