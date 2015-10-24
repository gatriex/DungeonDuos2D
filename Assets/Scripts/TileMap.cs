using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent (typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshRenderer))]


public class TileMap : MonoBehaviour {

    public int size_x = 100; //Number of tiles in the x direction
    public int size_z = 100; //Number of tiles in the z direction
    public float tileSize = 1.0f;
    public Texture2D terrainTiles;
    public int tileResolution;


    // Use this for initialization
    void Start () {
        BuildMesh();
        //BuildTexture();
	}
	
    Color[][] ChopUpTiles()
    {
        int numTilesPerRow = terrainTiles.width / tileResolution;
        int numRows = terrainTiles.height / tileResolution;

        Color[][] tiles = new Color[numTilesPerRow * numRows][];

        for (int y =0; y <numRows; y++)
        {
            for (int x = 0; x <numTilesPerRow; x++)
            {
               tiles[y*numTilesPerRow + x] = terrainTiles.GetPixels(x* tileResolution, y*tileResolution, tileResolution, tileResolution);
            }
        }
        //Color[] p = terrainTiles.GetPixels(terrainTileOffset, 0, tileResolution, tileResolution);
        return tiles;
    }

    public void BuildTexture()
    {
        int tileResolution = terrainTiles.height;
        int numTilesPerRow = terrainTiles.width / tileResolution;
        int numRows = terrainTiles.height / tileResolution;

        Color[][] tiles = ChopUpTiles();

        int texWidth = size_x * tileResolution;
        int texHeight = size_z * tileResolution;
        Texture2D texture = new Texture2D(texWidth, texHeight);


        for (int y =0; y < size_z; y++)
        {
            for (int x = 0; x < size_x; x++)
            {

                Color[] p = tiles[Random.Range(0, 4)];
                texture.SetPixels(x*tileResolution , y*tileResolution , tileResolution, tileResolution, p);
            }
        }


        texture.filterMode= FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.Apply();

        MeshRenderer mesh_render = GetComponent<MeshRenderer>();
        mesh_render.sharedMaterials[0].mainTexture = texture; 
        Debug.Log("Texture done");
    }


    public void BuildMesh()
    {
        int num_Tiles = size_x * size_z;
        int numTriangles = num_Tiles * 2; 
        int vsize_x = size_x + 1;
        int vsize_z = size_z + 1;
        int numVerts = vsize_x * vsize_z;

        //Generate the mesh data (prcedural)
        Vector3[] vertices = new Vector3[numVerts];
        Vector3[] normals = new Vector3[numVerts];
        Vector2[] uv = new Vector2[numVerts];

        int[] triangles = new int[numTriangles * 3];

        //Assing the mesh data
        int x, z;
        for (z = 0; z < size_z; z++)   
        {
            for (x = 0; x < size_x; x++)
            {
                vertices[z * vsize_x + x] = new Vector3(x*tileSize, 0, z*tileSize);
                normals[z * vsize_x + x] = Vector3.up;
                uv[z * vsize_x + x] = new Vector2( (float)x/size_x, (float)z/size_z );
            }
        }

        for (z = 0; z < size_z; z++)
        {
            for (x = 0; x < size_x; x++)
            {
                int squareIndex = z * size_x + x;
                int triIndex = squareIndex * 6;
                triangles[triIndex + 0] = z * vsize_x + x + 0;
                triangles[triIndex + 1] = z * vsize_x + x + vsize_x + 0;
                triangles[triIndex + 2] = z * vsize_x + x + vsize_x + 1;

                triangles[triIndex + 3] = z * vsize_x + x + 0;
                triangles[triIndex + 4] = z * vsize_x + x + vsize_x + 1;
                triangles[triIndex + 5] = z * vsize_x + x + 1;

            }
        }

        //Create a new Mesh and populate with data
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        // Assign our mesh to our filter/rendere/collider
        MeshFilter mesh_filter = GetComponent<MeshFilter>();
        MeshCollider mesh_collider = GetComponent<MeshCollider>();
        MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();

        mesh_filter.mesh = mesh;
    }

}
