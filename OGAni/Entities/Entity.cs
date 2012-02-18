using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Globalization;

namespace OGAni.Entities
{
    public class Entity
    {
        public Texture2D texture;

        private Rectangle source;
        public Vector2 position, origin;
        public float rotation, scale;
        public bool flipped;

        public Entity()
            :this(Vector2.Zero, new Rectangle(0, 0, 64, 64), 0f, 1f, false)
        {
            scale = 1f;            
        }

        public Entity(Vector2 position, Rectangle source, float rotation, float scale, bool flipped)
        {
            this.position = position;
            this.source = source;
            this.rotation = rotation;
            this.scale = scale;
            this.flipped = flipped;
            origin = new Vector2(source.Width / 2f, source.Height / 2f);
        }

        public Rectangle Source
        {
            get { return source; }
            set
            { 
                source = value;
                origin.X = source.Width / 2f;
                origin.Y = source.Height / 2f;
            }
        }

        public void Draw(SpriteBatch sb, Vector2 position)
        {
            sb.Draw(texture, 
                    this.position + position, 
                    source, 
                    Color.White, 
                    rotation, 
                    origin, 
                    scale, 
                    flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                    1f);
        }

        public string ToSaveString()
        {
            string s = "";

            s += source.X + ":" + source.Y + ":" + source.Width + ":" + source.Height + "\n";
            s += position.X.ToString(CultureInfo.InvariantCulture) + ":" + position.Y.ToString(CultureInfo.InvariantCulture) + "\n";
            s += rotation.ToString(CultureInfo.InvariantCulture) + "\n";
            s += scale.ToString(CultureInfo.InvariantCulture) + "\n";
            s += flipped.ToString() + "\n";

            return s;
        }
    }
}
