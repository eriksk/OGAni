using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OGAniEditor;
using OGAni.Frames;

namespace OGAniEditorWinForms
{
    public partial class Animations : Form
    {
        public Animations()
        {
            InitializeComponent();
        }

        private Game1 Game
        {
            get { return (MdiParent as Form1).game; }
        }

        private void buttonNewFrame_Click(object sender, EventArgs e)
        {
            Frame frame = Game.NewFrame();
            listBoxFrames.Items.Add(frame);
        }

        private void buttonDeleteFrame_Click(object sender, EventArgs e)
        {
            Frame f = (Frame)listBoxFrames.SelectedItem;
            if (f != null)
            {
                listBoxFrames.Items.Remove(f);
                Game.Animations.allFrames.Remove(f);
                //Select first again
                if (listBoxFrames.Items.Count > 0)
                {
                    listBoxFrames.SelectedIndex = 0;
                }
            }
        }

        private void listBoxFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            Frame f = (Frame)listBoxFrames.SelectedItem;
            Game.SelectFrame(f);            
        }
    }
}
