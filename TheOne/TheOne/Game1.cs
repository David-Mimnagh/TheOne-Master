using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace TheOne
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    
    public class Player
    {
        public Texture2D Sprite { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
    }
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont mainScreenFont;
        private SpriteFont levelNumFont;
        private Texture2D mainBackground;
        private Texture2D level2Background;
        private Texture2D transitionBackground;
        private Texture2D phonePic;
        private Texture2D phoneConvoPic;
        private Vector2 phoneConvoPos;
        private int phoneConvoSpeed;
        bool droppedFully;
        private Vector2 phonePos;
        private bool transition;
        private Vector2 transitionPos;
        private int levelNumber;
        private Rectangle  levelProgressBBox;
        private Vector2 startPos;
        Player theOne = new Player();
        private string level3Text;
        private List<char> level3Chars;
        private SpriteFont levelText;
        private int LEVEL_WIDTH;
        private int LEVEL_HEIGHT;
        //https://blogs.msdn.microsoft.com/tarawalker/2012/12/10/windows-8-game-development-using-c-xna-and-monogame-3-0-building-a-shooter-game-walkthrough-part-2-creating-the-shooterplayer-asset-of-the-game/
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
           // graphics.IsFullScreen = true;
            Window.Title = "The One";
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            LEVEL_WIDTH = GraphicsDevice.DisplayMode.Width / 2;
            LEVEL_HEIGHT = GraphicsDevice.DisplayMode.Height / 2;
            graphics.PreferredBackBufferWidth = LEVEL_WIDTH;
            graphics.PreferredBackBufferHeight = LEVEL_HEIGHT;
            graphics.ApplyChanges();
            // TODO: Add your initialization logic here
            levelNumber = 1;
            transition = false;
            levelProgressBBox = new Rectangle(LEVEL_WIDTH - 140, 0, 140, LEVEL_HEIGHT);
            transitionPos = new Vector2(0, 0);
            droppedFully = false;
            phoneConvoSpeed = 1;

            level3Text = "Hello, welcome to level 3.\nI am currently trying out the ability for the text to appear\nas you walk.";
            level3Chars = new List<char>();
            foreach ( var c in level3Text )
            {
                level3Chars.Add(c);
            }
            level3Text = "";
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mainScreenFont = Content.Load<SpriteFont>("MainGameTitle");
            levelNumFont = Content.Load<SpriteFont>("MainGameTitle");
            levelText = Content.Load<SpriteFont>("MainGameTitle");
            mainBackground = Content.Load<Texture2D>("background");
            level2Background = Content.Load<Texture2D>("level2");
            transitionBackground = Content.Load<Texture2D>("transition");
            phonePic = Content.Load<Texture2D>("phone");
            phonePos = new Vector2(( LEVEL_WIDTH / 2 ) - phonePic.Width, 0);
            phoneConvoPic = Content.Load<Texture2D>("iMessageConvo");
            phoneConvoPos = new Vector2(( LEVEL_WIDTH / 2 ) - phonePic.Width, 0);
            phonePos.Y -= phonePic.Height;
            theOne.Sprite = Content.Load<Texture2D>("theOne");
            startPos = new Vector2(50, LEVEL_HEIGHT - theOne.Sprite.Height);
            theOne.posY = (int)startPos.Y;
            theOne.posX = (int)startPos.X;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected bool CheckIntersection()
        {
            bool intersecting = false;

            if(theOne.posX > levelProgressBBox.Left)
            {
                if((theOne.posX + theOne.Sprite.Width) < levelProgressBBox.Right)
                {
                    intersecting = true;
                }
            }

            return intersecting;
        }
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if ( GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) )
                Exit();


            if(levelNumber == 2)
            {
                if (theOne.posX < 200)
                {
                    phoneConvoSpeed = 1;
                }
                else if ( theOne.posX < 400 )
                {
                    phoneConvoSpeed = 2;
                }
                else if ( theOne.posX < 600 )
                {
                    phoneConvoSpeed = 3;
                }
            }

            if ( transition )
            {
                transitionPos.X -= 4;
            }
            if ( transitionPos.X + transitionBackground.Width <= 0 )
            {
                transition = false;
                transitionPos.X = 0;
                transitionPos.Y = 0;
            }


            if ( levelNumber == 2 )
            {
                if ( !transition )
                {
                    if ( !droppedFully )
                        phonePos.Y += 8;


                    if ( ( phonePos.Y + phonePic.Height ) >= phonePic.Height )
                    {
                        droppedFully = true;
                    }
                }
            }
           
            if ( theOne.posX < 0 )
            {
                theOne.posX = 0;
            }
            if(CheckIntersection())
            {
                theOne.posX = (int)startPos.X;
                theOne.posY = (int)startPos.Y;
                levelNumber += 1;
                transition = true;
            }
            if ( !transition )
            {
                // TODO: Add your update logic here
                if ( Keyboard.GetState().IsKeyDown(Keys.A) )
                    theOne.posX -= 2;

                Random rand = new Random();
                if ( Keyboard.GetState().IsKeyDown(Keys.D) )
                {
                    if ( levelNumber == 2 )
                    {
                        if ( !transition )
                        {
                            phoneConvoPos.Y -= phoneConvoSpeed ;
                        }
                    }
                    if ( levelNumber == 3 )
                    {
                        if ( !transition )
                        {
                            if ( level3Chars.Count > 0 )
                            {
                                if ( rand.Next(0, 2) > 0 )
                                {
                                    level3Text += level3Chars[0];
                                    level3Chars.RemoveAt(0);
                                }
                            }
                        }
                    }
                    theOne.posX +=2;
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

           
            GraphicsDevice.Clear(Color.Black);
            string text = "'The One'";
            string levelNumText = "Level: " + levelNumber.ToString();
            int width = (graphics.PreferredBackBufferWidth / 2) - (text.Length * 10);
            int height =20;
            Vector2 where = new Vector2(width, height);
          
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if ( levelNumber == 2 )
            {
                if (droppedFully) 
                spriteBatch.Draw(phoneConvoPic, new Rectangle((int)phoneConvoPos.X, (int)phoneConvoPos.Y,phoneConvoPic.Width, phoneConvoPic.Height), Color.White);

                spriteBatch.Draw(level2Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            }
            else
            {
                spriteBatch.Draw(mainBackground, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            }

            spriteBatch.Draw(theOne.Sprite, new Rectangle(theOne.posX, theOne.posY, theOne.Sprite.Width, theOne.Sprite.Height), Color.White);
            spriteBatch.DrawString(mainScreenFont, text, where, Color.White);
            spriteBatch.DrawString(levelNumFont, levelNumText, new Vector2(100, 100), Color.White);
            if ( transition )
            {
                spriteBatch.Draw(transitionBackground, new Rectangle((int)transitionPos.X, (int)transitionPos.Y, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.Black);
            }
            if(levelNumber == 2)
            {
                if(!transition)
                    spriteBatch.Draw(phonePic, new Rectangle((int)phonePos.X, (int)phonePos.Y, phonePic.Width, phonePic.Height), Color.White);
            }
            if ( levelNumber == 3 )
            {
                if ( !transition )
                    spriteBatch.DrawString(levelText, level3Text, new Vector2( 100, 200), Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
