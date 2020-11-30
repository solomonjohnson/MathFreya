using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0, 10)] public int speed = 2;

    [Range(0, 90f)] public float Angle = 0f;
    private float angleInRad => Angle * Mathf.Deg2Rad;

    public Transform MyObj;

    private void Start()
    {
        MyObj.position = transform.position;
    }

    private void Update()
    {
        MyObj.position += MyObj.position + (Vector3)GetTrajectoryComponent(speed, Time.deltaTime * 50f, angleInRad);
    }

    private void OnDrawGizmos()
    {
        float dt = 1f / 10f;
        int points = 15;
        float time;

        for (int i = 0; i < points; i++)
        {
            time = i * dt;
            Gizmos.DrawSphere(transform.position + (Vector3)GetTrajectoryComponent(speed, time, angleInRad), 0.1f);
        }


    }

    Vector2 GetTrajectoryComponent(float speed, float time, float angle)
    {
        float x = speed * time * Mathf.Cos(angleInRad);
        float y = speed * time * Mathf.Sin(angleInRad) + .5f * Physics.gravity.y * time * time;
        return new Vector2(x, y);
    }
}
