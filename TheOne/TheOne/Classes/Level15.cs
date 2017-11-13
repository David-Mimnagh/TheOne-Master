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
    public class Level15
    {
        private Texture2D level15Background;
        private string level15Text;
        private List<char> level15Chars;
        private SpriteFont level15StoryText;

        public bool textDone { get; set; }

        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public void Initialize()
        {
            textDone = false;
            level15Text = "Hmm... Keep walking!";
            level15Chars = new List<char>();
            foreach (var c in level15Text)
            {
                level15Chars.Add(c);
            }
            level15Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level15Background = Content.Load<Texture2D>("level15");
            level15StoryText = Content.Load<SpriteFont>("MainGameTitle");
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level15Chars.Count > 0)
            {
                if (rand.Next(0, 4) > 1)
                {
                    level15Text += level15Chars[0];
                    level15Chars.RemoveAt(0);
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
            spriteBatch.Draw(level15Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(level15StoryText, level15Text, new Vector2((LEVEL_WIDTH / 2) - level15Text.Length * 4, 280), Color.White);
        }
    }
}
