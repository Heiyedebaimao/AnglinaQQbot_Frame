using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Core.Tokens;
using YamlDotNet.RepresentationModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


namespace StartBot
{
    public partial class QQbot_Form : Form
    {
        public QQbot_Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 启动QQ机器人      
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, EventArgs e)
        {
            try
            {
                using (Process proc = new System.Diagnostics.Process())
                {

                    string local = string.Format(@"D:\1TOOL\QQbot\AngelinaBot-Windows10\AngelinaBot-Windows10");
                    //Process proc = new Process();
                    proc.StartInfo.WorkingDirectory = local;
                    proc.StartInfo.FileName = "D:\\1TOOL\\QQbot\\AngelinaBot-Windows10\\AngelinaBot-Windows10\\start.bat";
                    //proc.StartInfo.Arguments = string.Format("10");//this is argument
                    proc.StartInfo.CreateNoWindow = true;

                    proc.StartInfo.StandardOutputEncoding = Encoding.UTF8;//cmd输出流文本格式
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;//打开流输出
                    proc.StartInfo.RedirectStandardInput = true;//打开流输入
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//这里设置DOS窗口不显示，经实践可行

                    proc.Start();

                    // 异步获取命令行内容  
                    proc.BeginOutputReadLine();
                    //proc.StandardInput.WriteLine("test");
                    // 为异步获取订阅事件  
                    proc.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
                    //proc.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }

        }

        /// <summary>
        /// 指令发送函数
        /// </summary>
        /// <param name="tclCommand"></param>
        private void ExecuteTclCommand(string tclCommand)
        {
            //proc.StandardInput.WriteLine(tclCommand);
            //proc.StandardInput.AutoFlush = true;
        }



        /// <summary>
        /// 打开界面初始化参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] type = { "IPAD", "ANDROID_PAD", "ANDROID_PHONE", "MACOS" };
            F_typeList.Items.AddRange(type);
            F_typeList.SelectedIndex = 0;

            Updateyml();
        }

        /// <summary>
        /// 参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F_Setup_Click(object sender, EventArgs e)
        {
            String filePath = "D:\\1TOOL\\QQbot\\AngelinaBot-Windows10\\AngelinaBot-Windows10\\application.yml";
            Ymlhelper yml = new Ymlhelper(filePath);
            yml.modify("administrators", F_administrators.Text);
            yml.modify("qqList", F_qqList.Text);
            yml.modify("pwList", F_pwList.Text);
            yml.modify("APP_ID", F_APP_ID.Text);
            yml.modify("API_KEY", F_API_KEY.Text);
            yml.modify("SECRET_KEY", F_SECRET_KEY.Text);

            yml.modify("typeList", F_typeList.Text);
            yml.save();
            Updateyml();
        }

        /// <summary>
        /// 读取yml文件设置参数
        /// </summary>
        private void Updateyml()
        {
            String filePath = "D:\\1TOOL\\QQbot\\AngelinaBot-Windows10\\AngelinaBot-Windows10\\application.yml";
            //String filePath = Directory.GetCurrentDirectory() + @"\application.yml";
            Ymlhelper yml = new Ymlhelper(filePath);
            F_administrators.Text = yml.read("administrators");
            F_qqList.Text = yml.read("qqList");
            F_pwList.Text = yml.read("pwList");

            string botname = yml.read("botNames");
            Name_update(botname);

            F_APP_ID.Text = yml.read("APP_ID");
            F_API_KEY.Text = yml.read("API_KEY");
            F_SECRET_KEY.Text = yml.read("SECRET_KEY");
        }


        private void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // 这里仅做输出的示例，实际上可以根据情况取消获取命令行的内容  

            if (String.IsNullOrEmpty(e.Data) == false)
                this.AppendText(e.Data + "\r\n");
        }

        #region 解决多线程下控件访问的问题  

        public delegate void AppendTextCallback(string text);

        public void AppendText(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                AppendTextCallback d = new AppendTextCallback(AppendText);
                this.textBox1.Invoke(d, text);
            }
            else
            {
                this.textBox1.AppendText(text);
            }
        }
        #endregion


        /// <summary>
        /// 程序退出后关闭Jav进程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QQbot_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            //得到所有打开的进程   
            try
            {
                //获得需要杀死的进程名  
                foreach (System.Diagnostics.Process thisproc in System.Diagnostics.Process.GetProcessesByName("Java"))
                {
                    //立即杀死进程
                    thisproc.Kill();
                }
            }
            catch (Exception Exc)
            {
                throw new Exception("", Exc);
            }
            System.Diagnostics.Process.GetCurrentProcess().Kill();


        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReadJson();
        }

        Dictionary<string, Dictionary<Dictionary<string, List<string>>, Dictionary<string, List<string>>>> Dic_Infos = new Dictionary<string, Dictionary<Dictionary<string, List<string>>, Dictionary<string, List<string>>>>();



        string path = @"D:\1TOOL\QQbot\AngelinaBot-Windows10\AngelinaBot-Windows10\chatReplay.json";

        /// <summary>
        /// 读Json文件
        /// </summary>
        private void ReadJson()
        {
            StreamReader SR = File.OpenText(path);
            JsonTextReader JTR = new JsonTextReader(SR);
            JToken JTokens = JToken.ReadFrom(JTR);
            int num = JTokens.Count();
            if (num > 0)
            {
                JToken first = JTokens.First();

                for (int i = 0; i < num; i++)
                {
                    string Name = first.Path.Substring(1, first.Path.Length - 2);

                    //string Name = first.Path.Substring(2, first.Path.Length-3);

                    string keyWords = first.First().ToString();
                    string replay = first.Last().ToString();
                    //replay.Append("1");

                    Dictionary<string, List<StringBuilder>> Dic_Info = JsonConvert.DeserializeObject<Dictionary<string, List<StringBuilder>>>(keyWords);
                    //if (!Dic_Infos.ContainsKey(Name))
                    //{
                    //    Dic_Infos.Add(Name, Dic_Info);
                    //}
                    first = first.Next;
                }
            }
        }

        /// <summary>
        ///写Json文件
        /// </summary>
        private void WriteJson()
        {
            string Json = "{";
            foreach (var item in Dic_Infos)
            {
                Json += "\"" + item.Key + "\":{";
                foreach (var items in item.Value)
                {
                    Json += "\"" + items.Key + "\":" + "\"" + items.Value + "\",";
                }
                Json += "},";
            }
            Json += "}";

            JToken JToken = (JToken)JsonConvert.DeserializeObject(Json);
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(JToken, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, output);
        }

        /// <summary>
        /// 删除杰哥命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F_delete_name_Click(object sender, EventArgs e)
        {
            if (F_Botname.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                //F_Botname.Items.Remove(F_Botname.SelectedIndex);
                String filePath = "D:\\1TOOL\\QQbot\\AngelinaBot-Windows10\\AngelinaBot-Windows10\\application.yml";
                Ymlhelper yml = new Ymlhelper(filePath);
                string name = "";
                for (int i = 0; i < F_Botname.Items.Count; i++)
                {
                    if (i < F_Botname.Items.Count - 1 && i != F_Botname.SelectedIndex)
                        name = name + F_Botname.Items[i] + " ";
                    else if (i < F_Botname.Items.Count && i != F_Botname.SelectedIndex)
                        name = name + F_Botname.Items[i];
                }
                yml.modify("botNames", name);
                yml.save();
                Name_update(yml.read("botNames"));
            }
        }

        /// <summary>
        /// 增加杰哥命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F_insert_name_Click(object sender, EventArgs e)
        {
            if (F_Botname.Text != "")
            {
                String filePath = "D:\\1TOOL\\QQbot\\AngelinaBot-Windows10\\AngelinaBot-Windows10\\application.yml";
                Ymlhelper yml = new Ymlhelper(filePath);
                string name = F_Botname.Text;
                for (int i = 0; i < F_Botname.Items.Count; i++)
                {
                    name = name + " " + F_Botname.Items[i];
                }
                yml.modify("botNames", name);
                yml.save();
                Name_update(yml.read("botNames"));
            }
        }
        /// <summary>
        /// 更新botname
        /// </summary>
        /// <param name="botname"></param>
        private void Name_update(string botname)
        {
            F_Botname.Items.Clear();
            if (botname != "")
            {
                string[] name = botname.Split(' ');
                F_Botname.Items.AddRange(name);
                //F_Botname.SelectedIndex = 0;
            }
        }

        private void F_mm_cansee_CheckedChanged(object sender, EventArgs e)
        {
            if (F_mm_cansee.Checked)
            {
                F_pwList.PasswordChar = '\0';   //显示输入
            }
            else
            {
                F_pwList.PasswordChar = '*';   //显示*
            }
        }
    }
}
