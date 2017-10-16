using System.ComponentModel;
using WinDynamicLinqTest.Models;

namespace WinDynamicLinqTest.ViewModels
{
    /// <summary>
    /// コントロール表示、バインドテスト用クラス
    /// </summary>
    public class TestVM
    {
        private Test model = new Test();

        public void SetModel(Test model)
        {
            this.model = model;
        }

        public Test GetModel()
        {
            return this.model;
        }

        [Description("名前")]
        public string Name
        {
            set
            {
                model.Name = value;
            }
            get
            {
                return model.Name;
            }
        }

        [Description("値")]
        public string Value
        {
            set
            {
                model.Value = value;
            }
            get
            {
                return model.Value;
            }
        }
    }
}
