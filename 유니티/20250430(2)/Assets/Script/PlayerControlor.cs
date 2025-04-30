using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerControlor : MonoBehaviour
{

    //[SerializeField] private GameObject m_bulletPrefab;
    //[SerializeField] private Transform target;
    private Rigidbody m_playerRigid;
    private float m_moveSpeed = 5.0f;

    private Rigidbody m_bulletRigid;
    private float m_bulletSpeed = 8.0f;

    [SerializeField] private GameObject m_bulletPrefab; // �Ѿ� ������

    private float fireRate = 1f; // �߻� ���� (1��)
    private float nextFire = 0f; // ���� �߻� ���� �ð�

    private void Awake()
    {
        m_playerRigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    m_playerRigid.AddForce(Vector3.forward * m_moveSpeed);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    m_playerRigid.AddForce(Vector3.back * m_moveSpeed);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    m_playerRigid.AddForce(Vector3.right * m_moveSpeed);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    m_playerRigid.AddForce(Vector3.left * m_moveSpeed);
        //}
        PlayerMove();

        FireBullet();
    }

    

    void PlayerMove()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 targetVelocity = new Vector3(hor * m_moveSpeed, m_playerRigid.velocity.y, ver * m_moveSpeed);
        m_playerRigid.velocity = Vector3.Lerp(m_playerRigid.velocity, targetVelocity, Time.deltaTime);

    }

    void FireBullet()
    {
        if(Time.time >= nextFire)
        {
            GameObject bullet = Instantiate(m_bulletPrefab, transform.position + transform.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = transform.forward * m_bulletSpeed;
            }
        }
    }
    public void Die()
    {
        gameObject.SetActive(false);

        Gamemanager gamemanager = FindObjectOfType<Gamemanager>();
        //gamemanager.EndGame();
    }


    //private void FixedUpdate()
    //{
        
    //}
}