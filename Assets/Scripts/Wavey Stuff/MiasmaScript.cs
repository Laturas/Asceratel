using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiasmaScript : MonoBehaviour
{
    private Mesh mesh;
    [SerializeField] private Vector3[] vertices;
    [SerializeField] private Material material;
    [SerializeField] private int x, y;
    [SerializeField] private float height;
    private List<int> tris = new List<int>();

    public void Start()
    {
        vertices = new Vector3[x * y];
        mesh = new Mesh();

        for (int j = 0; j < vertices.Length;j++)
        {
            vertices[j] = new Vector3((j % x),0,(j / x));

        }
        for(int j = 0;j < vertices.Length - x;j++)
        {
            if (j % x == x - 1)
                continue;
            
            tris.Add(j);
            tris.Add(j + x);
            tris.Add(j + 1);
            tris.Add(j + 1);
            tris.Add(j + x);
            tris.Add(j + x + 1);
        }

        mesh.vertices = vertices;
        mesh.triangles = tris.ToArray();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material = material;

    }

    public void Update()
    {
        for (int j = 0; j < vertices.Length; j++)
        {
            //vertices[j] = new Vector3(vertices[j].x, SinWave(vertices[j].x, vertices[j].z) * height, vertices[j].z);
            vertices[j] = new Vector3(vertices[j].x, PerlinWave(vertices[j].x, vertices[j].z, 0.5F) * height, vertices[j].z);
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
    public float SinWave(float x, float z)
    {
        return Mathf.Sin(Time.time + x) + Mathf.Cos(Time.time + z);
    }

    public float PerlinWave(float x,float z,float scale)
    {
        return Mathf.PerlinNoise(Time.time + x * scale, Time.time + z * scale);
    }
}
