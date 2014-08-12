using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MC_loader
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            SystemInfo si = new SystemInfo();
            label6.Text += si.getSystemVersion();
            label4.Text += si.CheckSystemVer().ToString();
            label5.Text += si.CheckJava().ToString();
        }
            

        private void button1_Click(object sender, EventArgs e)
        {
            string gameName = textBox1.Text;
            string memory = textBox2.Text;
            JSON js = new JSON();
            js.aaaaaaaa();
          
        }

        

    }
}
