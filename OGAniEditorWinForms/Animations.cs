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
using OGAni.Animations;
using System.Globalization;

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

        public void Clear()
        {
            listBoxAnimations.Items.Clear();
            listBoxFrames.Items.Clear();
            listBoxKeyframes.Items.Clear();
            textBoxDuration.Text = "";
            richTextBoxScript.Text = "";
        }

        public void SetAnimationCollection(AnimationCollection aniColl)
        {
            listBoxFrames.Items.AddRange(aniColl.allFrames.ToArray());
            listBoxAnimations.Items.AddRange(aniColl.animations.ToArray());
        }

        #region Events

        private void buttonNewFrame_Click(object sender, EventArgs e)
        {
            Frame frame = Game.NewFrame();
            listBoxFrames.Items.Add(frame);
        }

        private void buttonDeleteFrame_Click(object sender, EventArgs e)
        {
            Frame f = (Frame)listBoxFrames.SelectedItem;
            //TODO: delete frames from keyframes
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
            listBoxKeyframes.Items.Clear();
        }

        private void listBoxFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            Frame f = (Frame)listBoxFrames.SelectedItem;
            Game.SelectFrame(f);
        }

        private void buttonNewAnimation_Click(object sender, EventArgs e)
        {
            listBoxAnimations.Items.Add(Game.NewAni());
        }

        private void buttonDeleteAnimation_Click(object sender, EventArgs e)
        {
            Animation ani = (Animation)listBoxAnimations.SelectedItem;
            if (ani != null)
            {
                listBoxAnimations.Items.Remove(ani);
                Game.Animations.animations.Remove(ani);
                Game.DeselectAnimation();
                //Select first again
                if (listBoxAnimations.Items.Count > 0)
                {
                    listBoxAnimations.SelectedIndex = 0;
                }
            }
        }

        private void buttonKeyframe_Click(object sender, EventArgs e)
        {
            Frame frame = (Frame)listBoxFrames.SelectedItem;
            Animation ani = (Animation)listBoxAnimations.SelectedItem;
            if (frame != null && ani != null)
            {
                KeyFrame kf = Game.NewKeyFrame(ani, frame);
                UpdateKeyFrames();
            }
        }

        #endregion

        private void UpdateKeyFrames()
        {
            listBoxKeyframes.Items.Clear();
            Animation ani = (Animation)listBoxAnimations.SelectedItem;
            if (ani != null)
            {
                ani.KeyFrames.ForEach(i => listBoxKeyframes.Items.Add(i));
            
            }
            ani.Reset();
        }

        private void listBoxAnimations_SelectedIndexChanged(object sender, EventArgs e)
        {
            Animation ani = (Animation)listBoxAnimations.SelectedItem;
            if (ani != null)
            {
                Game.SelectAni(ani);
            }
            UpdateKeyFrames();
        }

        private void listBoxKeyframes_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyFrame kf = (KeyFrame)listBoxKeyframes.SelectedItem;
            if (kf != null)
            {
                textBoxDuration.Text = kf.duration.ToString(CultureInfo.InvariantCulture);
                richTextBoxScript.Lines = kf.Scripts;
            }
        }

        private void buttonSaveKeyframe_Click(object sender, EventArgs e)
        {
            KeyFrame kf = (KeyFrame)listBoxKeyframes.SelectedItem;
            if (kf != null)
            {
                try
                {
                    kf.duration = float.Parse(textBoxDuration.Text, CultureInfo.InvariantCulture);
                    kf.Scripts = richTextBoxScript.Lines;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void listBoxFrames_DoubleClick(object sender, EventArgs e)
        {
            Frame f = (Frame)listBoxFrames.SelectedItem;
            if(f != null)
            {
                EditBox edb = new EditBox(f);
                edb.ShowDialog();
                listBoxFrames.Items.Clear();
                Game.Animations.allFrames.ForEach(i => listBoxFrames.Items.Add(i));
                listBoxFrames.SelectedItem = f;
            }
        }

        private void listBoxAnimations_DoubleClick(object sender, EventArgs e)
        {
            Animation a = (Animation)listBoxAnimations.SelectedItem;
            if (a != null)
            {
                EditBox edb = new EditBox(a);
                edb.ShowDialog();
                listBoxAnimations.Items.Clear();
                Game.Animations.animations.ForEach(i => listBoxAnimations.Items.Add(i));
                listBoxAnimations.SelectedItem = a;
            }
        }

        private void buttonDeleteKeyframe_Click(object sender, EventArgs e)
        {
            Animation a = (Animation)listBoxAnimations.SelectedItem;
            KeyFrame kf = (KeyFrame)listBoxKeyframes.SelectedItem;
            if (a != null && kf != null)
            {
                a.KeyFrames.Remove(kf);
                UpdateKeyFrames();
            }
        }
    }
}
