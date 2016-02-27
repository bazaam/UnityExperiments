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

        public Location tilePosition;
        public int triggerId = 0;


        protected List<TileProperty> tileProperties = new List<TileProperty>();
        protected ArrayList toys;

        public Tile(string tileId, Location position, int trigger, ArrayList toyList)
        {

            tilePosition = position;
            toys = toyList;

            //constructor gives the tile its properties from its ID
            switch (tileId)
            {
                case "wall":
                    tileProperties.Add(TileProperty.terrain);
                    break;

                case "floor":
                    break;

                case "pressureplate":
                    tileProperties.Add(TileProperty.trigger);
                    triggerId = trigger;
                    break;

                case "pressuredoor":
                    tileProperties.Add(TileProperty.trigger);
                    tileProperties.Add(TileProperty.terrain);
                    triggerId = trigger;
                    break;

                default:
                    tileProperties = null;
                    break;
            }

            


        }

        //public accessors
        public List<TileProperty> GetProperties()

        {
            return tileProperties;
        }

        public ArrayList GetToys()
        {
            return toys;
        }

        public void AddToy(MoveableCharacter toy)
        {
            toys.Add(toy);
        }


        


    }
    public class TileMap
    {

        //static to allow their use in initialization
        protected static int xcount = 0;
        protected static int ycount = 0;

        protected Tile[,] tileArray = new Tile[xcount, ycount];


        //set the size and members of the tile array
        public TileMap(int x, int y, ArrayList tiles)
        {
            xcount = x;
            ycount = y;

            //generate the tile array
            foreach (Tile currentTile in tiles)
            {
                SetTile(currentTile, currentTile.tilePosition);
            }

        }


        public void SetTile(Tile tile, Location arrayPosition)
        {
            tileArray[arrayPosition.x, arrayPosition.y] = tile;
        }


    }
}






