using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OGAni.Scripts;
using Microsoft.Xna.Framework.Graphics;
using OGAni.Entities;
using System.Globalization;
using Microsoft.Xna.Framework;

namespace OGAni.Frames
{
    public class KeyFrame
    {
        protected Frame frame;
        protected string[] scripts;
        protected KeyFrameScript script;
        public float duration;

        public KeyFrame()
            :this(null, 0f, new string[0])
        {
        }

        public KeyFrame(Frame frameRef, float duration, string[] scripts)
        {
            this.frame = frameRef;
            this.duration = duration;
            this.scripts = scripts;
        }

        public string[] Scripts
        {
            get { return scripts; }
            set { scripts = value; }
        }

        public Frame Frame
        {
            get { return frame; }
        }

        public float Duration
        {
            get { return duration; }
        }

        public virtual void RunScript()
        {
        }

        public void Draw(SpriteBatch sb, Vector2 position, bool flipped)
        {
            frame.Draw(sb, position, flipped);
        }

        public override string ToString()
        {
            return frame == null ? "" : frame.name;
        }
    }
}
