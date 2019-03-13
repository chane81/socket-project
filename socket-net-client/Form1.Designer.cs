namespace SocketNetClient
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtShowMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSendMsg = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(670, 459);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(128, 61);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "서버연결";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtShowMsg
            // 
            this.txtShowMsg.Location = new System.Drawing.Point(2, 2);
            this.txtShowMsg.Multiline = true;
            this.txtShowMsg.Name = "txtShowMsg";
            this.txtShowMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShowMsg.Size = new System.Drawing.Size(796, 363);
            this.txtShowMsg.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(670, 382);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(128, 61);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.BackColor = System.Drawing.SystemColors.Highlight;
            this.txtSendMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSendMsg.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtSendMsg.Location = new System.Drawing.Point(2, 382);
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(662, 215);
            this.txtSendMsg.TabIndex = 4;
            this.txtSendMsg.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(670, 536);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(128, 61);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "연결끊기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 609);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtShowMsg);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtShowMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox txtSendMsg;
        private System.Windows.Forms.Button btnClose;
    }
}

