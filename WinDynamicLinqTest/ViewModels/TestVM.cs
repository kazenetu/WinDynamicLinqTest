using System.ComponentModel;
using WinDynamicLinqTest.Models;

namespace WinDynamicLinqTest.ViewModels
{
    /// <summary>
    /// コントロール表示、バインドテスト用クラス
    /// </summary>
    public class TestVM : Interfaces.IViewModel
    {
        private Test model = new Test();

        public void SetModel(Test model)
        {
            this.model = model;
        }

        /// <summary>
        /// Modelインスタンスの取得
        /// </summary>
        /// <returns>IModelインスタンス</returns>
        public Interfaces.IModel GetModel()
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
