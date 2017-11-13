using System;
using System.Collections.Generic;
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
    public class Level11
    {
        private Texture2D level11Background;
        private string level11Text;
        private List<char> level11Chars;
        private SpriteFont level11StoryText;

        public bool textDone { get; set; }

        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public void Initialize()
        {
            textDone = false;
            level11Text = "2 years on and you were my life...\nWe had a lovely weekend in Edinburgh,\npity we didn't see any giraffes :(...";
            level11Chars = new List<char>();
            foreach (var c in level11Text)
            {
                level11Chars.Add(c);
            }
            level11Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level11Background = Content.Load<Texture2D>("level11");
            level11StoryText = Content.Load<SpriteFont>("MainGameTitle");
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level11Chars.Count > 0)
            {
                if (rand.Next(0, 4) > 1)
                {
                    level11Text += level11Chars[0];
                    level11Chars.RemoveAt(0);
                }
            }
            else
            {
                textDone = true;
            }
        }
        public void Update(GameTime gameTime)
        {

        }



        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.Draw(level11Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(level11StoryText, level11Text, new Vector2((LEVEL_WIDTH / 2) - level11Text.Length * 2, 320), Color.White);
        }
    }
}
