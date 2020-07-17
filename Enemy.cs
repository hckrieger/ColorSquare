using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ColorSquares
{
    class Enemy : SpriteGameObject
    {
        public Color Color { get; set; }
        float vertTimer, horTimer;
        float vertSwitch, horSwitch;
        float speed = 135;
        
        public Vector2 StartPos { get; set; }

        public Enemy(Color color, Vector2 pos) : base("square")
        {
            Color = color;
            LocalPosition = pos;
            StartPos = pos;

            vertTimer = 1;
            horTimer = 1;

        }

        public override void Update(GameTime gameTime, InputHelper inputHelper)
        {
            if (!ExtendedGame.Pause)
            {
                velocity = new Vector2(speed * horSwitch, speed * vertSwitch);

                vertTimer -= dt;
           

                if (vertTimer <= 0)
                {
                    vertTimer = ExtendedGame.Random.Next(0, 3);
                    vertSwitch = ExtendedGame.Random.Next(-1, 2);
                }

                horTimer -= dt;
                if (horTimer <= 0)
                {
                    horTimer = ExtendedGame.Random.Next(0, 3);
                    horSwitch = ExtendedGame.Random.Next(-1, 2);
                }

                if (LocalPosition.X >= 750)
                {
                    horSwitch = -1;
                } else if (LocalPosition.X <= 0)
                {
                    horSwitch = 1;
                }

                if (LocalPosition.Y >= 550)
                {
                    vertSwitch = -1;
                } else if (LocalPosition.Y <= 0)
                {
                    vertSwitch = 1;
                }

                base.Update(gameTime, inputHelper);
            }
            
        }

        public override void Reset()
        {
            LocalPosition = StartPos;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(sprite, GlobalPosition, Color);

        }
    }
}
