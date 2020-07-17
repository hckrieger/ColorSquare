using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ColorSquares
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    class Game1 : ExtendedGame
    {

            public Game1()
            {
                IsMouseVisible = true;
            }



            protected override void LoadContent()
            {
                base.LoadContent();

                gameWorld = new GameWorld();
            }

            public static GameWorld GameWorld
            {
                get { return (GameWorld)gameWorld; }
            }
    }
}
