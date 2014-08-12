using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC_loader
{
    class SystemInfo
    {
        internal static PROCESSORState X;//系统类型
        internal static string LauncherPath = @"\versions\" + "1.6.4-Forge9.11.1.965" + @"\";
        internal static string syspath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)+"\\";
        //获取系统路径
        public string getSystemVersion()
        {
            //获取系统信息
            System.OperatingSystem osInfo = System.Environment.OSVersion;
            //获取操作系统ID
            System.PlatformID platformID = osInfo.Platform;
            //获取主版本号
            int versionMajor = osInfo.Version.Major;
            //获取副版本号
            int versionMinor = osInfo.Version.Minor;
            switch (versionMajor)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    if (versionMinor == 0)
                    {
                        return "win2k";
                    }
                    return "winxp";
                case 6:
                    switch (versionMinor)
                    {
                        case 0:
                            return "vista";
                        case 1:
                            return "win7";
                        case 2:
                            return "win8";
                        case 3:
                            return "win8.1";
                    }
                    return "未知版本";
                default:
                    return "未知版本";
            }
        }
        internal static bool CheckFile(string FilePath)
        {
            return File.Exists(FilePath);
        }
        //鉴别文件是否存在
        
        public enum JavaState : byte
        {
            None = 0,
            X64 = 1,
            X86 = 2
        }

        /// <summary>
        /// 系统类型
        /// </summary>
        public enum PROCESSORState : byte
        {
            Err = 0,
            X64 = 64,
            X86 = 32
        }
 
        /// <summary>
        /// 判断进程
        /// </summary>
        /// <returns>返回位数</returns>
        public  PROCESSORState CheckSystemVer()
        {
            if (IntPtr.Size == 8)
            {
                // 64bit
                return PROCESSORState.X64;
            }
            else if (IntPtr.Size == 4)
            {
                // 32bit
                return PROCESSORState.X86;
            }
            else
            {
                //判断异常
                return PROCESSORState.Err;
            }

        }



        /// <summary>
        /// 判断java版本
        /// </summary>
        /// <returns></returns>
        public  JavaState CheckJava()
        {
            PROCESSORState x = X;
            switch (x)
            {
                case PROCESSORState.Err:
                    if (CheckFile(syspath + @"Java\jre7\bin\java.exe"))
                    {
                        return JavaState.X86;
                    }
                    break;

                case PROCESSORState.X64:
                    if (CheckFile(syspath + @"Java\jre7\bin\java.exe"))
                    {
                        if (CheckFile(syspath + @"Java\jre7\bin\java.exe"))
                        {
                            return (JavaState.None | JavaState.X64 | JavaState.X86);
                        }
                        return JavaState.X64;
                    }
                    if (CheckFile(syspath + @"Java\jre7\bin\java.exe"))
                    {
                        return JavaState.X86;
                    }
                    break;

                default:
                    if ((x == PROCESSORState.X86) && CheckFile(syspath + @"Java\jre7\bin\java.exe"))
                    {
                        return JavaState.X86;
                    }
                    break;
            }
            var result = MessageBox.Show("未发现任何版本的java，仅支持java7及以上版本的java\r\n是否跳转至java下载页面？",
                "未找到java",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Process.Start("http://www.java.com/zh_CN/download/manual.jsp");
            }
            return JavaState.None;
        }


        
    }
}
