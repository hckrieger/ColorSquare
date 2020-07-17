using Microsoft.Xna.Framework;


namespace ColorSquares
{
    class LivesHUD : TextGameObject
    {
        public int Lives { get; set; }

        public LivesHUD(Vector2 position) : base("HUD", Color.White)
        {
            Lives = 3;

            LocalPosition = position;
            
        }

        public override void Reset()
        {
            Lives = 3;
        }

        public override void Update(GameTime gameTime, InputHelper inputHelper)
        {
            Text = "Lives: " + Lives.ToString();
            base.Update(gameTime, inputHelper);
        }
    }
}
