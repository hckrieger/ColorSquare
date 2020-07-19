using Microsoft.Xna.Framework;

namespace ColorSquares
{
    class Stats : TextGameObject
    {
        public int Lives { get; set; }
        public int Score { get; set; }
        public int Total { get; set; }
        public int Tries { get; set; }

        private int record;
        public int Record {
            get 
            {
                if (Score > record)
                {
                    record = Score;
                }

                return record;
            } 
        }
        public int Average { 
            get 
            { 
                return Total / Tries; 
            }
        }

        public Stats(Vector2 position) : base("BannerWords", Color.White, Alignment.Right)
        {
            Lives = 3;
            Score = 0;
            Total = 0;
            Tries = 0;
            record = Score;
            
            LocalPosition = position;
        }

        public override void Reset()
        {
            Score = 0;
            Lives = 3;
        }

        public override void Update(GameTime gameTime, InputHelper inputHelper)
        {
            Text = "Score: " + Score.ToString() + "\n\n";
            Text += "Lives: " + Lives.ToString();



            base.Update(gameTime, inputHelper);
        }
    }
}
