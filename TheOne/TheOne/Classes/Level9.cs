using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOne.Classes
{
    public class Level9
    {
        Texture2D timeTexture;
        private AnimatedSprite timeAnimatedSprite;
        private Texture2D level9Background;
        private string level9Text;
        private List<char> level9Chars;
        private SpriteFont level9StoryText;

        public bool textDone { get; set; }

        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public void Initialize()
        {
            textDone = false;
            level9Text = "The time you changed my life.\nThe time you got my heart for good.\nThe time you said yes.";
            level9Chars = new List<char>();
            foreach (var c in level9Text)
            {
                level9Chars.Add(c);
            }
            level9Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level9Background = Content.Load<Texture2D>("level8");
            timeTexture = Content.Load<Texture2D>("timeTwoSprite");
            timeAnimatedSprite = new AnimatedSprite(timeTexture, 1, 10);
            level9StoryText = Content.Load<SpriteFont>("MainGameTitle");
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level9Chars.Count > 0)
            {
                if (rand.Next(0, 4) > 1)
                {
                    level9Text += level9Chars[0];
                    level9Chars.RemoveAt(0);
                }
            }
            else
            {
                textDone = true;
            }
        }
        public void Update(GameTime gameTime)
        {
            timeAnimatedSprite.Update();
        }



        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.Draw(level9Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            timeAnimatedSprite.Draw(spriteBatch, new Vector2(374, 212));
            spriteBatch.DrawString(level9StoryText, level9Text, new Vector2((LEVEL_WIDTH / 2) - level9Text.Length * 2, 341), Color.White);
        }
    }
}
