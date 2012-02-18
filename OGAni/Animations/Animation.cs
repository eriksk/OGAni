using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OGAni.Frames;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OGAni.Entities;
using Microsoft.Xna.Framework;

namespace OGAni.Animations
{
    public class Animation
    {
        protected List<KeyFrame> keyFrames;
        protected int currentFrame;
        protected float current;
        public string name;

        public Animation()
            :this(new List<KeyFrame>(), "Animation")
        {
        }
        public Animation(string name)
            :this(new List<KeyFrame>(), name)
        {
        }
        public Animation(List<KeyFrame> keyFrames, string name)
        {
            this.keyFrames = keyFrames;
            this.name = name;
        }
        
        public void Reset()
        {
            current = 0f;
            currentFrame = 0;
        }

        public virtual void Update(float time)
        {
            if(keyFrames.Count > 0)
            {
                KeyFrame kf = keyFrames[currentFrame];
                current += time;
                if (current > kf.duration)
                {
                    current = 0f;
                    kf.RunScript();
                    currentFrame++;
                    if (currentFrame > keyFrames.Count - 1)
                    {
                        currentFrame = 0;
                    }
                }
            }
        }

        public void Draw(SpriteBatch sb, Vector2 position)
        {
            if (keyFrames.Count > 0)
            {
                KeyFrame kf = keyFrames[currentFrame];
                kf.Draw(sb, position);
            }
        }

        public string ToSaveString()
        {
            string s = "";

            s += name + "\n";
            s += keyFrames.Count + "\n";

            foreach (KeyFrame kf in keyFrames)
            {
                s += kf.ToSaveString();
            }
            
            return s;
        }

    }
}
