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
            pba.paste_key = "";
            pba.api_dev_key = "";
        }
        private void btnGet_Click(object sender, EventArgs e)
        {
            textBox3.Text = pb.GetPost(txtUrlKey.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUrlKey.Text = pba.paste_key;
            textBox3.Text = pba.ToString();
        }
    }
}
