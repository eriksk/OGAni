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
            using (StreamWriter w = new StreamWriter(path, false))
            {
                w.WriteLine(a.name);
                w.WriteLine(a.texture);
                w.WriteLine(a.allFrames.Count);
                foreach (Frame f in a.allFrames)
                {
                    w.WriteLine(f.ToSaveString());
                }
                w.WriteLine(a.animations.Count);
                foreach (Animation ani in a.animations)
                {
                    w.WriteLine(ani.ToSaveString());
                }
            }
        }

        public static AnimationCollection Load(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {

            }

            return new AnimationCollection();
        }
    }
}
