using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MC_loader
{
    class gameLauncher
    {
        public void StartGame(string gameCMD,int Mem,string gameName)
        {
            try
            {
                string chuan=" -Xmx"+Mem+
                    "m -Djava.library.path=.minecraft\\Native -cp \"" + gameCMD +
                    ".minecraft\\versions\\1.6.4-Forge9.11.1.965\\1.6.4-Forge9.11.1.965.jar\""+
                    " net.minecraft.launchwrapper.Launch"+
                    " --username "+gameName+
                    " --version 1.6.4 --gameDir \".minecraft\" --assetsDir \"E:\\mc2\\.minecraft\\assets\"" +
                    " --tweakClass cpw.mods.fml.common.launcher.FMLTweaker";
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.LoadUserProfile = true;
                Info.FileName = "java.exe";
                Info.Arguments = chuan;
                //Info.WorkingDirectory = @"D:\mcload\mcload\MC_loader\MC_loader\bin\x64\Debug";
                System.Diagnostics.Process Proc;
                try
                {
                    Proc = System.Diagnostics.Process.Start(Info);
                    
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("ERROR");
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("ERROR");
            }
        }
    }
}
