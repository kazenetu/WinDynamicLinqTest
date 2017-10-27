using System;

namespace WinDynamicLinqTest.Attributes
{
    /// <summary>
    /// 対象プロパティに紐づくコントロールの有効/無効制御
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EnableAttribute:Attribute 
    {
        /// <summary>
        /// 対象のプロパティ名
        /// </summary>
        public string targetPropertyName { set; get; }
    }
}
