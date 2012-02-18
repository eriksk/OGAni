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
            this.script = new KeyFrameScript(scripts);
        }

        public string[] Scripts
        {
            get { return scripts; }
            set { scripts = value; }
        }

        public void RunScript()
        {
            script.Run();
        }

        public void Draw(SpriteBatch sb, Vector2 position)
        {
            for (int i = 0; i < frame.parts.Count; i++)
            {
                Entity f = frame.parts[i];
                f.Draw(sb, position);
            }
        }

        public string ToSaveString()
        {
            string s = "";

            s += frame.name + "\n";
            s += duration.ToString(CultureInfo.InvariantCulture) + "\n";
            s += scripts.Length + "\n";
            for (int i = 0; i < scripts.Length; i++)
            {
                s += scripts[i] + "\n";
            }
            
            return s;
        }

        public override string ToString()
        {
            return frame == null ? "" : frame.name;
        }
    }
}
