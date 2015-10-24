using UnityEngine;
using System.Collections;


[RequireComponent (typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshRenderer))]


public class TileMap : MonoBehaviour {


    public int size_x = 100; //Number of tiles in the x direction
    public int size_z = 100; //Number of tiles in the z direction
    public float tileSize = 1.0f;

	// Use this for initialization
	void Start () {

        BuildMesh();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void BuildMesh()
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
                uv[z * vsize_x + x] = new Vector2( (float)x/vsize_x, (float)z/vsize_z );
            }
        }

        for (z = 0; z < size_z; z++)
        {
            for (x = 0; x < size_x; x++)
            {
                int squareIndex = z * size_x + x;
                int triIndex = squareIndex * 6;
                triangles[triIndex + 0] = 0;
                triangles[triIndex + 1] = vsize_x + 1;
                triangles[triIndex + 2] = vsize_x + 0;

                triangles[triIndex + 3] = 0;
                triangles[triIndex + 4] = 1;
                triangles[triIndex + 5] = vsize_x + 1;

            }
        }

        /*vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(1, 0, 0);
        vertices[2] = new Vector3(0, 0, -1);
        vertices[3] = new Vector3(1, 0, -1);

        triangles[0] = 0;
        triangles[1] = 3;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 1;
        triangles[5] = 3;

        normals[0] = Vector3.up;
        normals[1] = Vector3.up;
        normals[2] = Vector3.up;
        normals[3 ] = Vector3.up;

        uv[0] = new Vector2(0,0);
        uv[1] = new Vector2(1,0);
        uv[2] = new Vector2(0,1);
        uv[3] = new Vector2(1,1);*/



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
