using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace A_Sussy_Night
{
    //inherit from the Character class
    class Player : Character
    {
        //protected Variables of the player class
        protected int lives;

        //constructer method for a player
        public Player(Rectangle rec, Texture2D texture, Color clr, int health, int maxHealth, Direction direction, int speed, int aLives)
           : base (rec, texture, clr, health, maxHealth, speed, direction ) 
        {
            this.setLives(aLives);
        }
        //get the lives of a player
        public int getLives()
        {
            return lives;
        }
        //set the lives of a player
        public void setLives(int someLives)
        {
            lives = someLives;
        }
        //update the player
        public void playerUpdate()
          
       {
            lives--;
            rec.X = 46;
            rec.Y = 533;
       }
        //update the player when they hit a wall
        public void playerWallUpdate()

        {
            
            rec.X = 46;
            rec.Y = 533;
        }

    }
}
