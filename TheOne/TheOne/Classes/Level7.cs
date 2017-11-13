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
    public class Level7
    {
        private Texture2D level7Background;
        private Texture2D bus;
        private Texture2D busWheel;
        private Vector2 wheelLocOne;
        private Texture2D busWheel2;
        private Vector2 wheelLocTwo;
        private Rectangle sourceWheelOne;
        private Rectangle sourceWheelTwo;
        private Vector2 wheelOrigin;
        private float angle;
        private string level7Text;
        private List<char> level7Chars;
        private SpriteFont level7StoryText;

        public bool textDone { get; set; }

        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public void Initialize()
        {
            textDone = false;
            level7Text = "We had an amazing night.\nWe went to see Bad grampa,\nthen we walked about Glasgow.\nIt couldn't have been more perfect.";
            wheelLocOne = new Vector2(514, 218);
            wheelLocTwo = new Vector2(815, 218);
            level7Chars = new List<char>();
            foreach (var c in level7Text)
            {
                level7Chars.Add(c);
            }
            level7Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level7Background = Content.Load<Texture2D>("level7");
            bus = Content.Load<Texture2D>("bus");
            busWheel = Content.Load<Texture2D>("busWheel2");
            busWheel2 = Content.Load<Texture2D>("busWheel2");
            level7StoryText = Content.Load<SpriteFont>("MainGameTitle");
            wheelOrigin = new Vector2(busWheel.Width / 2, busWheel.Height / 2);
            sourceWheelOne = new Rectangle((int)wheelLocOne.X, (int)wheelLocOne.Y, busWheel.Width, busWheel.Height);
            sourceWheelTwo = new Rectangle((int)wheelLocTwo.X, (int)wheelLocTwo.Y, busWheel2.Width, busWheel2.Height);
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level7Chars.Count > 0)
            {
                if (rand.Next(0, 4) > 1)
                {
                    level7Text += level7Chars[0];
                    level7Chars.RemoveAt(0);
                }
            }
            else
            {
                textDone = true;
            }
        }
        public void Update(GameTime gameTime)
        {
            angle -= 1.5f;
        }



        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.Draw(level7Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.Draw(busWheel, sourceWheelOne, null, Color.White, angle, wheelOrigin, SpriteEffects.None, 1);
            spriteBatch.Draw(busWheel2, sourceWheelTwo, null, Color.White, angle, wheelOrigin, SpriteEffects.None, 1);
            spriteBatch.Draw(bus, new Rectangle(358, 78, bus.Width, bus.Height), Color.White);
            spriteBatch.DrawString(level7StoryText, level7Text, new Vector2((LEVEL_WIDTH / 2) - level7Text.Length * 2, (LEVEL_HEIGHT / 2)), Color.White);
        }
    }
}
