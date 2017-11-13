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
    public class Level12
    {
        private Texture2D level12Background;
        private string level12Text;
        private List<char> level12Chars;
        private SpriteFont level12StoryText;

        public bool textDone { get; set; }

        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public void Initialize()
        {
            textDone = false;
            level12Text = "3 years and we were getting more serious.\nWe were house sitting for my Mum this year,\nall that time with you was amazing!";
            level12Chars = new List<char>();
            foreach (var c in level12Text)
            {
                level12Chars.Add(c);
            }
            level12Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level12Background = Content.Load<Texture2D>("level12");
            level12StoryText = Content.Load<SpriteFont>("MainGameTitle");
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level12Chars.Count > 0)
            {
                if (rand.Next(0, 4) > 1)
                {
                    level12Text += level12Chars[0];
                    level12Chars.RemoveAt(0);
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
            spriteBatch.Draw(level12Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(level12StoryText, level12Text, new Vector2((LEVEL_WIDTH / 2) - level12Text.Length * 2.5f, 320), Color.White);
        }
    }
}
