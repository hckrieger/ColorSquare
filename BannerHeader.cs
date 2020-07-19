using Microsoft.Xna.Framework;

namespace ColorSquares
{
    class BannerHeader : TextGameObject
    {
        public BannerHeader() : base("BannerHeader", Color.Black, Alignment.Center)
        {
            LocalPosition = new Vector2(400, 166);
            Text = "Color Squares";
        }
    }
}
