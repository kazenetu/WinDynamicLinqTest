namespace WinDynamicLinqTest
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ShowData = new System.Windows.Forms.Button();
            this.ChangeVM = new System.Windows.Forms.Button();
            this.ucSettingControl1 = new WinDynamicLinqTest.UserControls.UcSettingControl();
            this.ChangeDisplay = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ucSettingControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(298, 496);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChangeDisplay);
            this.panel1.Controls.Add(this.ChangeVM);
            this.panel1.Controls.Add(this.ShowData);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 44);
            this.panel1.TabIndex = 3;
            // 
            // ShowData
            // 
            this.ShowData.Location = new System.Drawing.Point(3, 3);
            this.ShowData.Name = "ShowData";
            this.ShowData.Size = new System.Drawing.Size(75, 38);
            this.ShowData.TabIndex = 2;
            this.ShowData.Text = "データ表示";
            this.ShowData.UseVisualStyleBackColor = true;
            // 
            // ChangeVM
            // 
            this.ChangeVM.Location = new System.Drawing.Point(84, 3);
            this.ChangeVM.Name = "ChangeVM";
            this.ChangeVM.Size = new System.Drawing.Size(75, 38);
            this.ChangeVM.TabIndex = 3;
            this.ChangeVM.Text = "VM切替";
            this.ChangeVM.UseVisualStyleBackColor = true;
            this.ChangeVM.Click += new System.EventHandler(this.ChangeVM_Click);
            // 
            // ucSettingControl1
            // 
            this.ucSettingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSettingControl1.Location = new System.Drawing.Point(3, 53);
            this.ucSettingControl1.Name = "ucSettingControl1";
            this.ucSettingControl1.Size = new System.Drawing.Size(292, 440);
            this.ucSettingControl1.TabIndex = 2;
            this.ucSettingControl1.TargetVMName = "WinDynamicLinqTest.ViewModels.TestVM";
            // 
            // ChangeDisplay
            // 
            this.ChangeDisplay.Location = new System.Drawing.Point(165, 3);
            this.ChangeDisplay.Name = "ChangeDisplay";
            this.ChangeDisplay.Size = new System.Drawing.Size(83, 38);
            this.ChangeDisplay.TabIndex = 4;
            this.ChangeDisplay.Text = "項目\r\n表示/非表示";
            this.ChangeDisplay.UseVisualStyleBackColor = true;
            this.ChangeDisplay.Click += new System.EventHandler(this.ChangeDisplay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 496);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UserControls.UcSettingControl ucSettingControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ChangeVM;
        private System.Windows.Forms.Button ShowData;
        private System.Windows.Forms.Button ChangeDisplay;
    }
}

