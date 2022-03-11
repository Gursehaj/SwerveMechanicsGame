using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class pathGenerator : MonoBehaviour
{
    [Range(0f, 1f)]
    public float xScale;
    [Range(0f, 1f)]
    public float zScale;

    [Range(1, 10)]
    public int xLength;
    [Range(1, 10)]
    public int zWidth;

    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreatShape();
        UpdateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatShape()
    {
        vertices = new Vector3[(xLength + 1) * (zWidth + 1)];
        for (int i = 0, z = 0; z <= zWidth; z++)
        {
            for (int x = 0; x <= xLength; x++)
            {
                vertices[i] = new Vector3(x * xScale, 0, z * zScale);
                i++;
            }
        }

        triangles = new int[xLength * zWidth * 6];
        int tris = 0;
        int vert = 0;


        for (int z = 0; z< zWidth; z++)
        {
            for (int x = 0; x < xLength; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xLength + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xLength + 1;
                triangles[tris + 5] = vert + xLength + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        //vertices = new Vector3[]
        //{
        //    new Vector3(0,0,0),
        //    new Vector3(0,0,yScale),
        //    new Vector3(xScale,0,0),
        //    new Vector3(xScale,0,yScale)
        //};
        //triangles = new int[]
        //{
        //    0,1,2,
        //    1,3,2
        //};
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}
