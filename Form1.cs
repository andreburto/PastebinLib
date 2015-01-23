using System;
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
        public Form1()
        {
            InitializeComponent();
            pb = new Pastebin();
        }
        private void btnGet_Click(object sender, EventArgs e)
        {
            textBox3.Text = pb.GetPost(txtUrlKey.Text);
        }
    }
}
