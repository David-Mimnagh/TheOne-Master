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
   public class Level4
    {
        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public bool textDone { get; set; }

        private Texture2D level4Background;
       // private Texture2D phonePic;
        private Texture2D skypeConvoPic;
        private Vector2 skypeConvoPos;
        public int convoSpeed {get;set;}
        //bool droppedFully;
        //private Vector2 phonePos;
        private string level4Text;
        private List<char> level4Chars;
        private SpriteFont level4StoryText;

        public void Initialize()
        {
            textDone = false;
            convoSpeed = 1;
            level4Text = "We would speak for hours at a time...\nAlways about silly little things!";
            level4Chars = new List<char>(); 
            foreach (var c in level4Text)
            {
                level4Chars.Add(c);
            }
            level4Text = "";
        }

        public void LoadContent(ContentManager Content)
        {
            level4StoryText = Content.Load<SpriteFont>("MainGameTitle");
            level4Background = Content.Load<Texture2D>("level4");
            skypeConvoPic = Content.Load<Texture2D>("SkypeConvo");
            skypeConvoPos = new Vector2(432, 70);
            //phonePos.Y -= phonePic.Height;
        }

        public void UpdateText()
        {
            Random rand = new Random();
            if (level4Chars.Count > 0)
            {
                if (rand.Next(0, 2) > 0)
                {
                    level4Text += level4Chars[0];
                    level4Chars.RemoveAt(0);
                }
            }
            else
            {
                textDone = true;
            }
        }

       public void UpdateConvo()
        {
            skypeConvoPos.Y -= convoSpeed;
        }
        public void Update(GameTime gameTime)
        {
        //    if (!droppedFully)
        //        phonePos.Y += 8;


        //    if ((phonePos.Y + phonePic.Height) >= phonePic.Height)
        //    {
        //        droppedFully = true;
        //    }
        }

       public void DrawConvo(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            //if (droppedFully)
                spriteBatch.Draw(skypeConvoPic, new Rectangle((int)skypeConvoPos.X, (int)skypeConvoPos.Y, skypeConvoPic.Width, skypeConvoPic.Height), Color.White);
        
                //spriteBatch.Draw(phonePic, new Rectangle((int)phonePos.X, (int)phonePos.Y, phonePic.Width, phonePic.Height), Color.White);

       }

        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.Draw(level4Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(level4StoryText, level4Text, new Vector2((LEVEL_WIDTH / 2) - level4Text.Length * 3, (LEVEL_HEIGHT / 2)), Color.White);

        }
    }
}
