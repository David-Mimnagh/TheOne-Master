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
    public class Level3
    {


        public int LEVEL_WIDTH { get; set; }
        public int LEVEL_HEIGHT { get; set; }

        private Texture2D level3Background;
        private Texture2D[] convoPics;
        public int convoNumber { get; set; }

        public void Initialize()
        {
            
        }

        public void LoadContent(ContentManager Content)
        {
            level3Background = Content.Load<Texture2D>("level3Background");
            convoPics = new Texture2D[5];
            for (int i = 1; i < 6; i++)
            {
                convoPics[i-1] = Content.Load<Texture2D>("leagueChat"+i.ToString());
            }
        }

        public void Update(GameTime gameTime)
        {
          
        }



        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.Draw(level3Background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.Draw(convoPics[convoNumber-1], new Rectangle(0, 0, convoPics[0].Width, convoPics[0].Height), Color.White);
          
        }
    }
}
