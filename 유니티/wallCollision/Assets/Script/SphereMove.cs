using UnityEngine;

public class SphereMove : MonoBehaviour
{
    public float moveSpeed = 5f; 

    private Rigidbody rb; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            enabled = false;
        }
    }

    
    void Update()
    {
        
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f; 
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f; 
        }
        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1f; 
        }
        if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1f; 
        }

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

       
        Vector3 worldMoveDirection = transform.TransformDirection(moveDirection);

        
        rb.velocity = worldMoveDirection * moveSpeed;
    }
}
