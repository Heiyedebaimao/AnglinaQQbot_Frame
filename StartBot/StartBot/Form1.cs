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
            try
            {
                string targetDir = string.Format(@"D:\1TOOL\QQbot\AngelinaBot-Windows10\AngelinaBot-Windows10");
                Process proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = "D:\\1TOOL\\QQbot\\AngelinaBot-Windows10\\AngelinaBot-Windows10\\start.bat";
                //proc.StartInfo.Arguments = string.Format("10");//this is argument
                proc.StartInfo.CreateNoWindow = false;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;//这里设置DOS窗口不显示，经实践可行
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
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

            F_APP_ID.Text = yml.read("APP_ID");
            F_API_KEY.Text = yml.read("API_KEY");
            F_SECRET_KEY.Text = yml.read("SECRET_KEY");
        }

        private void test()
        {
            using (Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = "ping";
                process.StartInfo.Arguments = "www.ymind.net -t";
                // 必须禁用操作系统外壳程序  
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;

                process.Start();

                // 异步获取命令行内容  
                process.BeginOutputReadLine();

                // 为异步获取订阅事件  
                process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
            }             
        }


        private void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // 这里仅做输出的示例，实际上您可以根据情况取消获取命令行的内容  
            // 参考：process.CancelOutputRead()  

            if (String.IsNullOrEmpty(e.Data) == false)
                this.AppendText(e.Data + "\r\n");
        }

        #region 解决多线程下控件访问的问题  

        public delegate void AppendTextCallback(string text);

        public void AppendText(string text)
        {
            //if (this.textBox1.InvokeRequired)
            //{
            //    AppendTextCallback d = new AppendTextCallback(AppendText);
            //    this.textBox1.Invoke(d, text);
            //}
            //else
            //{
            //    this.textBox1.AppendText(text);
            //}
        }

        #endregion
    }
}
