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
        /// Modelインスタンスの設定
        /// </summary>
        /// <param name="model">設定するModelインスタンス</param>
        public void SetModel(Interfaces.IModel model)
        {
            if(model is TestEx)
            {
                this.model = model as TestEx;
            }
        }

        /// <summary>
        /// Modelインスタンスの取得
        /// </summary>
        /// <returns>IModelインスタンス</returns>
        public Interfaces.IModel GetModel()
        {
            return this.model;
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
