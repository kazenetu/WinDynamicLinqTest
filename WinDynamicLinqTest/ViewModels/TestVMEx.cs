using System.Windows.Forms;
using WinDynamicLinqTest.Attributes;
using WinDynamicLinqTest.DataSources;
using WinDynamicLinqTest.Models;

namespace WinDynamicLinqTest.ViewModels
{
    /// <summary>
    /// コントロール表示、バインドテスト用クラス(拡張版)
    /// </summary>
    public class TestVMEx : Interfaces.IViewModel
    {
        private TestEx model = new TestEx();

        /// <summary>
        /// Modelインスタンスの取得
        /// </summary>
        /// <returns>IModelインスタンス</returns>
        public Interfaces.IModel GetModel()
        {
            return this.model;
        }

        /// <summary>
        /// プロパティ更新の通知
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <returns>コントロールに値を設定するか否か</returns>
        public bool NotifyPropertyChanged(string propertyName)
        {
            // TODO プロパティ更新後の処理

            return false;
        }

        /// <summary>
        /// テキストボックスサンプル
        /// </summary>
        [InputControl(LabelText = "名前", InputControl = typeof(TextBox))]
        [DisplayOrder(Order = 1)]
        public string Name {
            set
            {
                model.Name = value;
            }
            get
            {
                return model.Name;
            }
        }

        /// <summary>
        /// チェックボックスサンプル
        /// </summary>
        [InputControl(LabelText = "値", InputControl = typeof(CheckBox))]
        [DisplayOrder(Order = 0)]
        public bool Value {
            set
            {
                model.Value = value;
            }
            get
            {
                return model.Value;
            }
        }

        /// <summary>
        /// コンボボックスサンプル
        /// </summary>
        [InputControl(LabelText = "選択値", InputControl = typeof(ComboBox), DataSourceClass = typeof(ComboBoxItem))]
        [DisplayOrder(Order = 2)]
        public int SelectItem {
            set
            {
                model.SelectItem = value;
            }
            get
            {
                return model.SelectItem;
            }
        }
    }
}
