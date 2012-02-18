using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using OGAni.Animations;
using System.IO;
using OGAni.Frames;
using OGAni.Entities;
using OGAniEditor.Drawhelpers;

namespace OGAniEditor
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private IntPtr drawSurface;

        Texture2D pixel;
        Rectangle screen;

        Texture2D currentTexture;
        Vector2 textureOffset = Vector2.Zero;

        AnimationCollection animations;
        private int selectedAnimation = -1;
        private Frame selectedFrame;
        private int selectedPart = -1;


        Vector2 framePos = new Vector2(1280 / 2, 720 / 2);
        
        #region Setup

        public Game1(IntPtr drawSurface)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            this.drawSurface = drawSurface;
            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
            System.Windows.Forms.Control.FromHandle((this.Window.Handle)).VisibleChanged += new EventHandler(Game1_VisibleChanged);
            animations = new AnimationCollection();
            Reset();
        }

        void Game1_VisibleChanged(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Control.FromHandle((this.Window.Handle)).Visible == true)
            {
                System.Windows.Forms.Control.FromHandle((this.Window.Handle)).Visible = false;
            }
        }
        void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = drawSurface;
        }
        
        #endregion

        public AnimationCollection Animations
        {
            get { return animations; }
            set 
            { 
                animations = value;
                Reset();
            }
        }

        /// <summary>
        /// Resets the game
        /// </summary>
        public void Reset()
        {
            selectedAnimation = -1;
            selectedPart = -1;
            selectedFrame = null;
        }

        public void SetTexture(string path)
        {
            try
            {
                Texture2D texture = Texture2D.FromStream(GraphicsDevice, File.OpenRead(path));
                currentTexture = texture;
                foreach (Frame f in animations.allFrames)
	            {
		            f.SetTexture(texture);                
	            }
                textureOffset = Vector2.Zero;
            }
            catch (Exception ex)
            {
            }
        }

        public Frame NewFrame()
        {
            Frame f = new Frame();
            f.SetTexture(currentTexture);
            animations.allFrames.Add(f);
            return f;
        }

        public void SelectFrame(Frame f)
        {
            selectedFrame = f;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });
            screen = new Rectangle(0, 0, 1280, 720);
        }

        KeyboardState oldkey, key;
        MouseState om, m;
        Rectangle source = new Rectangle();
        protected override void Update(GameTime gameTime)
        {
            Mouse.WindowHandle = drawSurface;
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            oldkey = key;
            om = m;
            m = Mouse.GetState();
            key = Keyboard.GetState();

            if (selectedAnimation > -1)
            {
                animations.animations[selectedAnimation].Update(time);
            }

            #region Select statements

            if (key.IsKeyDown(Keys.LeftControl))
            {
                if (selectedFrame != null)
                {
                    if (key.IsKeyDown(Keys.A) && oldkey.IsKeyUp(Keys.A))
                    {
                        //Add part
                        Entity part = new Entity()
                        {
                            texture = currentTexture,
                            position = Vector2.Zero,
                            Source = new Rectangle(0, 0, 128, 128)
                        };
                        selectedFrame.parts.Add(part);
                        selectedPart = selectedFrame.parts.IndexOf(part);
                    }
                }
            }
            
            #endregion

            #region Transformation

            if (key.IsKeyUp(Keys.LeftControl))
            {
                if (selectedFrame != null)
                {
                    if (selectedPart != -1)
                    {
                        Entity part = selectedFrame.parts[selectedPart];
                        //Transform
                        if (m.LeftButton == ButtonState.Pressed)
                        {
                            part.position += new Vector2(m.X - om.X, m.Y - om.Y) * 0.5f;
                        }
                        if (m.RightButton == ButtonState.Pressed)
                        {
                            part.rotation += (m.Y - om.Y) * 0.01f;
                        }
                        if (m.MiddleButton == ButtonState.Pressed)
                        {
                            part.scale += (m.Y - om.Y) * 0.001f;
                        }
                        if (key.IsKeyDown(Keys.NumPad1))
                        {
                            part.scale = 1f;
                        }
                        if(key.IsKeyDown(Keys.NumPad0))
                        {
                            part.rotation = 0f;
                        }
                    }

                    //Select part
                    if (key.IsKeyDown(Keys.Escape))
                    {
                        selectedPart = -1;
                    }
                    else
                    {
                        if (oldkey.IsKeyUp(Keys.Left) && key.IsKeyDown(Keys.Left))
                        {
                            selectedPart--;
                            if(selectedPart < 0){
                                selectedPart = selectedFrame.parts.Count - 1;
                            }
                        }
                        if (oldkey.IsKeyUp(Keys.Right) && key.IsKeyDown(Keys.Right))
                        {
                            selectedPart++;
                            if(selectedPart > selectedFrame.parts.Count - 1){
                                selectedPart = selectedFrame.parts.Count == 0 ? -1 : 0;
                            }
                        }
                    }

                }
            }
            
            #endregion

            #region Select source

            if (key.IsKeyDown(Keys.LeftShift))
            {
                if (m.MiddleButton == ButtonState.Pressed)
                {
                    textureOffset += new Vector2(m.X - om.X, m.Y - om.Y);
                }
                if (m.LeftButton == ButtonState.Pressed && om.LeftButton == ButtonState.Released)
                {
                    source.X = m.X + (int)textureOffset.X;
                    source.Y = m.Y + (int)textureOffset.Y;
                }
                else if (m.LeftButton == ButtonState.Pressed)
                {
                    source.Width = (m.X + (int)textureOffset.X) - source.X;
                    source.Height = (m.Y + (int)textureOffset.Y) - source.Y;
                    if (m.RightButton == ButtonState.Pressed)
                    {
                        source.X += m.X - om.X;
                        source.Y += m.Y - om.Y;
                    }
                    //Update in real time
                    if (selectedFrame != null && selectedPart > -1)
                    {
                        selectedFrame.parts[selectedPart].Source = source;
                    }
                }
                else if (m.LeftButton == ButtonState.Released && om.LeftButton == ButtonState.Pressed)
                {
                    //Save it
                    if (selectedFrame != null && selectedPart > -1)
                    {
                        selectedFrame.parts[selectedPart].Source = source;
                    }
                }
            }
            else
            {
                source = Rectangle.Empty;
            }
            
            #endregion
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            if (selectedAnimation > -1)
            {
                animations.animations[selectedAnimation].Draw(spriteBatch, new Vector2(1000, 15));
            }

            if (selectedFrame != null)
            {
                spriteBatch.Begin();
                selectedFrame.Draw(spriteBatch, framePos);
                if (selectedPart != -1)
                {
                    Entity part = selectedFrame.parts[selectedPart];
                    Rectangle rect = part.FullRect;
                    rect.X += (int)framePos.X;
                    rect.Y += (int)framePos.Y;
                    spriteBatch.DrawOutline(pixel, rect, Color.Yellow);
                }
                //TODO: draw borders
                //TODO: don't draw if texture is unset
                spriteBatch.End();
            }

            if (key.IsKeyDown(Keys.LeftShift))
            {
                spriteBatch.Begin();
                spriteBatch.Draw(pixel, screen, Color.Black * 0.4f);
                if (currentTexture != null)
                {
                    spriteBatch.Draw(currentTexture, textureOffset, Color.White);
                    if (source != Rectangle.Empty)
                    {
                        spriteBatch.Draw(pixel, source, Color.Yellow * 0.4f);
                    }
                }
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
