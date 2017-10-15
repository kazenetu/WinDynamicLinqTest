using System.ComponentModel;

namespace WinDynamicLinqTest.ViewModels
{
    /// <summary>
    /// コントロール表示、バインドテスト用クラス
    /// </summary>
    public class TestVM
    {
        [Description("名前")]
        public string Name { set; get; }

        [Description("値")]
        public string Value { set; get; }
    }
}
