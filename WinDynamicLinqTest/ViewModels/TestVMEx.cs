using System.Windows.Forms;
using WinDynamicLinqTest.Attributes;
using WinDynamicLinqTest.DataSources;

namespace WinDynamicLinqTest.ViewModels
{
    /// <summary>
    /// コントロール表示、バインドテスト用クラス(拡張版)
    /// </summary>
    public class TestVMEx
    {
        /// <summary>
        /// テキストボックスサンプル
        /// </summary>
        [InputControl(LabelText = "名前", InputControl = typeof(TextBox))]
        [DisplayOrder(Order = 1)]
        public string Name { set; get; }

        /// <summary>
        /// チェックボックスサンプル
        /// </summary>
        [InputControl(LabelText = "値", InputControl = typeof(CheckBox))]
        [DisplayOrder(Order = 0)]
        public bool Value { set; get; }

        /// <summary>
        /// コンボボックスサンプル
        /// </summary>
        [InputControl(LabelText = "選択値", InputControl = typeof(ComboBox), DataSourceClass = typeof(ComboBoxItem))]
        [DisplayOrder(Order = 2)]
        public int SelectItem { set; get; }
    }
}
