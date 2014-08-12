using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace MC_loader
{
    class JSON
    {

        private string getjson()
        {
            StringBuilder str = new StringBuilder();
            str.Append("");
            string path = System.Environment.CurrentDirectory + "\\1.6.4-Forge9.11.1.965.json";
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader m_streamReader = new StreamReader(fs);
            str.Append(m_streamReader.ReadToEnd());
            m_streamReader.Close();
            m_streamReader.Dispose();
            fs.Close();
            fs.Dispose();
            return str.ToString();
        } 
        
        public void aaaaaaaa()
        {
            string str = getjson();
            JsonReader readerjson = new JsonTextReader(new StringReader(str));
            while(readerjson.Read())
            {
                Console.WriteLine(readerjson.Value);
            }

        }
    }
}
