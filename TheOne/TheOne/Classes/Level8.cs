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
   public class Level8
    {
        Texture2D timeTexture;
        private AnimatedSprite timeAnimatedSprite;
        private Texture2D level8Background;
        private string level8Text;
        private List<char> level8Chars;
        private SpriteFont level8StoryText;

        public bool textDone { get; set; }

        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public void Initialize()
        {
            textDone = false;
            level8Text = "The most nervous moment of my life.\nThe time I knew I met my soul mate.\nThe time I asked you out...";
            level8Chars = new List<char>();
            foreach (var c in level8Text)
            {
                level8Chars.Add(c);
            }
            level8Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level8Background = Content.Load<Texture2D>("level8");
            timeTexture = Content.Load<Texture2D>("timeOneSprite");
            timeAnimatedSprite = new AnimatedSprite(timeTexture, 1, 10);
            level8StoryText = Content.Load<SpriteFont>("MainGameTitle");
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level8Chars.Count > 0)
            {
                if (rand.Next(0, 4) > 1)
                {
                    level8Text += level8Chars[0];
                    level8Chars.RemoveAt(0);
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
            spriteBatch.Draw(level8Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            timeAnimatedSprite.Draw(spriteBatch, new Vector2(374, 212));
            spriteBatch.DrawString(level8StoryText, level8Text, new Vector2((LEVEL_WIDTH / 2) - level8Text.Length * 2, 341), Color.White);
        }

    }
}
