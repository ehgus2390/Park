//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

///****************************************************
//[Collider]
//- 물리적인 충돌이나 트리거 이벤트 발생했을 때 호출
//-물리 충돌이벤트
//ㄴ 오브젝트가 실재 충돌할때 발생하며, 최소한 하나의 오브젝트에는 Rigidbody가 필요함
//ㄴ 반드시 Collider가 필요함
//ㄴ두 오브젝트 모두 Istrigger가 False여야함

//-트리거 이벤트 OnTriggerEnter(), OnTriggerStay(),OnTriggerExit()
//ㄴ물리연산을 하지않고 오브젝트가 컬라이더 안으로 들어오거나 나갈때 발생

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
//        Debug.Log("충돌이 처음발생할때");
//        if (collision.gameObject.CompareTag("Wall"));
//        {
//            Debug.Log($"{collision.gameObject.name}와 충돌");
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
