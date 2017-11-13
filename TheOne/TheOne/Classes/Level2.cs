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
    public class Level2
    {
        private Texture2D level2Background;
        private Texture2D augustCalendar;
        private string level2Text;
        private List<char> level2Chars;
        private SpriteFont level2StoryText;

        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public bool textDone { get; set; }

        public void Initialize()
        {
            textDone = false;
            level2Text = "Our story begins in the late summer of 2013.\nOn a casual game of ARAM in League of Legends.";
            level2Chars = new List<char>();
            foreach (var c in level2Text)
            {
                level2Chars.Add(c);
            }
            level2Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level2Background = Content.Load<Texture2D>("CalendarBackground");
            augustCalendar = Content.Load<Texture2D>("CalendarAug");
            level2StoryText = Content.Load<SpriteFont>("MainGameTitle");
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level2Chars.Count > 0)
            {
                if (rand.Next(0, 4) > 1)
                {
                    level2Text += level2Chars[0];
                    level2Chars.RemoveAt(0);
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
            spriteBatch.Draw(level2Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.Draw(augustCalendar, new Rectangle((LEVEL_WIDTH / 2) - (augustCalendar.Width / 2), 35, augustCalendar.Width, augustCalendar.Height), Color.White);
            spriteBatch.DrawString(level2StoryText, level2Text, new Vector2((LEVEL_WIDTH / 2) - level2Text.Length * 4, (LEVEL_HEIGHT / 2)), Color.White);     
        }
    }
}
