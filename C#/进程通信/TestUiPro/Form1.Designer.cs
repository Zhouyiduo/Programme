namespace TestUiPro
{
    partial class Form1
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
            this.btnSocket = new System.Windows.Forms.Button();
            this.btnControl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSocket
            // 
            this.btnSocket.Location = new System.Drawing.Point(24, 42);
            this.btnSocket.Name = "btnSocket";
            this.btnSocket.Size = new System.Drawing.Size(75, 23);
            this.btnSocket.TabIndex = 0;
            this.btnSocket.Text = "网络通信";
            this.btnSocket.UseVisualStyleBackColor = true;
            this.btnSocket.Click += new System.EventHandler(this.btnSocket_Click);
            // 
            // btnControl
            // 
            this.btnControl.Location = new System.Drawing.Point(132, 42);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(75, 23);
            this.btnControl.TabIndex = 1;
            this.btnControl.Text = "消息控制";
            this.btnControl.UseVisualStyleBackColor = true;
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 97);
            this.Controls.Add(this.btnControl);
            this.Controls.Add(this.btnSocket);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSocket;
        private System.Windows.Forms.Button btnControl;
    }
}

