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
        
        #region Setup

        public Game1(IntPtr drawSurface)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

        protected override void UnloadContent()
        {
        }

        KeyboardState oldkey, key;
        MouseState om, m;
        protected override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            oldkey = key;
            om = m;
            m = Mouse.GetState();
            key = Keyboard.GetState();

            if (selectedAnimation > -1)
            {
                animations.animations[selectedAnimation].Update(time);
            }

            if (key.IsKeyDown(Keys.LeftShift))
            {
                if (m.MiddleButton == ButtonState.Pressed)
                {
                    textureOffset += new Vector2(m.X - om.X, m.Y - om.Y);
                }
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            if (selectedAnimation > -1)
            {
                animations.animations[selectedAnimation].Draw(spriteBatch);
            }

            if (key.IsKeyDown(Keys.LeftShift))
            {
                spriteBatch.Begin();
                spriteBatch.Draw(pixel, screen, Color.Black * 0.4f);
                if (currentTexture != null)
                {
                    spriteBatch.Draw(currentTexture, textureOffset, Color.White);
                }
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
