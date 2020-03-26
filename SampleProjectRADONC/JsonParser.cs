using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectRADONC
{
    class JsonParser:Parser
    {

        public override void ReadDetails(string xmlFileName)
        {
            Parser xml = new XmlParser();
            xml.ReadDetails("C:\\TestRun.xml");
            SetTestRun(xml.GetTestRun());
           
            
        }
    }
}
