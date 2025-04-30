using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExam : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private Vector3 m_pushDir;
    private bool isActiveforce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 2.0f, Color.red);

        RaycastHit raycastHit;
        if (Physics.Raycast(transform.position, transform.forward, out raycastHit,2.0f))
        {
            Debug.Log("충돌한 물체의 이름 :" + raycastHit.collider.gameObject.name);

            m_pushDir = -raycastHit.normal;
            isActiveforce = true;
        }
    }

    private void FixedUpdate()
    {
        if(isActiveforce && m_rigidbody != null)
        {
            Debug.Log("lisg");

        }
    }
}
