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

        Vector2 animPos = new Vector2(1280 - 200, 720 - 200);
        Vector2 framePos = new Vector2(1280 / 2, 720 - 100);
        
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

        public void Clear()
        {
            selectedFrame = null;
            animations = null;
            selectedPart = -1;
            selectedAnimation = -1;
            textureOffset = Vector2.Zero;
            currentTexture = null;
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
                animations.texture = path.Split('/').Last();
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
            //Clone if selected
            Frame f = new Frame();
            if (selectedFrame != null)
            {
                f = selectedFrame.Clone();
            }

            f.SetTexture(currentTexture);
            animations.allFrames.Add(f);
            return f;
        }
        
        public Animation NewAni()
        {
            Animation a = new Animation();
            animations.animations.Add(a);
            return a;
        }

        public KeyFrame NewKeyFrame(Animation ani, Frame frame)
        {
            KeyFrame kf = new KeyFrame(frame, 300, new string[]{"#add script"});
            ani.KeyFrames.Add(kf);
            return kf;
        }

        public void DeselectAnimation()
        {
            selectedAnimation = -1;
        }

        public void SelectFrame(Frame f)
        {
            selectedFrame = f;
            selectedPart = -1;
        }
        
        public void SelectAni(Animation ani)
        {
            selectedAnimation = animations.animations.IndexOf(ani);
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

            if (key.IsKeyUp(Keys.LeftShift))
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
                        //Select
                        if (oldkey.IsKeyUp(Keys.D1) && key.IsKeyDown(Keys.D1))
                        {
                            selectedPart--;
                            if(selectedPart < 0){
                                selectedPart = selectedFrame.parts.Count - 1;
                            }
                        }
                        if (oldkey.IsKeyUp(Keys.D2) && key.IsKeyDown(Keys.D2))
                        {
                            selectedPart++;
                            if(selectedPart > selectedFrame.parts.Count - 1){
                                selectedPart = selectedFrame.parts.Count == 0 ? -1 : 0;
                            }
                        }

                        //Sort order

                        if (oldkey.IsKeyUp(Keys.D3) && key.IsKeyDown(Keys.D3))
                        {
                            int target = selectedPart - 1;
                            if (target > -1)
                            {
                                //Swap
                                Entity temp = selectedFrame.parts[selectedPart];
                                selectedFrame.parts[selectedPart] = selectedFrame.parts[target];
                                selectedFrame.parts[target] = temp;
                                selectedPart--;
                            }                                
                        }
                        if (oldkey.IsKeyUp(Keys.D4) && key.IsKeyDown(Keys.D4))
                        {
                            int target = selectedPart + 1;
                            if (target < selectedFrame.parts.Count)
                            {
                                //Swap
                                Entity temp = selectedFrame.parts[selectedPart];
                                selectedFrame.parts[selectedPart] = selectedFrame.parts[target];
                                selectedFrame.parts[target] = temp;
                                selectedPart++;
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
                spriteBatch.Begin();
                animations.animations[selectedAnimation].Draw(spriteBatch, animPos);
                spriteBatch.End();
            }

            if (selectedFrame != null)
            {
                spriteBatch.Begin();
                //Floor line
                spriteBatch.Draw(pixel, new Rectangle(0, (int)framePos.Y, 1280, 1), Color.Black);
                spriteBatch.Draw(pixel, new Rectangle((int)framePos.X, 0, 1, 720), Color.Black);
                if (currentTexture != null)
                {
                    selectedFrame.Draw(spriteBatch, framePos);
                    if (selectedPart != -1)
                    {
                        Entity part = selectedFrame.parts[selectedPart];
                        Rectangle r = new Rectangle((int)(part.position.X - part.origin.X) + (int)framePos.X, (int)(part.position.Y - part.origin.Y) + (int)framePos.Y, (int)part.origin.X * 2, (int)part.origin.Y * 2);
                        spriteBatch.Draw(pixel, r, Color.Red * 0.1f);                       
                    }
                }
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
