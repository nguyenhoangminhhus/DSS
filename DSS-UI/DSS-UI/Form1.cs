using DSS_UI.DA;
using DSS_UI.Models;
using DSS_UI.Untils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSS_UI
{
    public partial class Form1 : Form
    {
        private string sourceParth = "";
        public Form1()
        {
            InitializeComponent();
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;

           getListPersion();


        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPage1;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            tabControl.SelectedTab = tabPage2;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPage3;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            openFileDialogImageAvatar.ShowDialog();
            string file = openFileDialogImageAvatar.FileName;
            if (string.IsNullOrEmpty(file))
            {
                MessageBox.Show("Vui lòng chọn file", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                try
                {
                    Image myImage = Image.FromFile(file);
                    pictureBoxAvatar.Image = myImage;
                    sourceParth = Path.GetFullPath(openFileDialogImageAvatar.FileName);
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn file là file ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void bunifuThinButtonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string sexual = comboBoxSexual.Text;
            string dateOfBirth = comboBoxYear.Text + "-" + comboBoxMonth.Text + "-" + comboBoxDay.Text;
            string hometown = textBoxHomeTown.Text;
            string position = textBoxPosition.Text;
            if (sourceParth.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập ảnh ");
                return;
            }
            byte[] image = Helper.converseToByte(sourceParth);
            string description = richTextBoxDescription.Text;
            Person person = new Person(0,name, sexual, dateOfBirth, hometown, position, image, description);
            DatabaseProviders databaseProviders = new DatabaseProviders();
            databaseProviders.add(person);

        }

        private void showListView()
        {
            listViewImage.Items.Clear();

        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            getListPersion();
        }

        private void getListPersion()
        {
            
            DatabaseProviders databaseProviders = new DatabaseProviders();
            List<Person> listPersons = databaseProviders.getAllPersion();

            DataGridViewImageColumn dgvImage = new DataGridViewImageColumn();
            dgvImage.HeaderText = "ẢNH";
            dgvImage.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridViewTextBoxColumn dgvId = new DataGridViewTextBoxColumn();
            dgvId.HeaderText = "ID";
            dgvId.Width = 20;
            DataGridViewTextBoxColumn dgvName = new DataGridViewTextBoxColumn();
            dgvName.HeaderText = "TÊN";

            DataGridViewTextBoxColumn dgvDateOfBirth = new DataGridViewTextBoxColumn();
            dgvDateOfBirth.HeaderText = "NGÀY SINH";

            DataGridViewTextBoxColumn dgvPosition = new DataGridViewTextBoxColumn();
            dgvPosition.HeaderText = "CHỨC VỤ";

            
            dataGridViewDS.Columns.Add(dgvId);
            dataGridViewDS.Columns.Add(dgvImage);
            dataGridViewDS.Columns.Add(dgvName);
            dataGridViewDS.Columns.Add(dgvDateOfBirth);
            dataGridViewDS.Columns.Add(dgvPosition);



            dgvPosition.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // dataGridViewDS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDS.RowTemplate.Height = 120;
            dataGridViewDS.AllowUserToAddRows = false;

            for (int i = 0; i < listPersons.Count; i++)
            {
                MemoryStream memStm = new MemoryStream(listPersons.ElementAt(i).image);

                Image image = Image.FromStream(memStm);
                dataGridViewDS.Rows.Add(listPersons.ElementAt(i).id, listPersons.ElementAt(i).image, listPersons.ElementAt(i).name
                    , listPersons.ElementAt(i).dateofbirth, listPersons.ElementAt(i).position);


                Console.WriteLine(listPersons.ElementAt(i).name);
            }

        }

        private void listViewPerson_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {

        }
    }
}
