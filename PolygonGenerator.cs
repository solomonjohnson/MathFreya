using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonGenerator : MonoBehaviour
{
    [Range(2, 12)]
    public int VertexCount;
    
    [Range(2, 4)]
    public int d;

    public Vector3 AngleToDir(float angle) => new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));

    private void OnDrawGizmos()
    {
        List<Vector3> vertices = new List<Vector3>();

        //Generate vertices data
        for (int i = 0; i < VertexCount; i++)
        {
            Vector3 vertex = AngleToDir(i * Mathf.PI * 2 / VertexCount);
            vertices.Add(vertex);

        }

        //Draw Lines

        for (int i = 0; i < vertices.Count; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + vertices[i], transform.position + vertices[(i + d) % VertexCount]);
        }

        //Draw vertices

        for (int i = 0; i < vertices.Count; i++)
        {
            Gizmos.DrawSphere(transform.position + vertices[i], 0.1f);
        }
    }
}
