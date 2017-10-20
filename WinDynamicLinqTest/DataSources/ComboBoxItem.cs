using System;
using System.Collections.Generic;
using WinDynamicLinqTest.Interfaces;

namespace WinDynamicLinqTest.DataSources
{
    /// <summary>
    /// コンボボックス選択項目取得サンプル
    /// </summary>
    public class ComboBoxItem : ISettingControlDataSource
    {
        //表示項目と設定値のクラス
        public class Item
        {
            public string Text { set; get; }
            public int Value { set; get; }
        }

        /// <summary>
        /// 選択値を取得
        /// </summary>
        /// <returns>選択項目リスト</returns>
        /// <remarks>実際はDBから取得する実装になります</remarks>
        public dynamic GetItem()
        {
            var result = new List<Item>();

            result.Add(new Item() { Text = String.Empty , Value = 0 });
            result.Add(new Item() { Text = "選択A", Value = 1 });
            result.Add(new Item() { Text = "選択B", Value = 10 });
            result.Add(new Item() { Text = "選択C", Value = 20 });

            return result;
        }

        /// <summary>
        /// 表示プロパティ名
        /// </summary>
        /// <returns></returns>
        public string GetDisplayMember()
        {
            return "Text";
        }

        /// <summary>
        /// 設定値プロパティ名
        /// </summary>
        /// <returns></returns>
        public string GetValueMember()
        {
            return "Value";
        }
    }
}
