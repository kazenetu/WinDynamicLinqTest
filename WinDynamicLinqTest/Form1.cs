using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinDynamicLinqTest
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// ViewModelのリスト
        /// </summary>
        private List<Interfaces.IViewModel> viewModels = null;

        /// <summary>
        /// 現在選択中のViewModelのIndex
        /// </summary>
        private int viewModelIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            // ViewModelを生成
            this.viewModels = new List<Interfaces.IViewModel>();
            this.viewModels.Add(new ViewModels.TestVM());
            this.viewModels.Add(new ViewModels.TestVMEx());

            // ViewModelを設定
            this.ucSettingControl1.SetViewModel(this.viewModels[this.viewModelIndex]);

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
            // Indexをインクリメント
            if(++this.viewModelIndex >= this.viewModels.Count)
            {
                this.viewModelIndex -= this.viewModels.Count;
            }

            // ViewModelを設定
            this.ucSettingControl1.SetViewModel(this.viewModels[this.viewModelIndex]);
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
