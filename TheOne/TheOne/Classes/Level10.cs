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
    public class Level10
    {
        private Texture2D level10Background;
        private string level10Text;
        private List<char> level10Chars;
        private SpriteFont level10StoryText;

        public bool textDone { get; set; }

        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public void Initialize()
        {
            textDone = false;
            level10Text = "A year on, I love you more than ever.\nYou made me a lovely candle lit dinner.\nThe year you also got Geraldine!";
            level10Chars = new List<char>();
            foreach (var c in level10Text)
            {
                level10Chars.Add(c);
            }
            level10Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level10Background = Content.Load<Texture2D>("level10");
            level10StoryText = Content.Load<SpriteFont>("MainGameTitle");
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level10Chars.Count > 0)
            {
                if (rand.Next(0, 4) > 1)
                {
                    level10Text += level10Chars[0];
                    level10Chars.RemoveAt(0);
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
            spriteBatch.Draw(level10Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(level10StoryText, level10Text, new Vector2((LEVEL_WIDTH / 2) - level10Text.Length * 2, 320), Color.White);
        }

    }
}
