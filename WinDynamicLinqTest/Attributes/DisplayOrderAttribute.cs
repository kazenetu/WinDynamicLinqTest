using System;

namespace WinDynamicLinqTest.Attributes
{
    /// <summary>
    /// コントロール表示用属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DisplayOrderAttribute : Attribute
    {
        /// <summary>
        /// 表示順番
        /// </summary>

        public int Order { get; set; }
    }
}
