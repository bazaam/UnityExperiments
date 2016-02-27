using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MoveableCharacter : MonoBehaviour
{
    protected ArrayList toys;
    protected List<TileSystem.Tile.TileProperty> properties;
    public bool canMove = false;

    public virtual void Move(TileSystem.Tile target, int direction)
    {
        
        toys = target.GetToys();
        properties = target.GetProperties();


    }
}

public class Player : MoveableCharacter
{
    public override void Move(TileSystem.Tile target, int direction)
    {
        base.Move(target, direction);

        foreach (TileSystem.Tile.TileProperty property in properties)
        {
            if (property == TileSystem.Tile.TileProperty.terrain)
            {
                //add can't move into wall behavior here

                return;
            }

            else canMove = true;

        }

        if (canMove)
        {
            foreach (MoveableCharacter toy in toys)
            {
                if (toy is Water) 
                {
                    //add can't move into water behavior here
                    return;
                }

                if (toy is Ball)
                {
                    toy.Move((target.GetNeighbor(direction)), direction);
                    if (!toy.canMove)
                    {
                        //ball is stuck behavior
                        return;
                    }

                }

            }
        
            //do the actual moving here
            target.AddToy(this);
            GraphicOutput.UpdateToy(this, target);
         }

        


    }

}

public class Ball : MoveableCharacter 
{
    public override void Move(TileSystem.Tile target, int direction)
    {
        base.Move(target, direction);
    }
}

public class Box : MoveableCharacter
{
    public override void Move(TileSystem.Tile target, int direction)
    {
        base.Move(target, direction);
    }
}

public class Water : MoveableCharacter
{
    public override void Move(TileSystem.Tile target, int direction)
    {
        base.Move(target, direction);

    }
}