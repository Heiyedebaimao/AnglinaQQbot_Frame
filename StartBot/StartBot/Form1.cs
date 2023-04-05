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
            //Process p = new Process();
            //p.StartInfo.FileName = "cmd";
            //p.StartInfo.Arguments = "/k cd d: \"D:\\1TOOL\\QQbot\\AngelinaBot-Windows10\\AngelinaBot-Windows10\\start.bat\"";
            //p.StartInfo.UseShellExecute = false;//运行时隐藏dos窗口
            //p.StartInfo.CreateNoWindow = false;//运行时隐藏dos窗口
            //p.Start();
            //p.WaitForExit();

            try

            {
                string targetDir = string.Format(@"D:\1TOOL\QQbot\AngelinaBot-Windows10\AngelinaBot-Windows10");//@"D:\BizMap\"
                Process proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = "D:\\1TOOL\\QQbot\\AngelinaBot-Windows10\\AngelinaBot-Windows10\\start.bat";
                //proc.StartInfo.Arguments = string.Format("10");//this is argument
                proc.StartInfo.CreateNoWindow = false;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;//这里设置DOS窗口不显示，经实践可行
                proc.Start();
                //proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }
            //using (Process proc = new Process())
            //{
            //    string command = @"D:\1TOOL\QQbot\AngelinaBot-Windows10\AngelinaBot-Windows10\start.bat";
            //    proc.StartInfo.FileName = command;
            //    proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(command);

            //    //run as admin
            //    proc.StartInfo.Verb = "runas";

            //    proc.Start();
            //    while (!proc.HasExited)
            //    {
            //        proc.WaitForExit(1000);
            //    }
            //}

        }

        public void writeBATFile(string fileContent)
        {
            string filePath = "D:\\test\\calljar.bat";
            if (!File.Exists(filePath))
            {
                FileStream fs1 = new FileStream(filePath, FileMode.Create, FileAccess.Write);//创建写入文件
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(fileContent);//开始写入值
                sw.Close();
                fs1.Close();
            }
            else
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(fileContent);//开始写入值
                sr.Close();
                fs.Close();
            }
        }

        /// <summary>
        /// 批量文件处理创建
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileContent"></param>
        public void WriteBatFile(string filePath, string fileContent)
        {
            File.Delete(filePath);
            FileStream fs1 = new FileStream(filePath, FileMode.Create, FileAccess.Write);//创建写入文件
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine(fileContent);//开始写入值
            sw.Close();
            fs1.Close();
        }

        /// <summary>
        /// 进入界面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] type = { "IPAD", "ANDROID_PAD", "ANDROID_PHONE", "MACOS" };
            F_typeList.Items.AddRange(type);
            F_typeList.SelectedIndex = 0;
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F_Update_Click(object sender, EventArgs e)
        {
            string filePath = "D:\\1TOOL\\QQbot\\AngelinaBot-Windows10\\AngelinaBot-Windows10\\application.yml";
            TextReader reader = File.OpenText(filePath);
            var yaml = new YamlStream();
            yaml.Load(reader);
            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

            F_administrators.Text = mapping["userConfig"]["administrators"].ToString();
            F_qqList.Text= mapping["userConfig"]["qqList"].ToString();
            F_pwList.Text = mapping["userConfig"]["pwList"].ToString();

            F_APP_ID.Text = mapping["baiduConfig"]["APP_ID"].ToString();
            F_API_KEY.Text = mapping["baiduConfig"]["API_KEY"].ToString();
            F_SECRET_KEY.Text = mapping["baiduConfig"]["SECRET_KEY"].ToString();

        }

        /// <summary>
        /// 参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F_Setup_Click(object sender, EventArgs e)
        {
            //string filePath = "D:\\1TOOL\\QQbot\\AngelinaBot-Windows10\\AngelinaBot-Windows10\\application.yml";
            //TextReader writer = File.OpenText(filePath);
            //var yaml = new YamlStream();
            //yaml.Save(writer);

            //var mapping1 = (YamlMappingNode)yaml.Documents[0].RootNode;

            //yaml.Save(mapping);


            //mapping["userConfig"]["administrators"] = F_administrators.Text.Trim();



            //F_qqList.Text = mapping["userConfig"]["qqList"].ToString();
            //F_pwList.Text = mapping["userConfig"]["pwList"].ToString();

            //F_APP_ID.Text = mapping["baiduConfig"]["APP_ID"].ToString();
            //F_API_KEY.Text = mapping["baiduConfig"]["API_KEY"].ToString();
            //F_SECRET_KEY.Text = mapping["baiduConfig"]["SECRET_KEY"].ToString();

        }
    }
}
