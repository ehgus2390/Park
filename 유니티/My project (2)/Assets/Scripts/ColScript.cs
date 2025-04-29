
using UnityEngine;

/*
 [Collider]
 - �������� �浹�̳� Ʈ���� �̺�Ʈ �߻������� ȣ��
 - ���� �浹�̺�Ʈ OnCollisionEnter(),OnCollisionStay(), OnCollisionExit()
  ��������Ʈ�� ���� �浹�Ҷ� �߻��ϸ�, �ּ��� �ϳ��� ������Ʈ���� Rigidbody�� �ʿ���
  ���ݵ�� Collider�� �ʿ���
  �� �� ������Ʈ ��� IsTrigger�� false������   

 - Ʈ���� �̺�Ʈ OnTriggerEnter(), OnTriggerStay(), OnTriggerExit()
  �� ���������� �����ʰ� ������Ʈ�� �ö��̴� ������ �����ų� ������ �߻�
 
 
 
 */
public class ColScript : MonoBehaviour
{



    private Renderer renderer;

    // Update is called once per frame

    private void Awake()
    {
        renderer = GetComponent<Renderer>();    
    }
    private void Start()
    {
        renderer.material.color = Color.blue;    
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, 5.0f * Time.deltaTime));
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, -5.0f * Time.deltaTime));
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("�浹�� ó�� �߻��Ҷ� ȣ��");
    //    if(collision.gameObject.CompareTag("Wall"))
    //    {
    //        Debug.Log($"{collision.gameObject.name}�� �浹");
    //    }
    //}
    //private void OnCollisionStay(Collision collision)
    //{
    //    Debug.Log("�浹�� ��� �߻��Ҷ� ȣ��");
    //    Debug.Log($"{collision.gameObject.name}�� �浹");

    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("�浹�� �������� ȣ��");
    //    Debug.Log($"{collision.gameObject.name}�� �浹 ����");
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.gameObject.name}�� Ʈ���ſ� ����");
    }
}
