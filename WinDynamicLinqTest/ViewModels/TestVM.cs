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
        public void NotifyPropertyChanged(string propertyName)
        {
            // TODO プロパティ更新後の処理
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
