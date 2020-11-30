using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEvaluator : MonoBehaviour
{

    public MeshFilter ObjMesh;

    public float Area;

    private void Update()
    {
         if (Input.GetKeyUp(KeyCode.Space))
        {
            Area = 0;
            CalculateMeshArea();
        }
    }

    private void CalculateMeshArea()
    {
        Mesh mesh = ObjMesh.mesh;
        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            Vector3 vec01 = mesh.vertices[mesh.triangles[i + 1]] - mesh.vertices[mesh.triangles[i]];
            Vector3 vec12 = mesh.vertices[mesh.triangles[i + 2]] - mesh.vertices[mesh.triangles[i]];
            Area += Vector3.Cross(vec01, vec12).magnitude;
        }
        Area /= 2;

    }

}
