using Microsoft.Xna.Framework;

namespace ColorSquares
{
    class ScoreHUD : TextGameObject
    {
        public int Score { get; set; }

        public ScoreHUD(Vector2 position) : base("HUD", Color.White)
        {
            Score = 0;

            LocalPosition = position;
            
        }

        public override void Reset()
        {
            Score = 0;
        }

        public override void Update(GameTime gameTime, InputHelper inputHelper)
        {
            Text = "Score: " + Score.ToString();

            base.Update(gameTime, inputHelper);
        }
    }
}
