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
    public float yScale;

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
        vertices = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(0,0,yScale),
            new Vector3(xScale,0,0),
            new Vector3(xScale,0,yScale)
        };
        triangles = new int[]
        {
            0,1,2,
            1,3,2
        };
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
