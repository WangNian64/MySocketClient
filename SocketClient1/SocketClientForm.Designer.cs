namespace SocketClient1
{
    partial class SocketClientForm
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
            this.label_IP = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.connect_btn = new System.Windows.Forms.Button();
            this.textBox_receiveMsg = new System.Windows.Forms.TextBox();
            this.disconnect_btn = new System.Windows.Forms.Button();
            this.clearReceive_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(23, 24);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(23, 12);
            this.label_IP.TabIndex = 0;
            this.label_IP.Tag = "labelIP";
            this.label_IP.Text = "IP:";
            this.label_IP.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(52, 23);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(206, 21);
            this.textBox_IP.TabIndex = 1;
            this.textBox_IP.Text = "127.0.0.1";
            this.textBox_IP.TextChanged += new System.EventHandler(this.textBox_IP_TextChanged);
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(289, 24);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(35, 12);
            this.label_port.TabIndex = 2;
            this.label_port.Text = "Port:";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(330, 21);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(206, 21);
            this.textBox_port.TabIndex = 3;
            this.textBox_port.Text = "50001";
            // 
            // connect_btn
            // 
            this.connect_btn.Location = new System.Drawing.Point(606, 24);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(115, 24);
            this.connect_btn.TabIndex = 4;
            this.connect_btn.Text = "连接";
            this.connect_btn.UseVisualStyleBackColor = true;
            this.connect_btn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // textBox_receiveMsg
            // 
            this.textBox_receiveMsg.Location = new System.Drawing.Point(25, 68);
            this.textBox_receiveMsg.Multiline = true;
            this.textBox_receiveMsg.Name = "textBox_receiveMsg";
            this.textBox_receiveMsg.Size = new System.Drawing.Size(696, 396);
            this.textBox_receiveMsg.TabIndex = 7;
            this.textBox_receiveMsg.TextChanged += new System.EventHandler(this.textBox_receiveMsg_TextChanged);
            // 
            // disconnect_btn
            // 
            this.disconnect_btn.Location = new System.Drawing.Point(759, 21);
            this.disconnect_btn.Name = "disconnect_btn";
            this.disconnect_btn.Size = new System.Drawing.Size(89, 23);
            this.disconnect_btn.TabIndex = 9;
            this.disconnect_btn.Text = "断开连接";
            this.disconnect_btn.UseVisualStyleBackColor = true;
            this.disconnect_btn.Click += new System.EventHandler(this.disconnect_btn_Click);
            // 
            // clearReceive_btn
            // 
            this.clearReceive_btn.Location = new System.Drawing.Point(759, 68);
            this.clearReceive_btn.Name = "clearReceive_btn";
            this.clearReceive_btn.Size = new System.Drawing.Size(89, 23);
            this.clearReceive_btn.TabIndex = 10;
            this.clearReceive_btn.Text = "清空";
            this.clearReceive_btn.UseVisualStyleBackColor = true;
            this.clearReceive_btn.Click += new System.EventHandler(this.clearReceive_btn_Click);
            // 
            // SocketClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 487);
            this.Controls.Add(this.clearReceive_btn);
            this.Controls.Add(this.disconnect_btn);
            this.Controls.Add(this.textBox_receiveMsg);
            this.Controls.Add(this.connect_btn);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.label_IP);
            this.Name = "SocketClientForm";
            this.Text = "SocketClientForm";
            this.Load += new System.EventHandler(this.SocketClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Button connect_btn;
        private System.Windows.Forms.TextBox textBox_receiveMsg;
        private System.Windows.Forms.Button disconnect_btn;
        private System.Windows.Forms.Button clearReceive_btn;
    }
}

