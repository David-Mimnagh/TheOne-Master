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
    public class Level14
    {
        private Texture2D level14Background;
        private string level14Text;
        private List<char> level14Chars;
        private SpriteFont level14StoryText;

        public bool textDone { get; set; }

        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public void Initialize()
        {
            textDone = false;
            level14Text = "But now we need to move on to the next step...";
            level14Chars = new List<char>();
            foreach (var c in level14Text)
            {
                level14Chars.Add(c);
            }
            level14Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level14Background = Content.Load<Texture2D>("level14");
            level14StoryText = Content.Load<SpriteFont>("MainGameTitle");
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level14Chars.Count > 0)
            {
                if (rand.Next(0, 4) > 1)
                {
                    level14Text += level14Chars[0];
                    level14Chars.RemoveAt(0);
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
            spriteBatch.Draw(level14Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(level14StoryText, level14Text, new Vector2((LEVEL_WIDTH / 2) - level14Text.Length * 4.5f, 280), Color.White);
        }
    }
}
