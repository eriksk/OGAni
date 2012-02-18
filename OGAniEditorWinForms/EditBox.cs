using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OGAniEditorWinForms
{
    public partial class EditBox : Form
    {
        private object obj;

        public EditBox(object obj)
        {
            this.obj = obj;
            InitializeComponent();
            textBox1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Save
            try
            {
                obj.GetType().GetField("name").SetValue(obj, textBox1.Text);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Cancel
            this.Close();
        }
    }
}
