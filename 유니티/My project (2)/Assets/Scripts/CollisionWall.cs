using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWall : MonoBehaviour
{

    private Renderer renderer;

    // Update is called once per frame
    private void Start()
    {
        renderer = GetComponent<Renderer>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedWall"))
        {
            renderer.material.color = Color.red;
        }
        if (collision.gameObject.CompareTag("BlueWall"))
        {
            renderer.material.color = Color.blue;
        }
        if (collision.gameObject.CompareTag("GreenWall"))
        {
            renderer.material.color = Color.green;
        }
    }
}
