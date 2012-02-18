using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OGAni.Entities;
using Microsoft.Xna.Framework.Graphics;

namespace OGAni.Frames
{
    public class Frame
    {
        public string name;
        public List<Entity> parts;

        public Frame()
            :this(new List<Entity>(), "Frame")
        {
        }
        public Frame(List<Entity> parts, string name)
        {
            this.parts = parts;
            this.name = name;
        }

        public void SetTexture(Texture2D texture)
        {
            for (int i = 0; i < parts.Count; i++)
            {
                parts[i].texture = texture;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Entity e in parts)
            {
                e.Draw(sb);
            }
        }

        public void Draw(SpriteBatch sb, bool debug, Texture2D pixel)
        {
            if (debug)
            {
                foreach (Entity e in parts)
                {
                    e.Draw(sb);
                }
            }
            else
            {
                Draw(sb);
            }
        }

        public string ToSaveString()
        {
            string s = "";

            s += name + "\n";

            foreach (Entity e in parts)
            {
                s += e.ToSaveString();
            }

            return s;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
