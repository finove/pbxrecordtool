namespace pbxrecordtool
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnStartUpdate = new System.Windows.Forms.Button();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeviceMAC = new System.Windows.Forms.TextBox();
            this.dtpUpdateDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartUpdate
            // 
            this.btnStartUpdate.Location = new System.Drawing.Point(315, 304);
            this.btnStartUpdate.Name = "btnStartUpdate";
            this.btnStartUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnStartUpdate.TabIndex = 0;
            this.btnStartUpdate.Text = "开始同步";
            this.btnStartUpdate.UseVisualStyleBackColor = true;
            this.btnStartUpdate.Click += new System.EventHandler(this.btnStartUpdate_Click);
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(313, 92);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(121, 21);
            this.txtDeviceName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "设备名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "设备MAC";
            // 
            // txtDeviceMAC
            // 
            this.txtDeviceMAC.Location = new System.Drawing.Point(315, 137);
            this.txtDeviceMAC.Name = "txtDeviceMAC";
            this.txtDeviceMAC.Size = new System.Drawing.Size(119, 21);
            this.txtDeviceMAC.TabIndex = 3;
            // 
            // dtpUpdateDate
            // 
            this.dtpUpdateDate.Location = new System.Drawing.Point(313, 182);
            this.dtpUpdateDate.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
            this.dtpUpdateDate.Name = "dtpUpdateDate";
            this.dtpUpdateDate.Size = new System.Drawing.Size(121, 21);
            this.dtpUpdateDate.TabIndex = 5;
            this.dtpUpdateDate.Value = new System.DateTime(2020, 3, 31, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "同步日期";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpUpdateDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDeviceMAC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDeviceName);
            this.Controls.Add(this.btnStartUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Record Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartUpdate;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeviceMAC;
        private System.Windows.Forms.DateTimePicker dtpUpdateDate;
        private System.Windows.Forms.Label label3;
    }
}

