using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;

namespace ColorSquares
{

    class GameWorld : GameObjectList
    {
        Player player = new Player(Color.White, new Vector2(400, 300));
        Enemy redEnemy = new Enemy(Color.DarkRed, new Vector2(0, 0));
        Enemy orangeEnemy = new Enemy(Color.OrangeRed, new Vector2(0, 300));
        Enemy yellowEnemy = new Enemy(Color.Yellow, new Vector2(0, 550));
        Enemy greenEnemy = new Enemy(Color.Green, new Vector2(400, 0));
        Enemy blueEnemy = new Enemy(Color.Blue, new Vector2(750, 0));
        Enemy indigoEnemy = new Enemy(Color.Indigo, new Vector2(750, 300));
        Enemy violetEnemy = new Enemy(Color.Violet, new Vector2(400, 550));
        Enemy purpleEnemy = new Enemy(Color.Purple, new Vector2(750, 550));

        Stats stats = new Stats(new Vector2(775, 25));
        BannerHeader bannerHeaderText = new BannerHeader();
        BannerWords bannerWordsText = new BannerWords();


        Border border = new Border();

        EndBanner banner = new EndBanner();
        float colorTimer = .05f;
        float invincibilityTime = 1f;
        bool invincible = false;
        bool damage = false;


        public GameWorld()
        {
            GameObject[] gameObjects = { redEnemy, orangeEnemy, yellowEnemy, greenEnemy, purpleEnemy, 
                                         blueEnemy, indigoEnemy, violetEnemy, player, stats,
                                         banner, bannerHeaderText, bannerWordsText, border };

            foreach (GameObject obj in gameObjects)
            {
                AddChild(obj);
            }

            ExtendedGame.Pause = true;

            ExtendedGame.AssetManager.PlaySong("snd_music", true);

        }

        public override void Update(GameTime gameTime, InputHelper inputHelper)
        {


            Enemy[] enemies = { redEnemy, orangeEnemy, yellowEnemy, greenEnemy,
                                blueEnemy, indigoEnemy, violetEnemy, purpleEnemy };

            Color[] colors = { Color.DarkRed, Color.OrangeRed, Color.Yellow, Color.Green,
                               Color.Blue, Color.Indigo, Color.Violet, Color.Purple };

            int randIndx = ExtendedGame.Random.Next(0, 8);

            for (int i = 0; i < enemies.Length; i++)
            {
                
                    if (enemies[i].BoundingBox.Intersects(player.BoundingBox) && enemies[i].Color == player.TargetColor && !invincible)
                    {
                        player.TargetColor = colors[randIndx];
                      
                        stats.Score++;
                        stats.Total++;
                        invincible = true;

                        ExtendedGame.AssetManager.PlaySoundEffect("addScore");
                }

                    if (enemies[i].BoundingBox.Intersects(player.BoundingBox) && enemies[i].Color != player.TargetColor && !invincible)
                    {
                        stats.Lives--;
                        invincible = true;
                        damage = true;

                        ExtendedGame.AssetManager.PlaySoundEffect("damage");
                }

                
            }
            
            if (stats.Lives <= 0)
            {
                  ExtendedGame.Pause = true;
              
                  stats.Tries++;

                  bannerHeaderText.Text = "Nice Try!";

                  bannerWordsText.Text = "Score: " + stats.Score.ToString() + "\n";
                  bannerWordsText.Text += "Tries: " + stats.Tries.ToString() + "\n";
                  bannerWordsText.Text += "Average: " + stats.Average.ToString() + "\n";
                  bannerWordsText.Text += "Record: " + stats.Record.ToString() + "\n";
                  bannerWordsText.Text += "Total: " + stats.Total.ToString() + "\n\n";
                  bannerWordsText.Text += "Spacebar - Play Again\n";
                  bannerWordsText.Text += "F5 - Toggle Fullscreen\n";
                  bannerWordsText.Text += "Esc - Exit\n";

                GameObject[] gameObjects = { player, redEnemy, orangeEnemy, yellowEnemy, greenEnemy, purpleEnemy,
                                              blueEnemy, indigoEnemy, violetEnemy, stats };

                  foreach (GameObject obj in gameObjects)
                  {
                      obj.Reset();
                  }


                  bannerWordsText.Visible = true;
                  bannerHeaderText.Visible = true;
                  banner.Visible = true; 

            }

            if (invincible)
            {
                invincibilityTime -= dt;
                if (invincibilityTime <= 0)
                {

                    invincibilityTime = 1f;
                    invincible = false;
                }

            }

            if (damage)
            {
                colorTimer -= dt;
                ExtendedGame.BackgroundColor = Color.Red;
                if (colorTimer <= 0)
                {
                    ExtendedGame.BackgroundColor = Color.Black;
                    colorTimer = .1f;
                    damage = false;
                }
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
