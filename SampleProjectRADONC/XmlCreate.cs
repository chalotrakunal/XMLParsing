using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SampleProjectRADONC
{
    class XmlCreate
    {
        public void RunXmlFunction()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("TestRun");
            xmlDoc.AppendChild(rootNode);  
            XmlNode userNode = xmlDoc.CreateElement("DateTime");
            userNode.InnerText = "2020-3-3 12:23:34";
            rootNode.AppendChild(userNode);
            userNode = xmlDoc.CreateElement("HostName");
            userNode.InnerText = "INBDGRERFERE";
            rootNode.AppendChild(userNode);
            userNode = xmlDoc.CreateElement("UserID");
            userNode.InnerText = "ing1234";
            rootNode.AppendChild(userNode);
            userNode = xmlDoc.CreateElement("version");
            rootNode.AppendChild(userNode);
            userNode = xmlDoc.CreateElement("TestCaseResults");
            userNode = xmlDoc.CreateElement("TestCaseResult");
            userNode.InnerText = null;
            rootNode.AppendChild(userNode);
            userNode = xmlDoc.CreateElement("TestCaseResult");
            userNode.InnerText = null;
            rootNode.AppendChild(userNode);
            rootNode.AppendChild(userNode);
            xmlDoc.Save("test-doc.xml");
        }

        static void Main(string[] args)
        {
            XmlCreate obj = new XmlCreate();
            obj.RunXmlFunction();
        }
    }
}
