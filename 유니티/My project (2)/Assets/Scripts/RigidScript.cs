
using UnityEngine;

public class RigidScript : MonoBehaviour
{

    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
 

    //void Update()
    //{
    //    //if(Input.GetKey(KeyCode.W))
    //    //{
    //    //    transform.Translate(new Vector3(0.0f, 0.0f, 5.0f * Time.deltaTime));
    //    //}
    //}
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            // rb.AddForce(Vector3.forward * 20.0f);

            rb.velocity = new Vector3(0, 0, 3.0f);
        }
    }
}
