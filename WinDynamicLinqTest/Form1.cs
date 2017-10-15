using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDynamicLinqTest
{
    public partial class Form1 : Form
    {
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

            var targetType = this.ucSettingControl1.Target.GetType();

            // クラス名の格納
            result.AppendLine(string.Format("class:{0}",targetType.FullName ));

            // プロパティの格納
            foreach (var propaty in targetType.GetProperties())
            {
                result.AppendLine(string.Format("{0}:{1}", propaty.Name, propaty.GetValue(this.ucSettingControl1.Target)));
            }

            MessageBox.Show(result.ToString());
        }
    }
}
