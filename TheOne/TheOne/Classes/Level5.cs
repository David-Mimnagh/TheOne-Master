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
   public class Level5
    {
        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        private Texture2D level5Background;

        public bool textDone { get; set; }


        public int convoSpeed { get; set; }

        private Texture2D phoneConvoPic;
        private Vector2 phoneConvoPos;

        private Texture2D fbConvoPic;
        private Vector2 fbConvoPos;
        private Texture2D fbConvoScrollPic;
        private Vector2 fbConvoScrollPos;

        private string level5Text;
        private List<char> level5Chars;
        private SpriteFont level5StoryText;

        public void Initialize()
        {
            convoSpeed = 1;

            textDone = false;
            level5Text = "We exchanged numbers,\nadded each other on Facebook\nand started speaking a lot more...";
            level5Chars = new List<char>();
            foreach (var c in level5Text)
            {
                level5Chars.Add(c);
            }
            level5Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level5StoryText = Content.Load<SpriteFont>("MainGameTitle");
            level5Background = Content.Load<Texture2D>("level5");

            phoneConvoPic = Content.Load<Texture2D>("iPhoneChat2");
            phoneConvoPos = new Vector2(171, 124);
            fbConvoPic = Content.Load<Texture2D>("facebookChat");
            fbConvoPos = new Vector2(591, 26);
            fbConvoScrollPic = Content.Load<Texture2D>("facebookScroller");
            fbConvoScrollPos = new Vector2(836, 39);
            //phonePos.Y -= phonePic.Height;
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level5Chars.Count > 0)
            {
                if (rand.Next(0, 2) > 0)
                {
                    level5Text += level5Chars[0];
                    level5Chars.RemoveAt(0);
                }
            }
            else
            {
                textDone = true;
            }
        }

        public void UpdateConvo()
        {
            phoneConvoPos.Y -= convoSpeed;
            fbConvoPos.Y -= convoSpeed * 1.5f;
            fbConvoScrollPos.Y += 0.3f;
        }
        public void Update(GameTime gameTime)
        {
        }

        public void DrawConvo(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            //if (droppedFully)
            spriteBatch.Draw(phoneConvoPic, new Rectangle((int)phoneConvoPos.X, (int)phoneConvoPos.Y, phoneConvoPic.Width, phoneConvoPic.Height), Color.White);
            spriteBatch.Draw(fbConvoPic, new Rectangle((int)fbConvoPos.X, (int)fbConvoPos.Y, fbConvoPic.Width, fbConvoPic.Height), Color.White);
            spriteBatch.Draw(fbConvoScrollPic, new Rectangle((int)fbConvoScrollPos.X, (int)fbConvoScrollPos.Y, fbConvoScrollPic.Width, fbConvoScrollPic.Height), Color.White);

            //spriteBatch.Draw(phonePic, new Rectangle((int)phonePos.X, (int)phonePos.Y, phonePic.Width, phonePic.Height), Color.White);

        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.Draw(level5Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(level5StoryText, level5Text, new Vector2((LEVEL_WIDTH / 2) - level5Text.Length * 3, 345), Color.White);

        }
    }
}
