using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileSystem : MonoBehaviour
{
    public struct Location
    {
        public int x;
        public int y;
    }

    public TileSystem()
    {

    }




    public class Tile
    {

        public enum TileProperty
        {
            terrain,
            trigger,
            exit,


        };

        public List<TileProperty> tileProperties = new List<TileProperty>();

        public Tile(int tileId)
        {

            //constructor gives the tile its properties from its ID
            switch (tileId)
            {
                case 0:
                    tileProperties = {TileProperty.terrain};
                    break;

                default:
                    tileProperties = null;
                    break;
            }
                
        }


    }


    public class TileMap
    {

        //static to allow their use in initialization
        protected static int xcount = 0;
        protected static int ycount = 0;


        //constructor, primarily for setting the size of the tile array
        public TileMap(int x, int y)
        {
            xcount = x;
            ycount = y;
        }


        protected Tile[,] tileArray = new Tile[xcount, ycount];

        public void SetTile(Tile tile, Location arrayPosition)
        {
            tileArray[arrayPosition.x, arrayPosition.y] = tile;
        }
    }
	
}
