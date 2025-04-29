
using UnityEngine;

/*
 [Collider]
 - 물리적인 충돌이나 트리거 이벤트 발생했을떄 호출
 - 물리 충돌이벤트 OnCollisionEnter(),OnCollisionStay(), OnCollisionExit()
  ㄴ오브젝트가 실제 충돌할때 발생하며, 최소한 하나의 오브젝트에는 Rigidbody가 필요함
  ㄴ반드시 Collider가 필요함
  ㄴ 두 오브젝트 모두 IsTrigger가 false여야함   

 - 트리거 이벤트 OnTriggerEnter(), OnTriggerStay(), OnTriggerExit()
  ㄴ 물리연산을 하지않고 오브젝트가 컬라이더 안으로 들어오거나 나갈때 발생
 
 
 
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
    //    Debug.Log("충돌이 처음 발생할때 호출");
    //    if(collision.gameObject.CompareTag("Wall"))
    //    {
    //        Debug.Log($"{collision.gameObject.name}와 충돌");
    //    }
    //}
    //private void OnCollisionStay(Collision collision)
    //{
    //    Debug.Log("충돌이 계속 발생할때 호출");
    //    Debug.Log($"{collision.gameObject.name}와 충돌");

    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("충돌이 끝났을때 호출");
    //    Debug.Log($"{collision.gameObject.name}와 충돌 종료");
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.gameObject.name}가 트리거에 진입");
    }
}
