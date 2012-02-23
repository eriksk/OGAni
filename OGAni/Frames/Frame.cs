using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OGAni.Entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

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

        public Frame Clone()
        {
            List<Entity> fps = new List<Entity>();
            foreach (Entity e in parts)
            {
                fps.Add(e.Clone());
            }
            Frame f = new Frame(fps, name);
            return f;
        }

        public void SetTexture(Texture2D texture)
        {
            for (int i = 0; i < parts.Count; i++)
            {
                parts[i].texture = texture;
            }
        }

        public void Draw(SpriteBatch sb, Vector2 position, bool flipped)
        {
            Vector2 pos = Vector2.Zero;
            for (int i = 0; i < parts.Count; i++)
            {
                Entity f = parts[i];
                pos.X = position.X + (flipped ? -f.position.X : f.position.X);
                pos.Y = position.Y + f.position.Y;
                sb.Draw(f.texture,
                        pos,
                        f.Source,
                        Color.White,
                        flipped ? -f.rotation : f.rotation,
                        f.origin,
                        f.scale,
                        flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                        1f);
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
