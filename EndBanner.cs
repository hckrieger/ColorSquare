using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ColorSquares
{
    class EndBanner : SpriteGameObject
    {
        public EndBanner() : base("GameEndBanner") 
        {
            SetOriginToCenter();
            LocalPosition = new Vector2(400, 300);
            Visible = false;
        }
    }
}
