using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody m_bulletRigid;  
    private float m_bulletSpeed = 8.0f;
    // Start is called before the first frame update

    private void Awake()
    {
        m_bulletRigid = GetComponent<Rigidbody>();
    }
    void Start()
    {
        m_bulletRigid.velocity = transform.forward * m_bulletSpeed;
        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out PlayerControlor playerControlor))
            {
                playerControlor.Die();
            }
        }
    }
}
