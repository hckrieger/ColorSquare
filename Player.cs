using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ColorSquares
{
    class Player : SpriteGameObject
    {
        float speed = 200;
        float posX;
        float posY;
        public Color Color { get; set; }
        public Color TargetColor { get; set; }

        float colorTimer1 = .35f;
        float colorTimer2 = .35f;

        public Vector2 StartPos { get; set; }




        public Player(Color color, Vector2 pos) : base("square")
        {
            TargetColor = Color.Green;
            Color = color;
            LocalPosition = pos;
            StartPos = pos;
            posX = LocalPosition.X;
            posY = LocalPosition.Y;
        }

        public override void Reset()
        {
            LocalPosition = StartPos;
        }

        public override void Update(GameTime gameTime, InputHelper inputHelper)
        {
            
            if (!ExtendedGame.Pause)
            {
                LocalPosition = new Vector2(posX, posY);
                if (inputHelper.KeyHeld(Keys.Up))
                {
                    posY -= speed * dt;
                }

                if (inputHelper.KeyHeld(Keys.Down))
                {
                    posY += speed * dt;
                }

                if (inputHelper.KeyHeld(Keys.Left))
                {
                    posX -= speed * dt;
                }

                if (inputHelper.KeyHeld(Keys.Right))
                {
                    posX += speed * dt;
                }

                //Alternates the color of the player from White to the target color every .35 seconds. 
                colorTimer1 -= dt;

                if (colorTimer1 <= 0)
                {
                    Color = TargetColor;

                    colorTimer2 -= dt;

                    if (colorTimer2 <= 0)
                    {
                        colorTimer1 = .35f;
                        colorTimer2 = .35f;
                    }

                }
                else
                {
                    Color = Color.White;
                }
            } 

            //Constrain the player on the screen
            if (posX <= 0)   { posX = 0; }
            if (posY <= 0)   { posY = 0; }           
            if (posX >= 750) { posX = 750; } 
            if (posY >= 550) { posY = 550; } 
            
            base.Update(gameTime, inputHelper);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, GlobalPosition, Color);
        }


    }
}
