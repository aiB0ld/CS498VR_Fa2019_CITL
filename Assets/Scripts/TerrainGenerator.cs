using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    // Use this for initialization
    void Start () {
        // Debug.Log(hMap.width);
        // Debug.Log(hMap.height);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void GenerateTerrainMesh()
    {
        GenerateTerrainSectionMesh(0, 250, 0, 250);
        GenerateTerrainSectionMesh(0, 250, 250, 500);
        GenerateTerrainSectionMesh(0, 250, 500, 750);
        GenerateTerrainSectionMesh(0, 250, 750, 1000);

        GenerateTerrainSectionMesh(250, 500, 0, 250);
        GenerateTerrainSectionMesh(250, 500, 250, 500);
        GenerateTerrainSectionMesh(250, 500, 500, 750);
        GenerateTerrainSectionMesh(250, 500, 750, 1000);

        GenerateTerrainSectionMesh(500, 750, 0, 250);
        GenerateTerrainSectionMesh(500, 750, 250, 500);
        GenerateTerrainSectionMesh(500, 750, 500, 750);
        GenerateTerrainSectionMesh(500, 750, 750, 1000);

        GenerateTerrainSectionMesh(750, 1000, 0, 250);
        GenerateTerrainSectionMesh(750, 1000, 250, 500);
        GenerateTerrainSectionMesh(750, 1000, 500, 750);
        GenerateTerrainSectionMesh(750, 1000, 750, 1000);
    }

    public void GenerateTerrainSectionMesh(int xLow, int xHigh, int yLow, int yHigh)
    {
        Texture2D hMap = Resources.Load<Texture2D>("Textures/terrain_hMap");
        Material terrainMaterial = Resources.Load<Material>("Materials/TerrainMaterial");

        List<Vector3> verts = new List<Vector3>();
        List<int> tris = new List<int>();

        for (int i = xLow; i < xHigh; i++)
        {
            for (int j = yLow; j < yHigh; j++)
            {
                int x = i - xLow;
                int y = j - yLow;
                //Add each new vertex in the plane
                verts.Add(new Vector3(i, hMap.GetPixel(i, j).grayscale * 100, j));
                //Skip if a new square on the plane hasn't been formed
                if (x == 0 || y == 0) continue;
                //Adds the index of the three vertices in order to make up each of the two tris
                tris.Add(250 * x + y); //Top right
                tris.Add(250 * x + y - 1); //Bottom right
                tris.Add(250 * (x - 1) + y - 1); //Bottom left - First triangle
                tris.Add(250 * (x - 1) + y - 1); //Bottom left 
                tris.Add(250 * (x - 1) + y); //Top left
                tris.Add(250 * x + y); //Top right - Second triangle
            }
        }

        Vector2[] uvs = new Vector2[verts.Count];
        for (var i = 0; i < uvs.Length; i++) //Give UV coords X,Z world coords
            uvs[i] = new Vector2(verts[i].x, verts[i].z);

        GameObject plane = new GameObject(string.Format("Terrain_{0}_{1}", (xLow / 250).ToString(), (yLow / 250).ToString())); //Create GO and add necessary components
        plane.AddComponent<MeshFilter>();
        plane.AddComponent<MeshRenderer>();
        Mesh terrainMesh = new Mesh
        {
            vertices = verts.ToArray(), //Assign verts, uvs, and tris to the mesh
            uv = uvs,
            triangles = tris.ToArray()
        };
        terrainMesh.RecalculateNormals(); //Determines which way the triangles are facing
        plane.GetComponent<MeshFilter>().mesh = terrainMesh; //Assign Mesh object to MeshFilter
        plane.GetComponent<MeshRenderer>().material = terrainMaterial;
    }

}
