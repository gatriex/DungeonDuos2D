using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent (typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshRenderer))]


public class TileMap : MonoBehaviour {
   
    public int size_x = 16; //Number of tiles in the x direction
    public int size_z = 16; //Number of tiles in the z direction
    public float tileSize = 1.0f;
    public Texture2D terrainTiles;
    public int tileResolution;
    public int numrooms;
    public int room_size_x;
    public int room_size_y;
    public int room_x_variance;
    public int room_y_variance;


    private bool map_is_built = false;

    //Add new tile types in Editor
    public TDTile[] tile_types;
    //All the tiles are saved as an array of game objects in the tiles member
    [HideInInspector]
    public int[,] tiles;

    // Use this for initialization
    void Start () {
        //If map has not been built yet
        if (!map_is_built)
        {
            BuildMap();
        }
    }

    public void BuildMap()
    {
        if (transform.childCount > 0) DestroyMap();
        map_is_built = true;
        DTileMap map = new DTileMap(size_x, size_z, numrooms, room_size_x , room_size_y, room_x_variance, room_y_variance );
        tiles = new int[size_x, size_z];

        //Initialize the Tiles
        for (int x = 0; x < size_x; x++)
        {
            for (int z = 0; z < size_z; z++)
            {
                tiles[x, z] = map.map_data[x, z];
                //Debug.Log(tiles[x, z]);
            }
        }
        GenerateMapVisuals();
    }

    public void DestroyMap()
    {
        int numchildren = transform.childCount;
        while (numchildren != 0)
        {
           foreach (Transform child in transform)
           {
               DestroyImmediate(child.gameObject);
           }
            numchildren = transform.childCount;
        }
    }

    public void GenerateMapVisuals()
    {
        for (int x = 0; x < size_x-1; x++)
        {
            for (int z = 0; z < size_z-1; z++)
            {
                TDTile tt = tile_types[tiles[x, z] ];
                GameObject tile = Instantiate(tt.prefab, new Vector3(x, 0, z), Quaternion.identity ) as GameObject;
                tile.transform.rotation = Quaternion.Euler(90, 0, 0);
                tile.transform.parent = transform;
                tile.name = "Tile ("+x+" , " + z +" )";
            }
        }
    }
}
