//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

///****************************************************
//[Collider]
//- �������� �浹�̳� Ʈ���� �̺�Ʈ �߻����� �� ȣ��
//-���� �浹�̺�Ʈ
//�� ������Ʈ�� ���� �浹�Ҷ� �߻��ϸ�, �ּ��� �ϳ��� ������Ʈ���� Rigidbody�� �ʿ���
//�� �ݵ�� Collider�� �ʿ���
//���� ������Ʈ ��� Istrigger�� False������

//-Ʈ���� �̺�Ʈ OnTriggerEnter(), OnTriggerStay(),OnTriggerExit()
//������������ �����ʰ� ������Ʈ�� �ö��̴� ������ �����ų� ������ �߻�

// * ***********************************************************/



//public class ColScript : MonoBehaviour
//{
//    private Renderer m_Renderer;
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }
//    void Update()
//    {
//        if(Input.GetKey(KeyCode.W))
//        {
//            transform.Translate(new Vector3(0.0f, 0.0f, 0.5f * Time.deltaTime));
//        }
//        if (Input.GetKey(KeyCode.S))
//        {
//            transform.Translate(new Vector3(0.0f, 0.0f, -0.5f * Time.deltaTime));
//        }
//    }
//    private void OnCollisionEnter(Collision collision)
//    {
//        Debug.Log("�浹�� ó���߻��Ҷ�");
//        if (collision.gameObject.CompareTag("Wall"));
//        {
//            Debug.Log($"{collision.gameObject.name}�� �浹");
//        }
//    }

//    private void OnCollisionStay(Collision collision)
//    {
        
//    }

//    private void OnCollisionExit(Collision collision)
//    {
        
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        Debug.Log($"{CollectionBase}")
//    }

//    // Update is called once per frame

//}
