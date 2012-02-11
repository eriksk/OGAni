using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OGAni.Entities;

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
    }
}
