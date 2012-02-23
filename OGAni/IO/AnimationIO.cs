using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OGAni.Animations;
using System.IO;
using OGAni.Frames;
using OGAni.Entities;
using System.Globalization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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
                //Metadata separate by |
                w.WriteLine(a.name + "|" + a.texture);
                
                //1. Framecount
                w.WriteLine(a.allFrames.Count);
                
                //2. Frames
                foreach (Frame f in a.allFrames)
                {
                    w.WriteLine(f.name);
                    //2.1 Parts
                    w.WriteLine(f.parts.Count);
                    foreach (Entity e in f.parts)
                    {
                        w.WriteLine(e.position.X.ToString(CultureInfo.InvariantCulture) + "|" + e.position.Y.ToString(CultureInfo.InvariantCulture));
                        w.WriteLine(e.rotation.ToString(CultureInfo.InvariantCulture));
                        w.WriteLine(e.scale.ToString(CultureInfo.InvariantCulture));
                        w.WriteLine(e.flipped); 
                        w.WriteLine(e.Source.X + "|" + e.Source.Y + "|" + e.Source.Width + "|" + e.Source.Height);
                    }
                }
                
                //3. AnimationCount
                w.WriteLine(a.animations.Count);

                //4. Animations
                foreach (Animation ani in a.animations)
                {
                    w.WriteLine(ani.name);
                    //4.1 Keyframes
                    w.WriteLine(ani.KeyFrames.Count);
                    foreach (KeyFrame kf in ani.KeyFrames)
                    {
                        w.WriteLine(a.allFrames.IndexOf(kf.Frame));
                        w.WriteLine(kf.Duration.ToString(CultureInfo.InvariantCulture));
                        //4.1.1 Scripts
                        w.WriteLine(kf.Scripts.Length);
                        foreach (string s in kf.Scripts)
                        {
                            w.WriteLine(s);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Loads the animations and sets the appropriate texture
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static AnimationCollection Load(string path, ContentManager content, string assetPath)
        {
            AnimationCollection anis = Load(path);
            Texture2D tex = content.Load<Texture2D>(assetPath + anis.AssetName);
            anis.allFrames.ForEach(i => i.SetTexture(tex));
            return anis;
        }
        public static AnimationCollection Load(string path)
        {
            string name = "";
            List<Frame> allFrames = new List<Frame>();
            List<Animation> animations = new List<Animation>();
            string texture = "";

            using (StreamReader r = new StreamReader(path))
            { 
                //Metadata separate by |
                string[] line = r.ReadLine().Split('|');
                name = line[0];
                texture = line[1];

                //1. Framecount
                int frameCount = int.Parse(r.ReadLine());

                //2. Frames
                for (int i = 0; i < frameCount; i++)
                {
                    string fName = r.ReadLine();
                    List<Entity> frameParts = new List<Entity>();
                    int fpCount = int.Parse(r.ReadLine());
                    for (int j = 0; j < fpCount; j++)
                    {
                        string[] xy = r.ReadLine().Split('|');
                        Vector2 pos = new Vector2(float.Parse(xy[0], CultureInfo.InvariantCulture), float.Parse(xy[1], CultureInfo.InvariantCulture));
                        float rotation = float.Parse(r.ReadLine(), CultureInfo.InvariantCulture);
                        float scale = float.Parse(r.ReadLine(), CultureInfo.InvariantCulture);
                        bool flipped = bool.Parse(r.ReadLine());
                        string[] rect = r.ReadLine().Split('|');
                        Rectangle source = new Rectangle(int.Parse(rect[0]), int.Parse(rect[1]), int.Parse(rect[2]), int.Parse(rect[3]));
                        Entity fp = new Entity()
                        {
                            position = pos,
                            rotation = rotation,
                            scale = scale,
                            flipped = flipped,
                            Source = source
                        };
                        frameParts.Add(fp);
                    }
                    Frame f = new Frame(frameParts, fName);
                    allFrames.Add(f);
                }

                int animCount = int.Parse(r.ReadLine());

                for (int i = 0; i < animCount; i++)
                {
                    string animName = r.ReadLine();
                    List<KeyFrame> keyframes = new List<KeyFrame>();
                    int kfCount = int.Parse(r.ReadLine());
                    for (int j = 0; j < kfCount; j++)
                    {
                        int frameIdx = int.Parse(r.ReadLine());
                        float duration = float.Parse(r.ReadLine(), CultureInfo.InvariantCulture);
                        int scriptCount = int.Parse(r.ReadLine());
                        string[] scripts = new string[scriptCount];
                        for (int x = 0; x < scriptCount; x++)
                        {
                            scripts[x] = r.ReadLine();
                        }
                        keyframes.Add(new KeyFrame(allFrames[frameIdx], duration, scripts));
                    }

                    animations.Add(new Animation(keyframes, animName));
                }
            }

            return new AnimationCollection(name, allFrames, animations, texture);
        }
    }
}
