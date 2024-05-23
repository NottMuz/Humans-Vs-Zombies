using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace A_Sussy_Night
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //Load all Variables for my game
        Texture2D dungeon, zombieLeft, zombieRight, playerUp, playerDown, playerRight, playerLeft, playerStop, wall, death, win,potHole;
        List<Texture2D> susGuy2d, zombie2d;
        List<CollectableGameItem> scraps = new List<CollectableGameItem>();
        Rectangle dungeonRec, endGame1Rec, endGame2Rec, potholeRec;
        SpriteFont font, font1;
        bool deathGameEnd, winGameEnd, menuScreen = true;
        int points;
        Rectangle[] wallsRec = new Rectangle [6];
        Rectangle[] zombieRec = new Rectangle[6];
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player sussyGuy;
        Enemy[] zombie = new Enemy[6];
        Song bckgroundMusic;
        SoundEffect dead, winSound;
        //load arrays for the size and position of the walls 
        int[] recWallPosX = new int[] { 25, 45, 445, 45, 90, 90 };
        int[] recWallPosY = new int[] { 20, 20, 20, 580, 530, 530 };
        int[] recWallPosWidth = new int[] { 20, 400, 20, 45, 20, 375};
        int[] recWallPosHeight = new int[] { 600, 20, 525, 20, 90, 20 };

        //load arrays for the positions of the zombies
        int[] zombieRecPosX = new int[] { 350, 150, 400, 300, 250, 200 };
        int[] zombieRecPosY = new int[] { 150, 100, 250, 350, 450, 400 };
        //load arrays for the positions of the scraps
        int[] scrapsRecPosX = new int[] { 78, 125, 340, 280, 250, 310 };
        int[] scrapsRecPosY = new int[] { 150, 100, 250, 350, 450, 400 };
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
        
            //sets my screen size to 500 by 600
            graphics.PreferredBackBufferWidth = 700;
            graphics.PreferredBackBufferHeight = 700;
            graphics.ApplyChanges();
            dungeonRec = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);           
            endGame1Rec = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            endGame2Rec = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            potholeRec = new Rectangle(390, 40,50,50);
            //generates the zombie rectangles
            for (int i = 0; i < zombie.Length; i++)
            {
                zombieRec[i] = new Rectangle(zombieRecPosX[i], zombieRecPosY[i], 40, 40);
            }
            //initializes and generates the scraps
            for (int i = 0; i < scrapsRecPosY.Length; i++)
            {
                scraps.Add(new CollectableGameItem(new Rectangle(scrapsRecPosX[i], scrapsRecPosY[i], 25, 25), Content.Load<Texture2D>("scraps"), Color.White, 1));
                
            }
            //creates rectangle for the walls
            for (int i = 0; i < recWallPosWidth.Length; i++)
            {
                wallsRec[i] = new Rectangle(recWallPosX[i], recWallPosY[i], recWallPosWidth[i], recWallPosHeight[i]);
            }
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //load all textures
            dungeon = Content.Load<Texture2D>("floor");
            wall = Content.Load<Texture2D>("wall");
            zombieLeft = Content.Load<Texture2D>("zombieLeft1");
            zombieRight = Content.Load<Texture2D>("zombieRight1");
            playerUp = Content.Load<Texture2D>("playerUp");
            playerDown = Content.Load<Texture2D>("playerDown");
            playerRight = Content.Load<Texture2D>("playerRight");
            playerLeft = Content.Load<Texture2D>("playerLeft");
            playerStop = Content.Load<Texture2D>("playerStop");
            death = Content.Load<Texture2D>("scaryFace");
            win = Content.Load<Texture2D>("winner");
            potHole = Content.Load<Texture2D>("pothole-removebg-preview");

            //load spritefonts and sound effects and song
            font = Content.Load<SpriteFont>("SpriteFont1");
            font1= Content.Load<SpriteFont>("SpriteFont2");
            dead = Content.Load<SoundEffect>("endgame");
            winSound = Content.Load<SoundEffect>("winSound");
            bckgroundMusic = Content.Load<Song>("backGroundMusic");

            //initialize texture2d list for player and zombie
            susGuy2d = new List<Texture2D>();
            zombie2d = new List<Texture2D>();

            //add zombie direction textures to list
            zombie2d.Add(zombieLeft);
            zombie2d.Add(zombieRight);

            //add directions and stop animation  textures to player texture list
            susGuy2d.Add(playerRight);
            susGuy2d.Add(playerUp);
            susGuy2d.Add(playerDown);
            susGuy2d.Add(playerLeft);
            susGuy2d.Add(playerStop);


            //create sussy guy (player)
            sussyGuy = new A_Sussy_Night.Player(new Rectangle(46, 533, 30, 30), susGuy2d[0], Color.White, 100, 100, Character.Direction.stop, 5, 3);

            //create zombies on the screen
            for (int i = 0; i < zombie.Length; i++)
            {
                zombie[i] = new Enemy(zombieRec[i], zombie2d[1] , Color.White, 100, 100, Character.Direction.right, 5, 2, true);
            }
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
                 
                //once A is pressed remove the menu screen and play the background music
                if (menuScreen == true)
                {
                    if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                    {
                        menuScreen = false;
                        MediaPlayer.Play(bckgroundMusic);
                    
                    }
                }
                //if the player has moved past the menu screen, allow the gamefunctions to run
                if (menuScreen == false)
                {
                 
                    //Movement
                    //****************************************************************************
                    //****************************************************************************
                if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
                {
                    sussyGuy.setDirection(Character.Direction.right);
                    sussyGuy.setTexture2D(susGuy2d[0]);
                }

                if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                {
                    sussyGuy.setDirection(Character.Direction.left);
                    sussyGuy.setTexture2D(susGuy2d[3]);
                }

                if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
                {
                    sussyGuy.setDirection(Character.Direction.up);
                    sussyGuy.setTexture2D(susGuy2d[1]);
                }

                if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
                {
                    sussyGuy.setDirection(Character.Direction.down);
                    sussyGuy.setTexture2D(susGuy2d[2]);
                }

                if (GamePad.GetState(PlayerIndex.One).DPad.Right != ButtonState.Pressed && GamePad.GetState(PlayerIndex.One).DPad.Left != ButtonState.Pressed && GamePad.GetState(PlayerIndex.One).DPad.Up != ButtonState.Pressed && GamePad.GetState(PlayerIndex.One).DPad.Down != ButtonState.Pressed)
                {
                    sussyGuy.setDirection(Character.Direction.stop);

                    sussyGuy.setTexture2D(susGuy2d[4]);
                }
                //****************************************************************************
                //****************************************************************************

                //if player intersects a wall, call on wallupdate method to move it back to spawn
                for (int i = 0; i < wallsRec.Length; i++)
                {
                    if (sussyGuy.HitTest(wallsRec[i]))
                    {
                        sussyGuy.playerWallUpdate();

                    }
                }
                //if the player has collected all materials, endgame
                for (int i = 0; i < scrapsRecPosX.Length; i++)
                {
                    if (points == 6 && sussyGuy.HitTest(potholeRec))
                    {
                        winGameEnd = true;
                       
                    }
                }

                //remove the collected scraps from the list
                for (int i = 0; i < scraps.Count; ++i)
                    if (sussyGuy.HitTest(scraps[i].getRect()))
                    {
                        scraps.RemoveAt(i);
                        i--;
                        points++;

                    }
                for (int i = 0; i < zombie.Length; ++i)
                    if (sussyGuy.HitTest(zombie[i].getRect()))
                    {
                        sussyGuy.playerUpdate();
                        // playerHit.Play();
                    }
                //if the game ends play the ending music
                if (sussyGuy.getLives() <= 0)
                {
                    deathGameEnd = true;
                    dead.Play();
                    MediaPlayer.Pause();

                }
                //update the enemy function of changing direction
                for (int j = 0; j < zombie.Length; j++)
                {
                    zombie[j].enemyUpdate();
                }
                //update the zombies (gets the zombies to start moving)
                for (int i = 0; i < zombie.Length; i++)
                {
                    zombie[i].Update();
                }
                sussyGuy.Move();

            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            spriteBatch.Begin();
            //if the player has not won or died and has moved past the menu, Display the game
            if ( menuScreen != true  &&  (deathGameEnd != true || winGameEnd != true))
            {

            
            spriteBatch.Draw(dungeon, dungeonRec, Color.White);
                spriteBatch.Draw(potHole, potholeRec, Color.White);
                sussyGuy.DrawSprite(spriteBatch);
                //draw walls
                for (int i = 0; i < recWallPosWidth.Length; i++)
                {

                    spriteBatch.Draw(wall, wallsRec[i], Color.Black);
                }
                //draw zombies
                for (int i = 0; i < zombie.Length; i++)
                {
                    zombie[i].DrawSprite(spriteBatch);
                }
                //draw scraps
                for (int i = 0; i < scraps.Count; i++)
                {
                    scraps[i].DrawSprite(spriteBatch);
                }
                spriteBatch.DrawString(font, " Lives: " + sussyGuy.getLives() + "", new Vector2(250, 550), Color.Black);
            }
            //draw the you died screen
            if (deathGameEnd == true&& winGameEnd == false)
            {
                spriteBatch.Draw(death, endGame1Rec, Color.White);
                spriteBatch.DrawString(font, "You Lost ", new Vector2(180, 250), Color.White);

            }
            //draw the winner screen
            else if (winGameEnd == true && deathGameEnd == false)
            {
                spriteBatch.Draw(win, endGame2Rec, Color.White);
                spriteBatch.DrawString(font, "You Win ", new Vector2(180, 250), Color.White);
            }
            //draw the menu screen
            if (menuScreen == true)
            {
                GraphicsDevice.Clear(Color.Black);
                spriteBatch.DrawString(font1, "BEWARE PLAYER, THIS IS A HARDCORE GAME", new Vector2(0, 0), Color.OrangeRed);
                spriteBatch.DrawString(font1, "Hitting walls move you to spawn, zombies you lose health", new Vector2(0, 50), Color.White);
                spriteBatch.DrawString(font1, "Hitting walls move you to spawn, zombies you lose health", new Vector2(0, 100), Color.White);
                spriteBatch.DrawString(font1, "To win, you need to get to the pothole", new Vector2(0, 150), Color.White);
                spriteBatch.DrawString(font1, "with all the scraps to take back to base ", new Vector2(0, 200), Color.White);
                spriteBatch.DrawString(font1, "If you are up for the challenge press A ", new Vector2(0, 250), Color.White);
            }


            //spriteBatch.DrawString(font,zombieRec[0].X.ToString(), new Vector2(250, 250), Color.Red);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
