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
    public class Level16
    {
        private Texture2D level16Background;
        private string level16Text;
        private List<char> level16Chars;
        private SpriteFont level16StoryText;

        public bool textDone { get; set; }

        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public void Initialize()
        {
            textDone = false;
            level16Text = "...What's that?";
            level16Chars = new List<char>();
            foreach (var c in level16Text)
            {
                level16Chars.Add(c);
            }
            level16Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level16Background = Content.Load<Texture2D>("level16");
            level16StoryText = Content.Load<SpriteFont>("MainGameTitle");
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level16Chars.Count > 0)
            {
                if (rand.Next(0, 4) > 1)
                {
                    level16Text += level16Chars[0];
                    level16Chars.RemoveAt(0);
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
            spriteBatch.Draw(level16Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(level16StoryText, level16Text, new Vector2((LEVEL_WIDTH / 2) - level16Text.Length * 5, 280), Color.White);
        }
    }
}
