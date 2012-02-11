using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OGAni.Scripts;
using Microsoft.Xna.Framework.Graphics;
using OGAni.Entities;
using System.Globalization;

namespace OGAni.Frames
{
    public class KeyFrame
    {
        protected Frame frame;
        protected string scripts;
        protected KeyFrameScript script;
        public string name;
        public float duration;

        public KeyFrame()
            :this(null, 0f, "KeyFrame", "")
        {
        }

        public KeyFrame(Frame frameRef, float duration, string name, string scripts)
        {
            this.frame = frameRef;
            this.duration = duration;
            this.name = name;
            this.scripts = scripts;
            this.script = new KeyFrameScript(scripts);
        }

        public void RunScript()
        {
            script.Run();
        }

        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < frame.parts.Count; i++)
            {
                Entity f = frame.parts[i];
                f.Draw(sb);
            }
        }

        public string ToSaveString()
        {
            string s = "";

            s += name + "\n";
            s += duration.ToString(CultureInfo.InvariantCulture) + "\n";
            s += scripts.Length + "\n";
            for (int i = 0; i < scripts.Length; i++)
            {
                s += scripts[i] + "\n";
            }
            
            return s;
        }
    }
}
