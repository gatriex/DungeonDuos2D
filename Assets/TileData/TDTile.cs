using UnityEngine;
using System.Collections;

public enum TILE_TYPE 
{
    EMPTY,
    WALL,
    FLOOR,
    DARK,
}

[System.Serializable]
public class TDTile {
   


    public int type = (int)TILE_TYPE.EMPTY;
    public GameObject prefab;
    public bool isWalkable = true;


    public TDTile(TILE_TYPE type)
    {
        this.type = (int)type;
    }
}
