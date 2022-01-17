using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[RequireComponent(typeof(MeshFilter))]
public class Sand : MonoBehaviour
{
    public Transform attachBlower;

    private float vBloxMax = 0.1f;
    private float vBlowMin = 0.05f; 

    private Mesh sand;
    private Transform transformSand;
    private int widthMesh = 100;
    Random rnd = new Random();

    private Vector3[] vertices;
    private int[] triangles;
    // Start is called before the first frame update
    void Awake()
    {
        sand = new Mesh();
        GetComponent<MeshFilter>().mesh = sand;
        transformSand = GetComponent<Transform>();
        Random rnd = new Random();

        createMesh();
        updateMesh();
    }

    private void Update()
    {
        vertices = sand.vertices;

        Vector3 distanceVector; 
        float distanceMag;

        for (int i = 0; i < vertices.Length; i++)
        {
            distanceVector = attachBlower.position - new Vector3(transformSand.position.x + (vertices[i].x * 0.1f), transformSand.position.y + vertices[i].y, transformSand.position.z + (vertices[i].z * 0.1f));
            distanceMag = distanceVector.magnitude;

            if (distanceMag < 0.5)
                vertices[i] = new Vector3(vertices[i].x, vertices[i].y - vBloxMax, vertices[i].z);
            else
                if(distanceMag < 1)
                    vertices[i] = new Vector3(vertices[i].x, vertices[i].y - vBlowMin, vertices[i].z);
        }

        sand.vertices = vertices;
    }

    private void updateMesh()
    {
        sand.Clear();

        sand.vertices = vertices;
        sand.triangles = triangles;
    }

    private void createMesh()
    {
        int count = 0;
        int indiceTriangles = 0;
        vertices = new Vector3[widthMesh* widthMesh];
        triangles = new int[(widthMesh-1) * (widthMesh-1) * 6];
        for (int i = 0; i < widthMesh; i++)
            for (int j = 0; j < widthMesh; j++)
            {
                if(i==0 || j==0 || i == widthMesh-1 || j == widthMesh - 1)
                    vertices[count] = new Vector3(i, 0, j);
                else
                    if (i < 5 || j < 5 || i > widthMesh - 6 || j > widthMesh - 6)
                        vertices[count] = new Vector3(i, UnityEngine.Random.Range(0.1f, 0.3f), j);
                    else
                        if (i < 10 || j < 10 || i > widthMesh - 11 || j > widthMesh - 11)
                            vertices[count] = new Vector3(i, UnityEngine.Random.Range(0.25f, 0.4f), j);
                        else
                            if (i < 15 || j < 15 || i > widthMesh - 16 || j > widthMesh - 16)
                                vertices[count] = new Vector3(i, UnityEngine.Random.Range(0.35f, 0.6f), j);
                            else
                                if (i < 19 || j < 19 || i > widthMesh - 20 || j > widthMesh - 20)
                                    vertices[count] = new Vector3(i, UnityEngine.Random.Range(0.55f, 0.7f), j);
                                else
                                    vertices[count] = new Vector3(i, UnityEngine.Random.Range(0.7f, 0.75f), j);

                if (i < widthMesh-1 && j < widthMesh-1)
                {
                    triangles[indiceTriangles] = count;
                    indiceTriangles++;
                    triangles[indiceTriangles] = count + 1;
                    indiceTriangles++;
                    triangles[indiceTriangles] = count + widthMesh;
                    indiceTriangles++;
                    triangles[indiceTriangles] = count+1;
                    indiceTriangles++;
                    triangles[indiceTriangles] = count + 1 + widthMesh;
                    indiceTriangles++;
                    triangles[indiceTriangles] = count + widthMesh;
                    indiceTriangles++;
                }

                count++;
            }

    }
}
