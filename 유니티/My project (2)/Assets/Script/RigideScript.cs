using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidscript : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        transform.Translate(new Vector3(0.0f, 0.0f, 5.0f * Time.deltaTime));
    //    }
    //}

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            //rb.AddForce(Vector3.forward * 20.0f);
            rb.velocity = new Vector3(0,0,3.0f);
        }
    }
}
