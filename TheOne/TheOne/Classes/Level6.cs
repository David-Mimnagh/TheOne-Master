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
   public class Level6
    {
        private Texture2D level6Background;
        private string level6Text;
        private List<char> level6Chars;
        private SpriteFont level6StoryText;

        public bool textDone { get; set; }

        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public void Initialize()
        {

            textDone = false;
            level6Text = "In November we went for our first date.\nYou looked gorgeous..!\nYou also tried to pierce my nose!";
            level6Chars = new List<char>();
            foreach (var c in level6Text)
            {
                level6Chars.Add(c);
            }
            level6Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level6Background = Content.Load<Texture2D>("level6");
            level6StoryText = Content.Load<SpriteFont>("MainGameTitle");
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level6Chars.Count > 0)
            {
                if (rand.Next(0, 4) > 1)
                {
                    level6Text += level6Chars[0];
                    level6Chars.RemoveAt(0);
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
            spriteBatch.Draw(level6Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(level6StoryText, level6Text, new Vector2((LEVEL_WIDTH / 2) - level6Text.Length * 3, 355), Color.White);
        }
    }
}
