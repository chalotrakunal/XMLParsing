using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SampleProjectRADONC
{
   public class JsonReporter:Reporter
    {
        public string DateTime { get; set; }
        public string HostName { get; set; }
        public string UserId { get; set; }
        public string Version { get; set; }
        public string TestCaseResults { get; set; }
        public string TestCaseResult { get; set; }
        public string TestCaseName { get; set; }
        public string TestStepResults { get; set; }
        public string TestStepResult { get; set; }
        public override void Report(string path)
        {
            Reporter Jsonreport = new JsonReporter()
            {
                DateTime = testRunObj.GetDateTime(),
                HostName = testRunObj.GetHostName(),
                UserId = testRunObj.UserId(),
                Version = "N/A",
            };
            string json = JsonConvert.SerializeObject(Jsonreport, Formatting.Indented);
            Console.WriteLine("Data Written to Json File");
            System.IO.File.WriteAllText(path+("filejson.json"), json);
        }
    }
}
