using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OGAni.Animations;
using System.IO;
using OGAni.Frames;

namespace OGAni.IO
{
    public class AnimationIO
    {
        private AnimationIO()
        {
        }

        public static void Save(AnimationCollection a, string path)
        {
            using (StreamWriter w = new StreamWriter(path))
            {
                w.WriteLine(a.name);
                foreach (Frame f in a.allFrames)
                {
                    w.WriteLine(f.ToSaveString());
                }
                foreach (Animation ani in a.animations)
                {
                    w.WriteLine(ani.ToSaveString());
                }
            }
        }

        public static AnimationCollection Load(string path)
        {
            return new AnimationCollection();
        }
    }
}
