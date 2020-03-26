using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SampleProjectRADONC
{
    class Test1
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\xml_sample.xml");
            
            // if you have the xml in a string use doc.LoadXml(stringvar)
            XmlNamespaceManager nsmngr = new XmlNamespaceManager(doc.NameTable);
            XmlNodeList results = doc.DocumentElement.SelectNodes("TestCaseResults", nsmngr);
            foreach (XmlNode result in results)
            {
                XmlNode namenode = result.SelectSingleNode("name");
                XmlNodeList types = result.SelectNodes("type");
                foreach (XmlNode type in types)
                {
                    Console.WriteLine(type.InnerText);
                }
                XmlNode fmtaddress = result.SelectSingleNode("formatted_address");
            }

            
            
        }
    }
}
