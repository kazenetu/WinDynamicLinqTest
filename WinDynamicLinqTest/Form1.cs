using System;
using System.Text;
using System.Windows.Forms;

namespace WinDynamicLinqTest
{
    public partial class Form1 : Form
    {
        private Interfaces.IViewModel testVM = null;
        private Interfaces.IViewModel testExVM= null;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// データ表示クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowData_Click(object sender, EventArgs e)
        {
            var result = new StringBuilder();

            // VMクラス名の格納
            var targetVM = this.ucSettingControl1.Target;
            result.AppendLine(string.Format("VMClass:{0}", targetVM.GetType().FullName));

            // Modelクラス名の格納
            var targetModel = targetVM.GetModel();
            result.AppendLine(string.Format("ModelClass:{0}", targetModel.GetType().FullName));


            // プロパティの格納
            foreach (var propaty in targetModel.GetType().GetProperties())
            {
                result.AppendLine(string.Format("{0}:{1}", propaty.Name, propaty.GetValue(targetModel)));
            }

            MessageBox.Show(result.ToString());
        }

        /// <summary>
        /// ViewModel切替
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeVM_Click(object sender, EventArgs e)
        {
            if (this.ucSettingControl1.Target is ViewModels.TestVM)
            {
                // 切替前のデータを保持
                this.testVM = this.ucSettingControl1.Target;

                // ViewModel切替
                if(this.testExVM != null)
                {
                    // データが保持されている場合は設定
                    this.ucSettingControl1.SetViewModel(this.testExVM);
                }
                else
                {
                    this.ucSettingControl1.TargetVMName = typeof(ViewModels.TestVMEx).FullName;
                }
            }
            else
            {
                // 切替前のデータを保持
                this.testExVM = this.ucSettingControl1.Target;

                // ViewModel切替
                if (this.testVM != null)
                {
                    // データが保持されている場合は設定
                    this.ucSettingControl1.SetViewModel(this.testVM);
                }
                else
                {
                    this.ucSettingControl1.TargetVMName = typeof(ViewModels.TestVM).FullName;
                }
            }
        }

        /// <summary>
        /// 項目(Value)の表示/非表示の制御
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeDisplay_Click(object sender, EventArgs e)
        {
            var targetColumnName = "Value";

            switch (this.ucSettingControl1.GetPropertyState(targetColumnName))
            {
                case UserControls.UcSettingControl.PropertyState.Show:
                    this.ucSettingControl1.HideProperty(targetColumnName);
                    break;

                case UserControls.UcSettingControl.PropertyState.Hide:
                    this.ucSettingControl1.ShowProperty(targetColumnName);
                    break;
            }
        }
    }
}
