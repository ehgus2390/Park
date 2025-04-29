using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public Transform target;
    public float orbitSpeed = 30.0f;

    void Update()
    {
        // 공전
        transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime);
        // 자전 
        transform.Rotate(Vector3.up, 30.0f * Time.deltaTime);

    }
}
