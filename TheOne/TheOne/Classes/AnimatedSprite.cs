using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOne.Classes
{
    public class AnimatedSprite
    {
        public Texture2D spriteTexture { get; set; }
        public int rows { get; set; }
        public int columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public AnimatedSprite(Texture2D texture, int _rows, int _columns)
        {
            spriteTexture = texture;
            rows = _rows;
            columns = _columns;
            currentFrame = 0;
            totalFrames = rows * columns;
        }

        public void Update()
        {
            Random rand = new Random();

            if (rand.Next(0, 1000) > 950)
                currentFrame++;

            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = spriteTexture.Width / columns;
            int height = spriteTexture.Height / rows;
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(spriteTexture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}
