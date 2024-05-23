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
    //inherit from the game item
    class CollectableGameItem: GameItem
    {
        //protected variable of the COllectable gameitem class
        protected int clectblePnts;
        //constructer method for a collectableGameitem
        public CollectableGameItem(Rectangle rec , Texture2D texture, Color clr, int aClectblePnts )
            :base(rec, texture, clr)
        {
            this.setCollectablePoints(aClectblePnts);
        }
        //gets the points of a gameItem
        public int getCollectablepoints()
        {
            return clectblePnts;
        }
        //sets the points of a gameItem
        public void setCollectablePoints(int someClectblePoints)
        {
            clectblePnts = someClectblePoints;
        }
        //updates the gameItem
        public void update()
        {
            clectblePnts++;
        }
    }
}
