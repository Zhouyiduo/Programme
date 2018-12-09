namespace UiPro
{
    partial class FormEx
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.process1 = new System.Diagnostics.Process();
            this.progressBarTest = new System.Windows.Forms.ProgressBar();
            this.btnSocket = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // progressBarTest
            // 
            this.progressBarTest.Location = new System.Drawing.Point(12, 21);
            this.progressBarTest.Name = "progressBarTest";
            this.progressBarTest.Size = new System.Drawing.Size(372, 23);
            this.progressBarTest.TabIndex = 0;
            // 
            // btnSocket
            // 
            this.btnSocket.Location = new System.Drawing.Point(13, 73);
            this.btnSocket.Name = "btnSocket";
            this.btnSocket.Size = new System.Drawing.Size(75, 23);
            this.btnSocket.TabIndex = 1;
            this.btnSocket.Text = "网络通信";
            this.btnSocket.UseVisualStyleBackColor = true;
            this.btnSocket.Click += new System.EventHandler(this.btnSocket_Click);
            // 
            // FormEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 119);
            this.Controls.Add(this.btnSocket);
            this.Controls.Add(this.progressBarTest);
            this.Name = "FormEx";
            this.Text = "FormEx";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormEx_FormClosed);
            this.Load += new System.EventHandler(this.FormEx_Load);
            this.Shown += new System.EventHandler(this.FormEx_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Diagnostics.Process process1;
        private System.Windows.Forms.ProgressBar progressBarTest;
        private System.Windows.Forms.Button btnSocket;
    }
}

