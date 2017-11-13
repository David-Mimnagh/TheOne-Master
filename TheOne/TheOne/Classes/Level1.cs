using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TheOne.Classes;
using Microsoft.Xna.Framework.Content;

namespace TheOne.Classes
{
    public class Level1
    {
        private SpriteFont mainScreenFont;
        private SpriteFont level1Start;

        Texture2D startTexture;
        private AnimatedSprite startAnimatedSprite;

        Texture2D theOneTexture;
        private AnimatedSprite theOneSprite;

        private Texture2D mainBackground;
        private SpriteFont levelText;
        string mainText;
        string infoText;
        int width;
        Vector2 where;
        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        public void Initialize()
        {
            mainText = "'The One'";
            width = (LEVEL_WIDTH / 2) - (mainText.Length * 10);
            where = new Vector2(width, 20);
            infoText = "To move use:\nA - left\nD - right.";
        }

        public void LoadContent(ContentManager Content)
        {
            startTexture = Content.Load<Texture2D>("StartSprite");
            startAnimatedSprite = new AnimatedSprite(startTexture, 1, 10);


            theOneTexture = Content.Load<Texture2D>("SarahWalkRight");
            theOneSprite = new AnimatedSprite(theOneTexture, 1, 4);

            mainScreenFont = Content.Load<SpriteFont>("MainGameTitle");
            level1Start = Content.Load<SpriteFont>("MainGameTitle");
            levelText = Content.Load<SpriteFont>("MainGameTitle");
            mainBackground = Content.Load<Texture2D>("level1Background");
        }

        public void Update(GameTime gameTime)
        {
            startAnimatedSprite.Update();
            theOneSprite.Update();

        }



        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.Draw(mainBackground, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            //spriteBatch.DrawString(mainScreenFont, mainText, where, Color.White);
            //spriteBatch.DrawString(level1Start, startText, new Vector2(LEVEL_WIDTH - 150, LEVEL_HEIGHT - 150), Color.White);
            startAnimatedSprite.Draw(spriteBatch, new Vector2(LEVEL_WIDTH - 150, LEVEL_HEIGHT - 150));
            //spriteBatch.DrawString(levelText, infoText, new Vector2(50, LEVEL_HEIGHT / 2), Color.White);
        }
    }
}
