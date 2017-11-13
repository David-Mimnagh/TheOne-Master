using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using TheOne.Classes;

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
        Song rodStewart;
        Song sunshine;
        SoundEffect level3Sound;
        SoundEffectInstance level3Inst;
        SoundEffect level7Bus;
        SoundEffectInstance level7Inst;
        SoundEffect typingSound;
        SoundEffectInstance typingInst;
        SpriteBatch spriteBatch;
        private int LEVEL_WIDTH;
        private int LEVEL_HEIGHT;

        Player theOne = new Player();
        private Vector2 startPos;


        private bool transition;
        private Vector2 transitionPos;
        private Texture2D transitionBackground;

        private int levelNumber;
        private Rectangle levelProgressBBox;

        bool walkingRight;
        Texture2D theOneTexRight;
        private AnimatedSprite theOneSprRight;

        Texture2D theOneTexLeft;
        private AnimatedSprite theOneSprLeft;
        bool textStillToType;
        Level1 levelOne;
        Level2 levelTwo;
        Level3 levelThree;
        Level4 levelFour;
        Level5 levelFive;
        Level6 levelSix;
        Level7 levelSeven;
        Level8 levelEight;
        Level9 levelNine;
        Level10 levelTen;
        Level11 levelEle;
        Level12 levelTwe;
        Level13 levelTteen;
        Level14 levelFourteen;
        Level15 levelFifteen;
        Level16 levelSixteen;
        Level17 levelSeventeen;
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
            this.rodStewart = Content.Load<Song>("song");
            this.sunshine = Content.Load<Song>("Sunshine");
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.Play(rodStewart);
            MediaPlayer.IsRepeating = false;
            textStillToType = true; 

            this.level3Sound = Content.Load<SoundEffect>("lolSoundEffect");
            level3Inst = this.level3Sound.CreateInstance();
            level3Inst.IsLooped = false;

            this.level7Bus = Content.Load<SoundEffect>("BusSound");
            level7Inst = this.level7Bus.CreateInstance();
            level7Inst.IsLooped = true;

            this.typingSound = Content.Load<SoundEffect>("Keyboard");
            typingInst = this.typingSound.CreateInstance();
            typingInst.IsLooped = true;

            SoundEffect.MasterVolume = 0.15f;
            
            // TODO: Add your initialization logic here
            levelNumber = 9;


            levelOne = new Level1();
            levelOne.LEVEL_WIDTH = LEVEL_WIDTH;
            levelOne.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelOne.Initialize();


            levelTwo = new Level2();
            levelTwo.LEVEL_WIDTH = LEVEL_WIDTH;
            levelTwo.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelTwo.Initialize();

            levelThree = new Level3();
            levelThree.convoNumber = 1; 
            levelThree.LEVEL_WIDTH = LEVEL_WIDTH;
            levelThree.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelThree.Initialize();


            levelFour = new Level4();
            levelFour.LEVEL_WIDTH = LEVEL_WIDTH;
            levelFour.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelFour.Initialize();

            levelFive = new Level5();
            levelFive.LEVEL_WIDTH = LEVEL_WIDTH;
            levelFive.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelFive.Initialize();

            levelSix = new Level6();
            levelSix.LEVEL_WIDTH = LEVEL_WIDTH;
            levelSix.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelSix.Initialize();

            levelSeven = new Level7();
            levelSeven.LEVEL_WIDTH = LEVEL_WIDTH;
            levelSeven.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelSeven.Initialize();

            levelEight = new Level8();
            levelEight.LEVEL_WIDTH = LEVEL_WIDTH;
            levelEight.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelEight.Initialize();

            levelNine = new Level9();
            levelNine.LEVEL_WIDTH = LEVEL_WIDTH;
            levelNine.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelNine.Initialize();

            levelTen = new Level10();
            levelTen.LEVEL_WIDTH = LEVEL_WIDTH;
            levelTen.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelTen.Initialize();

            levelEle = new Level11();
            levelEle.LEVEL_WIDTH = LEVEL_WIDTH;
            levelEle.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelEle.Initialize();


            levelTwe = new Level12();
            levelTwe.LEVEL_WIDTH = LEVEL_WIDTH;
            levelTwe.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelTwe.Initialize();

            levelTteen = new Level13();
            levelTteen.LEVEL_WIDTH = LEVEL_WIDTH;
            levelTteen.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelTteen.Initialize();

            levelFourteen = new Level14();
            levelFourteen.LEVEL_WIDTH = LEVEL_WIDTH;
            levelFourteen.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelFourteen.Initialize();

            levelFifteen = new Level15();
            levelFifteen.LEVEL_WIDTH = LEVEL_WIDTH;
            levelFifteen.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelFifteen.Initialize();

            levelSixteen = new Level16();
            levelSixteen.LEVEL_WIDTH = LEVEL_WIDTH;
            levelSixteen.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelSixteen.Initialize();

            levelSeventeen = new Level17();
            levelSeventeen.LEVEL_WIDTH = LEVEL_WIDTH;
            levelSeventeen.LEVEL_HEIGHT = LEVEL_HEIGHT;
            levelSeventeen.Initialize();



            transition = false;
            levelProgressBBox = new Rectangle(LEVEL_WIDTH - 140, 0, 140, LEVEL_HEIGHT);
            transitionPos = new Vector2(0, 0);
           
            base.Initialize();
        }

        protected void SongTransition()
        {
            while(MediaPlayer.Volume > 0)
            {
                MediaPlayer.Volume -= 0.000003f;
            }
            MediaPlayer.Stop();
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            levelOne.LoadContent(Content);
            levelTwo.LoadContent(Content);
            levelThree.LoadContent(Content);
            levelFour.LoadContent(Content);
            levelFive.LoadContent(Content);
            levelSix.LoadContent(Content);
            levelSeven.LoadContent(Content);
            levelEight.LoadContent(Content);
            levelNine.LoadContent(Content);
            levelTen.LoadContent(Content);
            levelEle.LoadContent(Content);
            levelTwe.LoadContent(Content);
            levelTteen.LoadContent(Content);
            levelFourteen.LoadContent(Content);
            levelFifteen.LoadContent(Content);
            levelSixteen.LoadContent(Content);
            levelSeventeen.LoadContent(Content);

            transitionBackground = Content.Load<Texture2D>("transition");
            theOne.Sprite = Content.Load<Texture2D>("theOne");

            walkingRight = true;
            theOneTexRight = Content.Load<Texture2D>("SarahWalkRight3");
            theOneSprRight = new AnimatedSprite(theOneTexRight, 1, 4);


            theOneTexLeft = Content.Load<Texture2D>("SarahWalkLeft");
            theOneSprLeft = new AnimatedSprite(theOneTexLeft, 1, 4);

            startPos = new Vector2(50, LEVEL_HEIGHT - theOneTexRight.Height);
            theOne.posY = (int)startPos.Y;
            theOne.posX = (int)startPos.X;

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

            levelOne.Update(gameTime);
            levelTwo.Update(gameTime);
            levelThree.Update(gameTime);
            levelFour.Update(gameTime);
            levelFive.Update(gameTime);
            levelSix.Update(gameTime);
            levelSeven.Update(gameTime);
            levelEight.Update(gameTime);
            levelNine.Update(gameTime);
            levelTen.Update(gameTime);
            levelEle.Update(gameTime);
            levelTwe.Update(gameTime);
            levelTteen.Update(gameTime);
            levelFourteen.Update(gameTime);
            levelFifteen.Update(gameTime);
            levelSixteen.Update(gameTime);
            levelSeventeen.Update(gameTime);

            bool notPlayed = true;
            switch (levelNumber)
            {
                case 3:

                    if (theOne.posX == 320)
                        notPlayed = true;
                   else if (theOne.posX == 500)
                        notPlayed = true;
                    else if (theOne.posX == 600)
                        notPlayed = true;
                    else if (theOne.posX == 860)
                        notPlayed = true;

                    if (theOne.posX < 140)
                    {
                        levelThree.convoNumber = 1;
                    }
                    else if (theOne.posX < 320)
                    {
                        levelThree.convoNumber = 2;
                        if (notPlayed)
                        {
                            level3Inst.Play();
                            notPlayed = false;
                        }
                    }
                    else if (theOne.posX < 500)
                    {
                        levelThree.convoNumber = 3;
                        if (notPlayed)
                        {
                            level3Inst.Play();
                            notPlayed = false;
                        }
                    }
                    else if (theOne.posX < 680)
                    {
                        levelThree.convoNumber = 4;
                        if (notPlayed)
                        {
                            level3Inst.Play();
                            notPlayed = false;
                        }
                    }
                    else if (theOne.posX < 860)
                    {
                        levelThree.convoNumber = 5;
                        if (notPlayed)
                        {
                            level3Inst.Play();
                            notPlayed = false;
                        }
                    }
                    break;
                case 4:
                case 5:
                    if (theOne.posX < 200)
                    {
                        levelFive.convoSpeed = 1;
                    }
                    else if (theOne.posX < 400)
                    {
                        levelFive.convoSpeed = 2;
                    }
                    else if (theOne.posX < 600)
                    {
                        levelFive.convoSpeed = 3;
                    }
                    break;
            }
          

            if ( transition )
            {
                transitionPos.X -= 6;
            }
            if ( transitionPos.X + transitionBackground.Width <= 0 )
            {
                transition = false;
                transitionPos.X = 0;
                transitionPos.Y = 0;
                if(levelNumber == 10)
                {
                    MediaPlayer.Play(sunshine);
                    MediaPlayer.Volume = 0.1f;
                    MediaPlayer.IsRepeating = false;
                }
            }


            if ( theOne.posX < 0 )
            {
                theOne.posX = 0;
            }


            if(CheckIntersection())
            {
                if (typingInst.State == SoundState.Playing)
                    typingInst.Stop();
                if (level7Inst.State == SoundState.Playing)
                    level7Inst.Stop();

                theOne.posX = (int)startPos.X;
                theOne.posY = (int)startPos.Y;
                levelNumber += 1;
                levelFour.convoSpeed = 1;
                levelFive.convoSpeed = 1;
                transition = true;
            }


            if ( !transition )
            {
                // TODO: Add your update logic here
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    walkingRight = false;
                    theOneSprLeft.Update();
                    theOne.posX -= 2;
                }

                Random rand = new Random();
                if (Keyboard.GetState().IsKeyUp(Keys.D))
                {
                    if (typingInst.State == SoundState.Playing)
                        typingInst.Stop();
                }

                
                if ( Keyboard.GetState().IsKeyDown(Keys.D) )
                {
                    if (levelNumber >= 2)
                    {
                        if (levelNumber != 3)
                        {
                            if (textStillToType)
                            {
                                if (typingInst.State != SoundState.Playing)
                                    typingInst.Play();
                            }
                            else
                            {
                                if (typingInst.State == SoundState.Playing)
                                    typingInst.Stop();

                            }
                        }
                    }
                    walkingRight = true;
                    switch (levelNumber)
                    {
                        case 2:
                          
                            if (!transition)
                            {
                                textStillToType = !levelTwo.textDone;
                                levelTwo.UpdateText();   
                            }
                            break;
                        case 4:
                            if (!transition)
                            {
                                textStillToType = !levelFour.textDone;
                                levelFour.UpdateConvo();
                                levelFour.UpdateText();
                            }
                            break;
                        case 5:
                            if (!transition)
                            {
                                textStillToType = !levelFive.textDone;
                                levelFive.UpdateConvo();
                                levelFive.UpdateText();
                            }
                            break;
                        case 6:
                            if (!transition)
                            {
                                textStillToType = !levelSix.textDone;
                                levelSix.UpdateText();
                            }
                            break;
                        case 7:
                            if (!transition)
                            {
                                textStillToType = !levelSeven.textDone;
                                levelSeven.UpdateText();
                            }
                            break;
                        case 8:
                            if (!transition)
                            {
                                textStillToType = !levelEight.textDone;
                                levelEight.UpdateText();
                            }
                            break;
                        case 9:
                            if (!transition)
                            {
                                textStillToType = !levelNine.textDone;
                                levelNine.UpdateText();
                            }
                            break;
                        case 10:
                            if (!transition)
                            {
                                textStillToType = !levelTen.textDone;
                                levelTen.UpdateText();
                            }
                            break;
                        case 11:
                            if (!transition)
                            {
                                textStillToType = !levelEle.textDone;
                                levelEle.UpdateText();
                            }
                            break;
                        case 12:
                            if (!transition)
                            {
                                textStillToType = !levelTwe.textDone;
                                levelTwe.UpdateText();
                            }
                            break;
                        case 13:
                            if (!transition)
                            {
                                textStillToType = !levelTteen.textDone;
                                levelTteen.UpdateText();
                            }
                            break;
                        case 14:
                            if (!transition)
                            {
                                textStillToType = !levelFourteen.textDone;
                                levelFourteen.UpdateText();
                            }
                            break;
                        case 15:
                            if (!transition)
                            {
                                textStillToType = !levelFifteen.textDone;
                                levelFifteen.UpdateText();
                            }
                            break;
                        case 16:
                            if (!transition)
                            {
                                textStillToType = !levelSixteen.textDone;
                                levelSixteen.UpdateText();
                            }
                            break;
                        case 17:
                            if (!transition)
                            {
                                textStillToType = !levelSeventeen.textDone;
                                levelSeventeen.UpdateText();
                            }
                            break;
                    }


                    theOneSprRight.Update();
                    theOne.posX +=2;
                }
            }
            base.Update(gameTime);
        }


        protected void DrawLevel()
        {
                switch (levelNumber)
                {
                    case 1:
                        levelOne.Draw(spriteBatch, graphics);
                    
                    break;
                case 2:
                    levelTwo.Draw(spriteBatch,graphics);
                    break;
                case 3:
                    levelThree.Draw(spriteBatch, graphics);
                        break;
                    case 4:

                        if (!transition)
                            levelFour.DrawConvo(spriteBatch, graphics);
                        levelFour.Draw(spriteBatch, graphics);
                        break;
                    case 5:

                    if (!transition)
                        levelFive.DrawConvo(spriteBatch, graphics);

                    levelFive.Draw(spriteBatch, graphics);
                    break;
                case 6:
                    levelSix.Draw(spriteBatch,graphics);
                    break;
                case 7:
                    levelSeven.Draw(spriteBatch, graphics);
                    level7Inst.Play();
                    break;
                case 8:
                    levelEight.Draw(spriteBatch, graphics);
                    break;
                case 9:
                    levelNine.Draw(spriteBatch, graphics);
                    break;
                case 10:
                    levelTen.Draw(spriteBatch, graphics);
                    break;
                case 11:
                    levelEle.Draw(spriteBatch, graphics);
                    break;
                case 12:
                    levelTwe.Draw(spriteBatch, graphics);
                    break;
                case 13:
                    levelTteen.Draw(spriteBatch, graphics);
                    break;
                case 14:
                    levelFourteen.Draw(spriteBatch, graphics);
                    break;
                case 15:
                    levelFifteen.Draw(spriteBatch, graphics);
                    break;
                case 16:
                    levelSixteen.Draw(spriteBatch, graphics);
                    break;
                case 17:
                    levelSeventeen.Draw(spriteBatch, graphics);
                    break;
                default:
                        break;
                }
            

            //spriteBatch.Draw(theOne.Sprite, new Rectangle(theOne.posX, theOne.posY, theOne.Sprite.Width, theOne.Sprite.Height), Color.White);
            if (walkingRight)
            theOneSprRight.Draw(spriteBatch, new Vector2(theOne.posX, theOne.posY));
            else
                theOneSprLeft.Draw(spriteBatch, new Vector2(theOne.posX, theOne.posY));

            if (transition)
            {
                spriteBatch.Draw(transitionBackground, new Rectangle((int)transitionPos.X, (int)transitionPos.Y, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
                if(levelNumber == 10)
                {
                    SongTransition();
                }
            }

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param> 
        protected override void Draw(GameTime gameTime)
        {

           
            GraphicsDevice.Clear(Color.Black);
            
          
            // TODO: Add your drawing code here
            spriteBatch.Begin();
             DrawLevel();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
