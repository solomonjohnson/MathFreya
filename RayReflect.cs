using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayReflect : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Ray ray = new Ray(this.transform.position, transform.right);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit))
        {
        Debug.DrawLine(transform.position, hit.point,Color.red);
        Debug.DrawRay(hit.point, hit.normal, Color.blue);
            float dot = Vector3.Dot(ray.direction, hit.normal);
            Vector3 reflection = ray.direction - 2 * dot * hit.normal;
            Debug.DrawRay(hit.point, reflection,Color.red);
        }
        
    }
}
