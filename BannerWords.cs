using Microsoft.Xna.Framework;

namespace ColorSquares
{
    class BannerWords : TextGameObject
    {
        public BannerWords() : base("BannerWords", Color.Black, Alignment.Center)
        {
            Visible = false;
            LocalPosition = new Vector2(400, 235);
        }
    }
}
