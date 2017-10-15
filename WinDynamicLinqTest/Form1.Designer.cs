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
            this.ShowData = new System.Windows.Forms.Button();
            this.ucSettingControl1 = new WinDynamicLinqTest.UserControls.UcSettingControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ucSettingControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ShowData, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(298, 496);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ShowData
            // 
            this.ShowData.Location = new System.Drawing.Point(3, 3);
            this.ShowData.Name = "ShowData";
            this.ShowData.Size = new System.Drawing.Size(75, 23);
            this.ShowData.TabIndex = 1;
            this.ShowData.Text = "データ表示";
            this.ShowData.UseVisualStyleBackColor = true;
            this.ShowData.Click += new System.EventHandler(this.ShowData_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 496);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UserControls.UcSettingControl ucSettingControl1;
        private System.Windows.Forms.Button ShowData;
    }
}

