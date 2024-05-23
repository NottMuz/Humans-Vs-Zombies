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
    //inherit the character class
    class Enemy: Character
    {
        //protected variables of the enemy class
        protected int damageInflicted;
        private bool goingLeft;
       
        //constructer of an enemy
            public Enemy(Rectangle rec, Texture2D texture, Color clr, int health, int maxHealth, Direction direction, int speed, int aDamageInflicted, bool aGoingLeft)
           : base(rec, texture, clr, health, maxHealth, speed, direction)
        {
            this.setDamage(aDamageInflicted);
            this.setGoingLeft(aGoingLeft);
        }
        //gets the damage of an enemy
        public int getDamage()
        {
            return damageInflicted;
        }
        //sets the damage of an enemy
        public void setDamage(int someDamage)
        {
            damageInflicted = someDamage;
        }
        //gets the bool if it is going left or not
        public bool getGoingLeft()
        {
            return goingLeft;
        }
        //sets the bool if it is going left or not
        public void setGoingLeft(bool someGoingLeft)
        {
            goingLeft = someGoingLeft;
        }
        //update methode for the enemy
        public void enemyUpdate( )
        { 
            if (!goingLeft && speed < 0)
            {
                speed *= -1;
                
            }
            else if (goingLeft && speed > 0)
            {
                speed *= -1;
            }


            if (rec.Left <= 45)
            {
                goingLeft = false;
            }
            if (rec.Right >= 445)
            {
                goingLeft= true;
            }
            //rec.X += speed;
        }
        
        
    }
}
