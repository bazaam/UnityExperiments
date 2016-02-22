using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ObjectController : MonoBehaviour
{
    public void Move(TileSystem.Tile target, int direction)
    {
        ArrayList toys = target.GetToys();
        List<TileSystem.Tile.TileProperty> properties = target.GetProperties();


    }
}