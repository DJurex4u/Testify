﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Testify
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblTestName_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            StringBuilder text = new StringBuilder();
            text
            .Append(txtBaseUrl.Text)
            .Append("/")
            .Append(txtEndpoint.Text)
            .Append(comboHttpMethods.Text)
            .Append(" ")
            .Append(txtHeaders.Text)
            .Append(" ")
            .Append(" kraj ");
            txtBody.Text = text.ToString();
         
            if (comboHttpMethods.Text == "GET")
            {
                txtBody.Text = "ssdfsdfsdfsdfsdfsdfsdffsfds";
            }
            //if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            //    lstNames.Items.Add(txtName.Text);
        }
    }
}
