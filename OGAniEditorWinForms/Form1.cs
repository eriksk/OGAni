using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OGAniEditor;

namespace OGAniEditorWinForms
{
    public partial class Form1 : Form
    {
        public Game1 game;
        Animations ani = new Animations();
        Editor editor = new Editor();
        private string path = "";
            
        public Form1()
        {
            InitializeComponent();
            editor.MdiParent = this;
            editor.Show();
            ani.MdiParent = this;
            ani.Show();
            FormClosing += new FormClosingEventHandler(Form1_FormClosing);

            toolStripStatusLabel1.Text = "No file loaded";
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ani.Close();
            editor.Close();
            game.Exit();
        }

        public IntPtr GetDrawSurface()
        {
            return editor.GetDrawSurface();
        }

        #region Menu


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void layoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a .png";
            ofd.ShowDialog();
            string path = ofd.FileName;
            if (!string.IsNullOrEmpty(path))
            {
                game.SetTexture(path);
            }
        }

        #endregion

    }
}
