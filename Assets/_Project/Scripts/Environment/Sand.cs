using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Sand : MonoBehaviour
{
    //Blower Transform
    public Transform attachBlower;

    //blowing speed
    private float vBloxMax = 0.01f;
    private float vBlowMin = 0.001f;
    private bool isBlowerActive = false;

    //mesh variables
    private Mesh sand;
    private Transform transformSand;
    private int widthMesh = 100;
    private Vector3[] vertices;
    private int[] triangles;

    void Awake()
    {
        sand = new Mesh();
        GetComponent<MeshFilter>().mesh = sand;
        transformSand = GetComponent<Transform>();

        createMesh();
        updateMesh();
    }

    private void Update()
    {
        vertices = sand.vertices;

        Vector3 distanceVector; 
        float distanceMag;

        if(isBlowerActive)
        {
            //Step through mesh vertices position
            for (int i = 0; i < vertices.Length; i++)
            {
                //Calculate the distance between the vertex and the blower
                distanceVector = attachBlower.position - new Vector3(transformSand.position.x + (vertices[i].x * 0.1f), transformSand.position.y + vertices[i].y, transformSand.position.z + (vertices[i].z * 0.1f));
                distanceMag = distanceVector.magnitude;

                //Sink the vertex according to the distance
                if (distanceMag < 1)
                    vertices[i] = new Vector3(vertices[i].x, vertices[i].y - vBloxMax, vertices[i].z);
                else
                    if (distanceMag < 3)
                    vertices[i] = new Vector3(vertices[i].x, vertices[i].y - vBlowMin, vertices[i].z);
            }

            //Update mesh vertices position
            sand.vertices = vertices;
        }
    }

    /*
     * Initialize mesh values
     */
    private void updateMesh()
    {
        sand.Clear();

        sand.vertices = vertices;
        sand.triangles = triangles;
    }

    /*
     *  Fill with values the array of vertex positions
     *  of the mesh and the array of indices of positions
     *  that form the triangles
     */
    private void createMesh()
    {
        int count = 0;
        int indiceTriangles = 0;
        vertices = new Vector3[widthMesh* widthMesh];
        triangles = new int[(widthMesh-1) * (widthMesh-1) * 6];

        //Loop the mesh
        for (int i = 0; i < widthMesh; i++)
            for (int j = 0; j < widthMesh; j++)
            {
                //Assign the height according to the position of the vertex
                if (i==0 || j==0 || i == widthMesh-1 || j == widthMesh - 1)
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

                //Assign the indices of the positions that make up the triangles
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

    public void setIsBlowerActive(bool isActive)
    {
        isBlowerActive = isActive;
    }
}
