
using System;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
           
    }
    private void FixedUpdate()
    {
        
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float moveX = 0.0f;
        float moveZ = 0.0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveZ = 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveZ = -1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1.0f;
        }
       
        // x,y,z
        Vector3 moveDirection = new Vector3(moveX, 0.0f, moveZ).normalized;
       
        if (moveDirection != Vector3.zero)
        {
            Vector3 move = rb.position + moveDirection * moveSpeed * Time.deltaTime;
            rb.MovePosition(move);
        }

       // float horizontal = Input.GetAxis("Horizontal");
       // float vertical = Input.GetAxis("Vertical");
       //
       // transform.Translate(Vector3.forward*vertical*moveSpeed*Time.deltaTime);
       // transform.Translate(Vector3.right*horizontal*moveSpeed*Time.deltaTime);
    }
}
