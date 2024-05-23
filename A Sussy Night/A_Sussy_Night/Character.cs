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
    //inherit from gameItem class
    class Character : GameItem
    {
        //protected variables of the charachter class
        protected int health;
        protected int maxHealth;
        protected int speed;
        protected Direction direction;

        //enum method for direction
        public enum Direction
        {
            left, right, up, down, stop
        }

        //constructor method a character
        public Character(Rectangle rec, Texture2D texture, Color clr, int aHealth, int aMaxHealth, int aSpeed, Direction aDirection)
            : base( rec, texture, clr)
        {
            this.setHealth(aHealth);
            this.setMaxHealth(aMaxHealth);
            this.setSpeed(aSpeed);
            this.setDirection(Direction.right);
        }
        //gets the health of a character
        public int getHealth()
        {
            return health;
        }
        //sets the health of a character
        public void setHealth(int someHealth)
        {
            health = someHealth;
        }
        //gets the max health of a character
        public int getMaxHealth()
        {
            return health;
        }
        //sets the max health of a character
        public void setMaxHealth(int someMaxHealth)
        {
            maxHealth = someMaxHealth;
        }
        //gets the speed of a character
        public int getSpeed()
        {
            return speed;
        }
        //sets the speed of a character
        public void setSpeed(int someSpeed)
        {
            speed = someSpeed;
        }
        //gets the direction of a character
        public Direction getDirection()
        {
            return direction;
        }
        //sets the direction of a character
        public void setDirection(Direction someDirection)

        {
            direction = someDirection;
        }

        //move method for a character
        public void Move()
        {
           if(direction==Direction.right)
            {
                rec.X+= speed;
            }

            if (direction == Direction.left)
            {
                rec.X -= speed;
            }

            if (direction == Direction.up)
            {
                rec.Y -= speed;
            }

            if (direction == Direction.down)
            {
                rec.Y += speed;
            }
            if (direction == Direction.down)
            {
                rec.Y += 0;
                rec.Y -= 0;
                rec.X -= 0;
                rec.X += 0;
            }
        }
        //update the character
        public void Update()
        {
            this.rec.X += this.speed;
        }
    }
}
