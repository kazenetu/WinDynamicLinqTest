using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDynamicLinqTest.Attributes
{
    /// <summary>
    /// 入力コントロール定義用属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class InputControlAttribute : Attribute
    {
        /// <summary>
        /// ラベル表示名
        /// </summary>
        public string LabelText { get; set; }

        /// <summary>
        /// 入力コントロール：種類
        /// </summary>
        public Type InputControl { get; set; }

        /// <summary>
        /// 入力コントロール：選択リストを定義するクラス
        /// </summary>
        /// <remarks>コンボボックスやリストボックスの選択情報</remarks>
        public Type DataSourceClass { get; set; }
    }
}
