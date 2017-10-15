using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace WinDynamicLinqTest.UserControls
{
    /// <summary>
    /// コントロールメインパネル
    /// </summary>
    public class UcSettingControl: FlowLayoutPanel
    {
        /// <summary>
        /// コントロール化したいクラスのフルネーム
        /// </summary>
        private string targetVMName;

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


            //クラスを指定されていなければ、終了
            if (string.IsNullOrEmpty(this.TargetVMName))
            {
                return;
            }

            //クラス名を元にTypeとそのインスタンスを取得
            var targetType = Type.GetType(this.TargetVMName);
            this.target = Activator.CreateInstance(targetType);

            //プロパティ一覧を取得
            var properties = targetType.GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType.IsPublic)
                {
                    //ラベル名を取得
                    var labelText = property.Name;
                    foreach (var propertyAttribute in property.GetCustomAttributes(true))
                    {
                        if (propertyAttribute.GetType().Equals(typeof(DescriptionAttribute)))
                        {
                            labelText =
                                (propertyAttribute as DescriptionAttribute).Description;
                        }
                    }

                    Type inputControl = null;

                    //入力コントロールを設定
                    //※独自に属性を作って指定する方法は後ほど実装……
                    inputControl = typeof(TextBox);

                    //情報を元にラベルと入力コントロールを生成
                    this.AddTable(property,
                        labelText,
                        inputControl);
                }
            }
        }

        /// <summary>
        /// ラベルと入力コントロールのテーブルレイアウトを作成、登録する。
        /// </summary>
        /// <param name="pi">プロパティ情報</param>
        /// <param name="labelText">ラベルの表示テキスト</param>
        /// <param name="inputType">入力コントロールのType</param>
        private void AddTable(PropertyInfo pi, string labelText, Type inputType)
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
            var input = (Control)Activator.CreateInstance(inputType);
            input.Name = pi.Name;
            input.Size = new System.Drawing.Size(100, 19);
            input.TabStop = true;

            //データバインドの設定
            var inputData = pi.GetValue(this.target, null);
            input.Text = inputData == null ? string.Empty : inputData.ToString();
            input.TextChanged += (sender, e) =>
            {
                pi.SetValue(this.target, input.Text, null);
            };

            //テーブルレイアウトにラベルと入力コントロールを登録
            table.SetCellPosition(label, new TableLayoutPanelCellPosition(0, 0));
            table.SetCellPosition(input, new TableLayoutPanelCellPosition(1, 0));
            table.Controls.Add(label);
            table.Controls.Add(input);

            //高さの調整
            if (label.Height < input.Height)
            {
                int y = (input.Height - label.Height);
                label.Margin = new System.Windows.Forms.Padding(0, y, 0, 0);
            }
            else
            {
                input.Top = (label.Height - input.Height) / 2;
            }

            //ユーザーコントロール（フローレイアウトパネル）に登録
            this.Controls.Add(table);
        }
    }
}
