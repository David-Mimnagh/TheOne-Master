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
    public class Level13
    {
        private Texture2D level13Background;
        private string level13Text;
        private List<char> level13Chars;
        private SpriteFont level13StoryText;

        public bool textDone { get; set; }

        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public void Initialize()
        {
            textDone = false;
            level13Text = "4 years now and we get to this point...\nWe had an amazing night yesterday,\na lovely dinner and a night to ourselves!";
            level13Chars = new List<char>();
            foreach (var c in level13Text)
            {
                level13Chars.Add(c);
            }
            level13Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level13Background = Content.Load<Texture2D>("level13");
            level13StoryText = Content.Load<SpriteFont>("MainGameTitle");
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level13Chars.Count > 0)
            {
                if (rand.Next(0, 4) > 1)
                {
                    level13Text += level13Chars[0];
                    level13Chars.RemoveAt(0);
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
            spriteBatch.Draw(level13Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(level13StoryText, level13Text, new Vector2((LEVEL_WIDTH / 2) - level13Text.Length * 2, 320), Color.White);
        }
    }
}
