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
            fDesign.richTextBox1.AppendText("�S���\�����܂����B");
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
            
            MsgDialogModal("1���o�^���܂����B", "���b�Z�[�W", MessageBoxIcon.Information);
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            var id = fDesign.labelUniqueId.Text;
            var code = fDesign.textBoxShohinCode.Text;
            var name = fDesign.textBoxShohinName.Text;
            var note = fDesign.textBoxRemarks.Text;
            service.EditShohin(id, code, name, note);
            MessageBox.Show("�Y�����i�̓��e��ύX���܂����B");
        }

        private void ButtonErase_Click(object sender, EventArgs e)
        {
            service.RemoveShohin(fDesign.labelUniqueId.Text);
            MessageBox.Show("�Y�����i���폜���܂����B");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fDesign.GetTableRowSetTextBox();
        }

        private void FormDesignSetting()
        {
            this.Name = "form1Control";
            this.Text = "���i�Ǘ��A�v�� ADO.NET(.NET Core) + �f�X�N�g�b�v�A�v�� + SQL Server";
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