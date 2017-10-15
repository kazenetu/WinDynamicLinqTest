using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WinDynamicLinqTest.Attributes;
using WinDynamicLinqTest.Interfaces;

namespace WinDynamicLinqTest.UserControls
{
    /// <summary>
    /// コントロールメインパネル
    /// </summary>
    public class UcSettingControl: FlowLayoutPanel
    {
        /// <summary>
        /// コントロール作成用データ
        /// </summary>
        private class CreateSourceData
        {
            /// <summary>
            /// 属性情報「InputControlAttribute」
            /// </summary>
            public InputControlAttribute InputControl { set; get; }

            /// <summary>
            /// ソート情報「InputControlAttribute」
            /// </summary>
            public DisplayOrderAttribute DisplayOrder { set; get; }

            /// <summary>
            /// プロパティ情報
            /// </summary>
            public PropertyInfo PropertyInfo { set; get; }
        }

        /// <summary>
        /// コントロール化したいクラスのフルネーム
        /// </summary>
        private string targetVMName;

        /// <summary>
        /// テーブルレイアウトリスト
        /// </summary>
        private Dictionary<string, TableLayoutPanel> tableLayoutPanels = null;

        /// <summary>
        /// コントロール化したいクラスのフルネーム
        /// </summary>
        [Browsable(true), DefaultValue("")]
        public string TargetVMName
        {
            set
            {
                this.targetVMName = value;

                //独自処理実行
                this.Initialize();
            }
            get
            {
                return this.targetVMName;
            }
        }

        /// <summary>
        /// TargetVMNameのインスタンス
        /// </summary>
        private object target = null;

        /// <summary>
        /// TargetVMNameのインスタンス
        /// </summary>
        [Browsable(false)]
        public object Target
        {
            get
            {
                return this.target;
            }
        }

        #region プロパティ表示設定

        /// <summary>
        /// プロパティの表示状態
        /// </summary>
        public enum PropertyState
        {
            None,
            Show,
            Hide
        }

        /// <summary>
        /// プロパティ（入力コントロール）の表示状態の取得
        /// </summary>
        /// <param name="PropertyName">プロパティ名</param>
        /// <returns>プロパティの表示状態</returns>
        public PropertyState GetPropertyState(string PropertyName)
        {
            PropertyState result = PropertyState.None;

            if (this.tableLayoutPanels.ContainsKey(PropertyName))
            {
                if (this.tableLayoutPanels[PropertyName].Visible)
                {
                    result = PropertyState.Show;
                }
                else
                {
                    result = PropertyState.Hide;
                }
            }

            return result;
        }

        /// <summary>
        /// プロパティ（入力コントロール）の表示
        /// </summary>
        /// <param name="PropertyName">プロパティ名</param>
        /// <returns>true：プロパティが存在 false:存在しない</returns>
        public bool ShowProperty(string PropertyName)
        {
            bool result = false;

            if (this.tableLayoutPanels.ContainsKey(PropertyName))
            {
                this.tableLayoutPanels[PropertyName].Visible = true;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// プロパティ（入力コントロール）の非表示
        /// </summary>
        /// <param name="PropertyName">プロパティ名</param>
        /// <returns>true：プロパティが存在 false:存在しない</returns>
        public bool HideProperty(string PropertyName)
        {
            bool result = false;

            if (this.tableLayoutPanels.ContainsKey(PropertyName))
            {
                this.tableLayoutPanels[PropertyName].Visible = false;
                result = true;
            }
            return result;
        }

        #endregion

        #region レイアウト設定

        /// <summary>
        /// レイアウト初期化　独自処理
        /// </summary>
        public void Initialize()
        {
            //デザイナーなら何もせずに終了
            if (this.DesignMode)
            {
                return;
            }

            //すでにレイアウトされている場合はコントロールを解放
            if (this.tableLayoutPanels != null)
            {
                this.tableLayoutPanels.Clear();
                this.Controls.Clear();
                this.tableLayoutPanels = null;
            }

            //クラスを指定されていなければ、終了
            if (string.IsNullOrEmpty(this.TargetVMName))
            {
                return;
            }

            //クラス名を元にTypeとそのインスタンスを取得
            var targetType = Type.GetType(this.TargetVMName);
            this.target = Activator.CreateInstance(targetType);

            //ソートするため、一時的に属性を格納するリスト作成
            var createSourceData = new List<CreateSourceData>();

            //プロパティ一覧を取得し、属性を取得する
            var properties = targetType.GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType.IsPublic)
                {
                    DisplayOrderAttribute displayOrder = null;
                    InputControlAttribute inputControl = null;

                    //属性を取得
                    foreach (var propertyAttribute in property.GetCustomAttributes(true))
                    {
                        if (propertyAttribute.GetType().Equals(typeof(InputControlAttribute)))
                        {
                            inputControl =
                                propertyAttribute as InputControlAttribute;
                        }
                        if (propertyAttribute.GetType().Equals(typeof(DisplayOrderAttribute)))
                        {
                            displayOrder =
                                propertyAttribute as DisplayOrderAttribute;
                        }
                    }

                    //属性が設定されていない場合の設定を行う
                    if (displayOrder == null)
                    {
                        displayOrder =
                            new DisplayOrderAttribute()
                            {
                                Order = -1
                            };
                    }
                    if (inputControl == null)
                    {
                        inputControl =
                            new InputControlAttribute()
                            {
                                LabelText = property.Name,
                                InputControl = typeof(TextBox)
                            };
                    }

                    createSourceData.Add(
                        new CreateSourceData()
                        {
                            InputControl = inputControl,
                            DisplayOrder = displayOrder,
                            PropertyInfo = property
                        });
                }
            }

            //テーブルレイアウトリストを生成
            this.tableLayoutPanels = new Dictionary<string, TableLayoutPanel>();

            //属性一覧からテーブルレイアウトを作成する
            var sortedInputControlAttributes =
                createSourceData.OrderBy(item => item.DisplayOrder.Order);
            foreach (var inputControl in sortedInputControlAttributes)
            {
                //情報を元にラベルと入力コントロールを生成
                this.AddTable(inputControl.PropertyInfo,
                    inputControl.InputControl.LabelText,
                    inputControl.InputControl.InputControl,
                    inputControl.InputControl.DataSourceClass);
            }

            //ユーザーコントロール（フローレイアウトパネル）に登録
            this.Controls.AddRange(this.tableLayoutPanels.Select(item => item.Value).ToArray());
        }

        /// <summary>
        /// ラベルと入力コントロールのテーブルレイアウトを作成、登録する。
        /// </summary>
        /// <param name="pi">プロパティ情報</param>
        /// <param name="labelText">ラベルの表示テキスト</param>
        /// <param name="inputType">入力コントロールのType</param>
        /// <param name="dataSourceClass">コンボボックスやリストボックスのための選択項目出力クラス</param>
        private void AddTable(PropertyInfo pi, string labelText, Type inputType, Type dataSourceClass)
        {
            //テーブルレイアウtを作成、設定する
            var table = new TableLayoutPanel();
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            table.AutoSize = true;
            table.RowCount++;
            table.ColumnCount = 2;

            //ラベルを生成
            var label = new Label();
            label.Text = labelText;
            label.AutoSize = true;

            //入力コントロールの設定
            var input = (dynamic)Activator.CreateInstance(inputType);
            input.Name = pi.Name;
            input.Size = new System.Drawing.Size(100, 19);
            input.TabStop = true;

            //データバインドの設定
            var inputHeight =
                this.SetDataBind(input, pi, dataSourceClass);

            //テーブルレイアウトにラベルと入力コントロールを登録
            table.SetCellPosition(label, new TableLayoutPanelCellPosition(0, 0));
            table.SetCellPosition(input, new TableLayoutPanelCellPosition(1, 0));
            table.Controls.Add(label);
            table.Controls.Add(input);

            //高さの調整

            if (label.Height < inputHeight)
            {
                int y = (inputHeight - label.Height);
                label.Margin = new System.Windows.Forms.Padding(0, y, 0, 0);
            }
            else
            {
                input.Top = (label.Height - inputHeight) / 2;
            }

            //テーブルレイアウトリストに追加
            this.tableLayoutPanels.Add(pi.Name, table);
        }

        #endregion

        #region データバインド関係

        /// <summary>
        /// データバインド処理：テキストボックス
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pi"></param>
        /// <param name="dataSourceClass">コンボボックスやリストボックスのための選択項目出力クラス</param>
        /// <returns>入力コントロールの高さ情報</returns>
        private int SetDataBind(TextBox input, PropertyInfo pi, Type dataSourceClass)
        {
            var inputData = pi.GetValue(this.target, null);
            input.Text = inputData == null ? string.Empty : inputData.ToString();

            input.TextChanged += (sender, e) =>
            {
                pi.SetValue(this.target, input.Text, null);
            };

            return input.Height;
        }

        /// <summary>
        /// データバインド処理：チェックボックス
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pi"></param>
        /// <param name="dataSourceClass">コンボボックスやリストボックスのための選択項目出力クラス</param>
        /// <returns>入力コントロールの高さ情報</returns>
        private int SetDataBind(CheckBox input, PropertyInfo pi, Type dataSourceClass)
        {
            var inputData = pi.GetValue(this.target, null);
            input.Checked = inputData == null ? false : (bool)inputData;

            input.CheckedChanged += (sender, e) =>
            {
                pi.SetValue(this.target, input.Checked, null);
            };

            return input.Height;
        }

        /// <summary>
        /// データバインド処理：コンボボックス
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pi"></param>
        /// <param name="dataSourceClass">コンボボックスやリストボックスのための選択項目出力クラス</param>
        /// <returns>入力コントロールの高さ情報</returns>
        private int SetDataBind(ComboBox input, PropertyInfo pi, Type dataSourceClass)
        {
            var datasource =
                (ISettingControlDataSource)Activator.CreateInstance(dataSourceClass);

            if (datasource != null)
            {
                input.ValueMember = datasource.GetValueMember();
                input.DisplayMember = datasource.GetDisplayMember();
                input.Items.AddRange(datasource.GetItem().ToArray());
            }

            var inputData = pi.GetValue(this.target, null);
            input.SelectedValueChanged += (_sender, _e) =>
            {
                pi.SetValue(this.target, input.SelectedValue, null);
            };
            input.SelectedValue = inputData;

            return input.Height;

        }

        #endregion
    }
}

