using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectRADONC
{
    class TextFileRead
    {
        private string text;
        public void ReadFileContent(string path)
        {
            try
            {   
                using (StreamReader sr = new StreamReader(path))
                {
                  
                    text = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public string GetTextFileContent()
        {
            return text;
        }
    }
}
