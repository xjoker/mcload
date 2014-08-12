using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections;
namespace MC_loader
{
    class JSON
    {

        public string lib = "";
        //lib 的命令合集

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

        public void readJSON()
        {
            string str = getjson();
            JsonReader readerjson = new JsonTextReader(new StringReader(str));
            while (readerjson.Read())
            {
                string temp = "";
                //获取目录
                if (readerjson.TokenType.ToString() == "PropertyName" && readerjson.Value.ToString() == "name")
                {
                    string path = readerjson.ReadAsString();

                    bool aa = false;
                    //循环识别行内数据并且转换
                    if (path != "osx")//抛弃osx的判断
                    {
                        foreach (char a in path)
                        {
                            if (a == ':')
                            {
                                //判断是不是读到了带冒号部分
                                //如果是就设置为true
                                temp += '\\';
                                aa = true;
                            }
                            else if (aa)
                            {
                                //读取到冒号后的处理方法
                                temp += a;
                            }
                            else
                            {
                                //没有读取到的方法
                                if (a == '.')
                                {
                                    temp += '\\';
                                }
                                else
                                {
                                    temp += a;
                                }
                            }
                        }
                        temp += '\\';

                        if (temp != "")
                        {
                            string fileTemp = "\\libraries\\" + temp;
                            ArrayList AL = new ArrayList(GetAllFiles(".minecraft"+fileTemp));
                            foreach (Object obj in AL)
                            {
                                if(obj.ToString()!="")
                                {
                                    lib += "." + fileTemp + obj.ToString() + ";";
                                    //把数据填入Lib
                                }
                                
                            }
                        }
                    }
                }

            }

        }

        private Array GetAllFiles(string strpath)
        {
            ArrayList AL=null;
            try
            {
                DirectoryInfo di = new DirectoryInfo(strpath);
                FileInfo[] result = di.GetFiles();
                AL= new ArrayList(result);
                string strExtFilter = ".jar";//需要列出文件的扩展名
                int num = AL.Count;
                int count = 0;
                for (int i = 0; i < result.Length; i++)
                {
                    FileInfo sf = (FileInfo)AL[count];
                    if ((strExtFilter.IndexOf(sf.Extension.ToLower()) == -1) || (sf.Extension == ""))//当前文件的扩展名存在在过滤列表中
                    {
                        AL.Remove(sf);//如果不存在就删去此项
                        count--;
                    }
                    count++;
                }

                return AL.ToArray();
            }
            catch (Exception ex)
            {
                AL = new ArrayList();
                AL.Add("");
                return AL.ToArray();
            }
        }
    }
}
