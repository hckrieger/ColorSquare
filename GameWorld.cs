using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace ColorSquares
{

    class GameWorld : GameObjectList
    {
        Player player = new Player(Color.White, new Vector2(400, 300));
        Enemy redEnemy = new Enemy(Color.Red, new Vector2(0, 0));
        Enemy orangeEnemy = new Enemy(Color.DarkOrange, new Vector2(0, 300));
        Enemy yellowEnemy = new Enemy(Color.Yellow, new Vector2(0, 550));
        Enemy greenEnemy = new Enemy(Color.Green, new Vector2(400, 0));
        Enemy blueEnemy = new Enemy(Color.Blue, new Vector2(750, 0));
        Enemy indigoEnemy = new Enemy(Color.Indigo, new Vector2(750, 300));
        Enemy violetEnemy = new Enemy(Color.Violet, new Vector2(400, 550));
        Enemy purpleEnemy = new Enemy(Color.Purple, new Vector2(750, 550));

        ScoreHUD scoreText = new ScoreHUD(new Vector2(600, 50));
        LivesHUD livesText = new LivesHUD(new Vector2(600, 100));
        BannerHeader bannerHeaderText = new BannerHeader();
        BannerWords bannerWordsText = new BannerWords();

        EndBanner banner = new EndBanner();

        float invincibilityTime = 1f;
        bool invincible = false;

        public GameWorld()
        {
            GameObject[] gameObjects = { redEnemy, orangeEnemy, yellowEnemy, greenEnemy, purpleEnemy, 
                                         blueEnemy, indigoEnemy, violetEnemy, player, scoreText, livesText,
                                         banner, bannerHeaderText, bannerWordsText };

            foreach (GameObject obj in gameObjects)
            {
                AddChild(obj);
            }

           

        }

        public override void Update(GameTime gameTime, InputHelper inputHelper)
        {


            Enemy[] enemies = { redEnemy, orangeEnemy, yellowEnemy, greenEnemy,
                                blueEnemy, indigoEnemy, violetEnemy, purpleEnemy };

            Color[] colors = { Color.Red, Color.DarkOrange, Color.Yellow, Color.Green,
                               Color.Blue, Color.Indigo, Color.Violet, Color.Purple };

            int randIndx = ExtendedGame.Random.Next(0, 8);

            if (invincible)
            {
                invincibilityTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (invincibilityTime <= 0)
                {
                    invincibilityTime = 1f;
                    invincible = false;
                }
            }
           

            for (int i = 0; i < enemies.Length; i++)
            {
                
                    if (enemies[i].BoundingBox.Intersects(player.BoundingBox) && enemies[i].Color == player.TargetColor && !invincible)
                    {
                        player.TargetColor = colors[randIndx];


                        scoreText.Score++;
                        invincible = true;

                    }

                    if (enemies[i].BoundingBox.Intersects(player.BoundingBox) && enemies[i].Color != player.TargetColor && !invincible)
                    {

                        livesText.Lives--;
                        invincible = true;

                    }

                
            }
            
            if (livesText.Lives <= 0)
            {
                ExtendedGame.Pause = true;

                bannerHeaderText.Text = "Color Squares";
                bannerWordsText.Text = "Score: " + scoreText.Score.ToString() + ".";
                bannerWordsText.Text += "\n  \nPress Spacebar to play again.";

                GameObject[] gameObjects = { player, redEnemy, orangeEnemy, yellowEnemy, greenEnemy, purpleEnemy,
                                            blueEnemy, indigoEnemy, violetEnemy, scoreText, livesText };

                foreach (GameObject obj in gameObjects)
                {
                    obj.Reset();
                }

                bannerWordsText.Visible = true;
                bannerHeaderText.Visible = true;
                banner.Visible = true;

            }

            if (ExtendedGame.Pause)
            {
                if (inputHelper.KeyPressed(Keys.Space))
                {
                    banner.Visible = false;
                    bannerHeaderText.Visible = false;
                    bannerWordsText.Visible = false;
                    ExtendedGame.Pause = false;
                }
            }



            base.Update(gameTime, inputHelper);

        }

       


            

        
    }
}
