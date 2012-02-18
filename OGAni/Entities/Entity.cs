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
        public string textureName;

        private Rectangle source;
        public Vector2 position, origin;
        public float rotation, scale;
        public bool flipped;

        public Entity()
            :this(Vector2.Zero, new Rectangle(0, 0, 64, 64), 0f, 1f, false, "NO TEXTURE ASSIGNED.")
        {
            scale = 1f;            
        }

        public Entity(Vector2 position, Rectangle source, float rotation, float scale, bool flipped, string textureName)
        {
            this.position = position;
            this.source = source;
            this.rotation = rotation;
            this.scale = scale;
            this.flipped = flipped;
            this.textureName = textureName;
            origin = new Vector2(source.Width / 2f, source.Height / 2f);
        }

        public Rectangle Source
        {
            get { return source; }
            set { source = value; }
        }

        public Rectangle FullRect
        {
            get
            {
                Vector2[] corners = new Vector2[4];
                corners[0] = new Vector2(-origin.X, -origin.Y);
                corners[1] = new Vector2(origin.X, -origin.Y);
                corners[2] = new Vector2(-origin.X, origin.Y);
                corners[3] = new Vector2(origin.X, -origin.Y);

                for (int i = 0; i < corners.Length; i++)
                {
                    corners[i] = RotatePoint(corners[i], position, rotation);
                }
                Vector2 topLeft = corners[0], bottomRight = corners[0];

                for (int i = 0; i < corners.Length; i++)
                {
                    if (corners[i].X < topLeft.X)
                    {
                        topLeft.X = corners[i].X;
                    } 
                    if (corners[i].Y < topLeft.Y)
                    {
                        topLeft.Y = corners[i].Y;
                    }
                    if (corners[i].X > bottomRight.X)
                    {
                        bottomRight.X = corners[i].X;
                    }
                    if (corners[i].Y > bottomRight.Y)
                    {
                        bottomRight.Y = corners[i].Y;
                    }
                }
                Rectangle r = new Rectangle((int)topLeft.X, (int)topLeft.Y, (int)(bottomRight.X - topLeft.X), (int)(bottomRight.Y - topLeft.Y));
                r.X += (int)position.X;
                r.Y += (int)position.Y;
                return r;
            }
        } 
        /// <summary>
        /// Rotates a vector2 around an origin using matrices
        /// </summary>
        /// <param name="point">Point to move</param>
        /// <param name="origin">Origin</param>
        /// <param name="rotation">Rotation amount</param>
        /// <returns>Returns the rotated vector</returns>
        public static Vector2 RotatePoint(Vector2 point, Vector2 origin, float rotation)
        {
            Matrix m =
                Matrix.CreateTranslation(new Vector3(-origin, 0.0f)) *      // translate back to rotate about (0,0) 
                Matrix.CreateRotationZ(rotation) *                            // rotate 
                Matrix.CreateTranslation(new Vector3(origin, 0.0f));        // translate back to origin 

            return Vector2.Transform(point, m);
        }

        public void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>(textureName);
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

            s += textureName + "\n";
            s += source.X + ":" + source.Y + ":" + source.Width + ":" + source.Height + "\n";
            s += position.X.ToString(CultureInfo.InvariantCulture) + ":" + position.Y.ToString(CultureInfo.InvariantCulture) + "\n";
            s += rotation.ToString(CultureInfo.InvariantCulture) + "\n";
            s += scale.ToString(CultureInfo.InvariantCulture) + "\n";
            s += flipped.ToString() + "\n";

            return s;
        }
    }
}
