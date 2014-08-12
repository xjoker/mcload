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
                //获取目录
                if (readerjson.TokenType.ToString() == "PropertyName" && readerjson.Value.ToString() == "name")
                {
                    string path = readerjson.ReadAsString();
                    string temp="";
                    bool aa = false;
                    foreach (char a in path)
                    {
                        if(a==':')
                        {
                            //判断是不是读到了带冒号部分
                            //如果是就设置为true
                            temp += '\\';
                            aa = true;
                        }
                        else if(aa)
                        {
                            //读取到冒号后的处理方法
                            temp += a;
                        }
                        else
                        {
                            //没有读取到的方法
                            if(a=='.')
                            {
                                temp+='\\';
                            }
                            else
                            {
                                temp += a;
                            }
                        }
                    }
                    temp += '\\';
                    Console.WriteLine(temp);
                }
                
            }

        }
    }
}
