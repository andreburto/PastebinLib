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
        public Form1()
        {
            InitializeComponent();
            pb = new Pastebin();
        }
        private void btnGet_Click(object sender, EventArgs e)
        {
            textBox3.Text = pb.GetPost(txtUrlKey.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hashtable langs = PastebinOptions.Expires;
            string hold_me = "";

            foreach (string key in langs.Keys.Cast<string>().OrderBy(c => c))
            {
                hold_me += String.Format("{0} = {1}\r\n", key, langs[key].ToString());
            }

            textBox3.Text = hold_me;
        }
    }
}
