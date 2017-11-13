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
    public class Level17
    {
        private Texture2D level17Background;
        private string level17Text;
        private List<char> level17Chars;
        private SpriteFont level17StoryText;

        public bool textDone { get; set; }

        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public void Initialize()
        {
            textDone = false;
            level17Text = "Turn around!";
            level17Chars = new List<char>();
            foreach (var c in level17Text)
            {
                level17Chars.Add(c);
            }
            level17Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level17Background = Content.Load<Texture2D>("level17");
            level17StoryText = Content.Load<SpriteFont>("MainGameTitle");
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level17Chars.Count > 0)
            {
                if (rand.Next(0, 4) > 1)
                {
                    level17Text += level17Chars[0];
                    level17Chars.RemoveAt(0);
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
            spriteBatch.Draw(level17Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(level17StoryText, level17Text, new Vector2(((LEVEL_WIDTH / 2) - level17StoryText.Texture.Width / 2) + 35, 350), Color.White);
        }
    }
}
