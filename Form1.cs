using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PastebinLib;
namespace PastebinLib
{
    public partial class Form1 : Form
    {
        private Pastebin pb;
        private PastebinArgs pba;
        public Form1()
        {
            InitializeComponent();
            pb = new Pastebin();
            pba = new PastebinArgs();
            txtDevKey.Text = "";
        }
        private void btnGet_Click(object sender, EventArgs e)
        {
            if (txtUrlKey.Text.Length == 0) { return; }
            textBox3.Text = pb.GetPost(txtUrlKey.Text);
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0) { return; }
            pba.api_dev_key = txtDevKey.Text;
            pba.api_paste_expire_date = "1H";
            pba.api_option = "paste";
            pba.api_paste_code = textBox3.Text;
            MessageBox.Show(pba.ToString());
            string res = pb.NewPaste(pba.ToHashtable());
            txtUrlKey.Text = res;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
