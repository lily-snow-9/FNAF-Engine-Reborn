﻿using System;
using System.IO;
using System.Windows.Forms;

namespace FNAF_Engine_Reborn
{
    public partial class Deleteproject : Form
    {
        public Deleteproject()
        {
            InitializeComponent();
        }

        private void Deleteproject_VisibleChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(System.IO.Directory.GetDirectories(@"assets/custom_assets/projects/"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select an project!");
            }
            else
            {
                string CurrentProject = comboBox1.SelectedItem.ToString();
                Directory.Delete(CurrentProject, true);
                MessageBox.Show("Project deleted!");
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(System.IO.Directory.GetDirectories(@"assets/custom_assets/projects/"));
            }
        }
    }
}
