namespace StartBot
{
    partial class QQbot_Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.F_Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.F_Update = new System.Windows.Forms.Button();
            this.F_Setup = new System.Windows.Forms.Button();
            this.F_administrators = new System.Windows.Forms.TextBox();
            this.F_qqList = new System.Windows.Forms.TextBox();
            this.F_pwList = new System.Windows.Forms.TextBox();
            this.F_typeList = new System.Windows.Forms.ComboBox();
            this.F_APP_ID = new System.Windows.Forms.TextBox();
            this.F_API_KEY = new System.Windows.Forms.TextBox();
            this.F_SECRET_KEY = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // F_Start
            // 
            this.F_Start.Location = new System.Drawing.Point(535, 121);
            this.F_Start.Name = "F_Start";
            this.F_Start.Size = new System.Drawing.Size(209, 68);
            this.F_Start.TabIndex = 0;
            this.F_Start.Text = "启动";
            this.F_Start.UseVisualStyleBackColor = true;
            this.F_Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "超级管理员";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "QQ号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "百度设置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "APP_ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "API_KEY";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 7;
            this.label7.Text = "SECRET_KEY";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(74, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 8;
            this.label8.Text = "登录协议";
            // 
            // F_Update
            // 
            this.F_Update.Location = new System.Drawing.Point(62, 396);
            this.F_Update.Name = "F_Update";
            this.F_Update.Size = new System.Drawing.Size(209, 68);
            this.F_Update.TabIndex = 9;
            this.F_Update.Text = "刷新";
            this.F_Update.UseVisualStyleBackColor = true;
            this.F_Update.Click += new System.EventHandler(this.F_Update_Click);
            // 
            // F_Setup
            // 
            this.F_Setup.Location = new System.Drawing.Point(62, 486);
            this.F_Setup.Name = "F_Setup";
            this.F_Setup.Size = new System.Drawing.Size(209, 68);
            this.F_Setup.TabIndex = 10;
            this.F_Setup.Text = "设置";
            this.F_Setup.UseVisualStyleBackColor = true;
            this.F_Setup.Click += new System.EventHandler(this.F_Setup_Click);
            // 
            // F_administrators
            // 
            this.F_administrators.Location = new System.Drawing.Point(214, 21);
            this.F_administrators.Name = "F_administrators";
            this.F_administrators.Size = new System.Drawing.Size(100, 28);
            this.F_administrators.TabIndex = 11;
            // 
            // F_qqList
            // 
            this.F_qqList.Location = new System.Drawing.Point(214, 71);
            this.F_qqList.Name = "F_qqList";
            this.F_qqList.Size = new System.Drawing.Size(100, 28);
            this.F_qqList.TabIndex = 12;
            // 
            // F_pwList
            // 
            this.F_pwList.Location = new System.Drawing.Point(214, 118);
            this.F_pwList.Name = "F_pwList";
            this.F_pwList.Size = new System.Drawing.Size(100, 28);
            this.F_pwList.TabIndex = 13;
            // 
            // F_typeList
            // 
            this.F_typeList.FormattingEnabled = true;
            this.F_typeList.Location = new System.Drawing.Point(214, 157);
            this.F_typeList.Name = "F_typeList";
            this.F_typeList.Size = new System.Drawing.Size(121, 26);
            this.F_typeList.TabIndex = 14;
            // 
            // F_APP_ID
            // 
            this.F_APP_ID.Location = new System.Drawing.Point(214, 252);
            this.F_APP_ID.Name = "F_APP_ID";
            this.F_APP_ID.Size = new System.Drawing.Size(100, 28);
            this.F_APP_ID.TabIndex = 15;
            // 
            // F_API_KEY
            // 
            this.F_API_KEY.Location = new System.Drawing.Point(214, 298);
            this.F_API_KEY.Name = "F_API_KEY";
            this.F_API_KEY.Size = new System.Drawing.Size(100, 28);
            this.F_API_KEY.TabIndex = 16;
            // 
            // F_SECRET_KEY
            // 
            this.F_SECRET_KEY.Location = new System.Drawing.Point(214, 334);
            this.F_SECRET_KEY.Name = "F_SECRET_KEY";
            this.F_SECRET_KEY.Size = new System.Drawing.Size(100, 28);
            this.F_SECRET_KEY.TabIndex = 17;
            // 
            // QQbot_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 603);
            this.Controls.Add(this.F_SECRET_KEY);
            this.Controls.Add(this.F_API_KEY);
            this.Controls.Add(this.F_APP_ID);
            this.Controls.Add(this.F_typeList);
            this.Controls.Add(this.F_pwList);
            this.Controls.Add(this.F_qqList);
            this.Controls.Add(this.F_administrators);
            this.Controls.Add(this.F_Setup);
            this.Controls.Add(this.F_Update);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.F_Start);
            this.Name = "QQbot_Form";
            this.Text = "AngelinaHelper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button F_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button F_Update;
        private System.Windows.Forms.Button F_Setup;
        private System.Windows.Forms.TextBox F_administrators;
        private System.Windows.Forms.TextBox F_qqList;
        private System.Windows.Forms.TextBox F_pwList;
        private System.Windows.Forms.ComboBox F_typeList;
        private System.Windows.Forms.TextBox F_APP_ID;
        private System.Windows.Forms.TextBox F_API_KEY;
        private System.Windows.Forms.TextBox F_SECRET_KEY;
    }
}

