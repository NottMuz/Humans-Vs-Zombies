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
  

    public class GameItem
    {
        //protected variables of the gameItem class
        protected Rectangle rec;
        protected Texture2D texture;
        protected Color clr;
        

        //constructer method for the game item
        public GameItem(Rectangle aRec, Texture2D aTexture, Color aColur)
        {
            this.setRect(aRec);
            this.setTexture2D(aTexture);
            this.setColor(aColur);
            

        }
        //gets the rectangle of the game item
        public Rectangle getRect()
        {
            return rec;
        }

        //sets the rectangle of the game item
        public void setRect(Rectangle someRect)
        {
            rec = someRect;
        }

        //gets the texture2d of the game item
        public Texture2D getTexture2D()
        {
            return texture;
        }
        //sets the texture2d of the game item
        public void setTexture2D(Texture2D someTexture2D)
        {
            texture = someTexture2D;
        }

        //gets the color of the game item
        public Color getColor()
        {
            return clr;
        }

        //sets the color of the game item
        public void setColor(Color someColur)
        {
            clr = someColur;
        }

        //hit test method if a gameItem or any of its children/sublclass intersects another rec
        public virtual bool HitTest(Rectangle otherRec)
        {
            if (this.rec.Intersects(otherRec))
            {
            return true;
            }
            else
            {
            return false;
            }
        }
        public virtual void DrawSprite(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, rec, clr);
        }
    }
}
 