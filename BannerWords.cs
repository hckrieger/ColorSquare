using Microsoft.Xna.Framework;

namespace ColorSquares
{
    class BannerWords : TextGameObject
    {
        public BannerWords() : base("BannerWords", Color.Black, Alignment.Center)
        {
            LocalPosition = new Vector2(415, 220);

            Text = "Use arrow keys to move around\n";
            Text += "Hit your target square color\n";
            Text += "Avoid the other squares\n\n";
            Text += "Spacebar - Start\n";
            Text += "F5 - Toggle Fullscreen \n";
            Text += "Esc - Exit\n\n";
            Text += "   Created by Hunter Krieger";
        }

        public override void Update(GameTime gameTime, InputHelper inputHelper)
        {

            base.Update(gameTime, inputHelper);
        }
    }
}
