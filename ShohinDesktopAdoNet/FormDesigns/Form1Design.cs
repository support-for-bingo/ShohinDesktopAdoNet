using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShohinDesktopAdoNet.FormDesigns
{
    public class Form1Design
    {
        //WinFormsアプリのデザイナーが存在しない場合を想定してコードで実行時に作成
        internal Dictionary<String, Label> labelDic = new Dictionary<String, Label>();
        internal DataGridView dataGridView1;
        internal BindingSource bindingSource1;
        internal RichTextBox richTextBox1;
        internal Label labelUniqueId;
        internal Label labelFoot;
        internal TextBox textBoxShohinCode;
        internal TextBox textBoxShohinName;
        internal TextBox textBoxRemarks;
        internal Button buttonRead;
        internal Button buttonAdd;
        internal Button buttonChange;
        internal Button buttonErase;

        private Label LabelsSetting(String name, String txt, int x, int y, int w, int h)
        {
            var label = new Label();
            label.Name = name;
            label.AutoSize = false;
            label.Text = txt;
            label.Location = new Point(x, y);
            label.Size = new Size(w, h);
            labelDic.Add(label.Name, label);
            //Controls.Add(label);

            return label;
        }

        /// <summary>与えられたControlクラスオブジェクトのロケーション、サイズを設定しControlオブジェクトで戻します</summary>
        /// <param name="ctl">System.Windows.Forms.Control</param>
        /// <param name="name">オブジェクト名</param>
        /// <param name="x">ロケーションX</param>
        /// <param name="y">ロケーションY</param>
        /// <param name="w">コントロールの横サイズ</param>
        /// <param name="h">コントロールの縦サイズ</param>
        /// <returns>System.Windows.Forms.Control</returns>
        private Control ControlsSetting(System.Windows.Forms.Control ctl, String name, int x, int y, int w, int h)
        {
            ctl.Name = name;
            ctl.Location = new Point(x, y);
            ctl.Size = new Size(w, h);
            //Controls.Add(ctl);

            return ctl;
        }

        internal void Setting()
        {
            this.dataGridView1 = new DataGridView();
            dataGridView1 = (DataGridView)(ControlsSetting(dataGridView1, "dataGridView1", 25, 25, 750, 200));

            //bindingSource1 = new BindingSource();

            this.richTextBox1 = new RichTextBox();
            richTextBox1.ReadOnly = true;
            richTextBox1 = (RichTextBox)(ControlsSetting(richTextBox1, "richTextBox1", 25, 235, 350, 200));

            this.buttonRead = new Button();
            buttonRead.Text = "抽出";
            buttonRead.TabIndex = 3;
            buttonRead.UseVisualStyleBackColor = true;
            buttonRead = (Button)(ControlsSetting(buttonRead, "buttonRead", 50, 470, 150, 50));

            this.buttonAdd = new Button();
            buttonAdd.Text = "追加";
            buttonAdd.TabIndex = 4;
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd = (Button)(ControlsSetting(buttonAdd, "buttonAdd", 230, 470, 150, 50));

            this.buttonChange = new Button();
            buttonChange.Text = "更新";
            buttonChange.TabIndex = 5;
            buttonChange.UseVisualStyleBackColor = true;
            buttonChange = (Button)(ControlsSetting(buttonChange, "buttonChange", 410, 470, 150, 50));

            this.buttonErase = new Button();
            buttonErase.Text = "削除";
            buttonErase.TabIndex = 6;
            buttonErase.UseVisualStyleBackColor = true;
            buttonErase = (Button)(ControlsSetting(buttonErase, "buttonErase", 590, 470, 150, 50));

            LabelsSetting("label1", "ユニークID：", 385, 250, 75, 25);
            LabelsSetting("label2", "商品番号：", 385, 300, 75, 25);
            LabelsSetting("label3", "商品名：", 385, 350, 75, 25);
            LabelsSetting("label4", "備考：", 385, 400, 60, 25);

            labelUniqueId = new Label();
            labelUniqueId.AutoSize = false;
            labelUniqueId.Text = "";
            labelUniqueId.TextAlign = ContentAlignment.TopRight;
            labelUniqueId = (Label)(ControlsSetting(labelUniqueId, "labelUniqueId", 530, 250, 230, 19));

            labelFoot = new Label();
            labelFoot.AutoSize = false;
            labelFoot.Text = $"Copyright (c)  2021-2023  support for bingo";
            labelFoot = (Label)(ControlsSetting(labelFoot, "LabelFoot", 30, 535, 300, 19));

            this.textBoxShohinCode = new TextBox();
            textBoxShohinCode.TabIndex = 0;
            textBoxShohinCode = (TextBox)(ControlsSetting(textBoxShohinCode, "textBoxShohinCode", 600, 300, 150, 19));

            this.textBoxShohinName = new TextBox();
            textBoxShohinName.TabIndex = 1;
            textBoxShohinName = (TextBox)(ControlsSetting(textBoxShohinName, "textBoxShohinName", 550, 350, 200, 19));

            this.textBoxRemarks = new TextBox();
            textBoxRemarks.TabIndex = 2;
            textBoxRemarks = (TextBox)(ControlsSetting(textBoxRemarks, "textBoxRemarks", 450, 400, 300, 19));
        }

        internal void TextBoxClear()
        {
            labelUniqueId.Text = "";
            textBoxShohinCode.Text = "";
            textBoxShohinName.Text = "";
            textBoxRemarks.Text = "";
        }

        internal void GetTableRowSetTextBox()
        {
            labelUniqueId.Text = dataGridView1.CurrentRow.Cells["UniqueId"].Value.ToString();
            textBoxShohinCode.Text = dataGridView1.CurrentRow.Cells["ShohinCode"].Value.ToString();
            textBoxShohinName.Text = dataGridView1.CurrentRow.Cells["ShohinName"].Value.ToString();
            textBoxRemarks.Text = dataGridView1.CurrentRow.Cells["Remarks"].Value.ToString();
        }

        internal void DataGridSetting()
        {
            dataGridView1.Columns["UniqueId"].HeaderText = "ユニークID";
            dataGridView1.Columns["ShohinCode"].HeaderText = "商品番号";
            dataGridView1.Columns["ShohinName"].HeaderText = "商品名";
            dataGridView1.Columns["EditDate"].HeaderText = "編集日付";
            dataGridView1.Columns["EditTime"].HeaderText = "編集時刻";
            dataGridView1.Columns["Remarks"].HeaderText = "備考";
            dataGridView1.Columns["UniqueId"].Width = 230;
            dataGridView1.Columns["ShohinCode"].Width = 70;
            dataGridView1.Columns["EditDate"].Width = 80;
            dataGridView1.Columns["EditTime"].Width = 80;
            dataGridView1.Columns["Remarks"].Width = 170;
            dataGridView1.Columns["EditDate"].DefaultCellStyle.Format = "0000/00/00";
            dataGridView1.Columns["EditTime"].DefaultCellStyle.Format = "00:00:00";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
        }
    }
}
