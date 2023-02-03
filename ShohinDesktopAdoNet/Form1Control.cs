using ShohinDesktopAdoNet.FormDesigns;
using ShohinDesktopAdoNet.Models.AppServices;
using ShohinDesktopAdoNet.Models.DomainObjects;
using ShohinDesktopAdoNet.Models.Repositorys;
using System.Windows.Forms;

namespace ShohinDesktopAdoNet
{
    public partial class Form1Control : Form
    {
        private ShohinAppService service = new ShohinAppService(new ShohinRepository());
        private Form1Design fDesign = new Form1Design();
        private BindingSource bindingSource1;

        public Form1Control()
        {
            InitializeComponent();
            fDesign.Setting();
            FormDesignSetting();
        }

        private void Form1Control_Load(object sender, EventArgs e)
        {

        }

        private void ButtonRead_Click(object sender, EventArgs e)
        {
            var list = service.GetAllShohinList();

            fDesign.dataGridView1.DataSource = list;
            fDesign.DataGridSetting();
            fDesign.richTextBox1.AppendText("全件表示しました。");
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                service.RegisterShohin(fDesign.textBoxShohinCode.Text, fDesign.textBoxShohinName.Text, fDesign.textBoxRemarks.Text);
            }
            catch (BusinessAppException ex)
            {
                MsgDialogModal(ex.Message, "", MessageBoxIcon.Warning);
            }
            catch (DomainObjectException ex2)
            {
                MsgDialogModal(ex2.Message, "", MessageBoxIcon.Warning);
            }
            
            MsgDialogModal("1件登録しました。", "メッセージ", MessageBoxIcon.Information);
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            var id = fDesign.labelUniqueId.Text;
            var code = fDesign.textBoxShohinCode.Text;
            var name = fDesign.textBoxShohinName.Text;
            var note = fDesign.textBoxRemarks.Text;
            service.EditShohin(id, code, name, note);
            MessageBox.Show("該当商品の内容を変更しました。");
        }

        private void ButtonErase_Click(object sender, EventArgs e)
        {
            service.RemoveShohin(fDesign.labelUniqueId.Text);
            MessageBox.Show("該当商品を削除しました。");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fDesign.GetTableRowSetTextBox();
        }

        private void FormDesignSetting()
        {
            this.Name = "form1Control";
            this.Text = "商品管理アプリ ADO.NET(.NET Core) + デスクトップアプリ + SQL Server";
            this.Location = new Point(500, 200);
            this.ClientSize = new Size(800, 600);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.AutoScaleDimensions = new SizeF(7F, 15F);
            //this.AutoScaleMode = AutoScaleMode.Font;
            this.Load += new System.EventHandler(this.Form1Control_Load);

            Controls.Add(fDesign.dataGridView1);
            fDesign.dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);

            Controls.Add(fDesign.richTextBox1);

            bindingSource1 = new BindingSource();
            //Controls.Add(fDesign.bindingSource1);

            Controls.Add(fDesign.buttonRead);
            fDesign.buttonRead.Click += new System.EventHandler(this.ButtonRead_Click);

            Controls.Add(fDesign.buttonAdd);
            fDesign.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);

            Controls.Add(fDesign.buttonChange);
            fDesign.buttonChange.Click += new System.EventHandler(this.ButtonChange_Click);

            Controls.Add(fDesign.buttonErase);
            fDesign.buttonErase.Click += new System.EventHandler(ButtonErase_Click);

            foreach (var label in fDesign.labelDic)
            {
                Controls.Add(label.Value);
            }

            Controls.Add(fDesign.labelUniqueId);
            Controls.Add(fDesign.labelFoot);
            Controls.Add(fDesign.textBoxShohinCode);
            Controls.Add(fDesign.textBoxShohinName);
            Controls.Add(fDesign.textBoxRemarks);
        }

        private void MsgDialogModal(string message, string title, MessageBoxIcon type)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, type);
        }
    }
}