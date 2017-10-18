using System;

namespace WinDynamicLinqTest.Models
{
    public class TestEx : Interfaces.IModel
    {
        /// <summary>
        /// ModelのTypeを返す
        /// </summary>
        /// <returns>ModelのType</returns>
        public Type GetModelType()
        {
            return GetType();
        }

        /// <summary>
        /// 文字列サンプル
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// boolサンプル
        /// </summary>
        public bool Value { set; get; }

        /// <summary>
        /// 数値サンプル
        /// </summary>
        public int SelectItem { set; get; }
    }
}
