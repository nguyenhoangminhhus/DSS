﻿using DSS.DA;
using DSS.Models;
using DSS.Untils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSS
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
            Person person = new Person(name, sexual, dateOfBirth, hometown, position, image, description);
            DatabaseProviders databaseProviders = new DatabaseProviders();
            databaseProviders.add(person);
            
        }

        private void showListView()
        {
            listViewImage.Items.Clear();
            
        }
    }
}
