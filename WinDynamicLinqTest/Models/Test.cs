using System;

namespace WinDynamicLinqTest.Models
{
    public class Test : Interfaces.IModel
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
        /// 文字列サンプル1
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 文字列サンプル1
        /// </summary>
        public string Value { set; get; }
    }
}
