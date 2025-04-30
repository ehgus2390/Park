using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Color[] wallColors = { Color.red, Color.green, Color.blue };
    private Index colorIndex = 0;
   
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, 0.5f * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, -0.5f * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0.5f, 0.0f, 0.0f * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-0.5f, 0.0f, 0.0f * Time.deltaTime));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //Renderer wallRenderer = collision.gameObject.GetComponent<Renderer>();

            //if (wallRenderer != null)
            //{
            //    wallRenderer.material.color = wallColors[colorindex];
            //}
            if (collision.gameObject.TryGetComponent<Renderer>(out Renderer wallRenderer))
            {
                wallRenderer.material.color = wallColors[colorIndex];
            }
            //colorIndex = (colorIndex + 1) % wallColors.Length;
        }
    }
    // Update is called once per frame
    
}
