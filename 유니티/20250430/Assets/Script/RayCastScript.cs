using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//RayCast
/**********************************************************
-특정방향으로 가상의 광선(Ray)을 쏴서 그 광선이 충돌한 객체를 감지하는 기능
-충돌감지, 터겟팅, 상호작용 등을 구현할 때 사용
-RayCast는 물리엔진을 사용하여 충돌을 감지, 일정방향으로 쏴서 무엇과 충돌하는지 파악한다.
-직접적인 물리연산을 하는것이 아니기 때문에 Update에서 처리

 * ********************************************************/
public class RayCastScript : MonoBehaviour
{
    private float m_speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float amtMove = m_speed * Time.deltaTime;
        float hor = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hor * amtMove);
        Debug.DrawRay(transform.position, transform.forward * 8, Color.red);
        //RaycastHit hit;

        //if (Physics.Raycast(transform.position,transform.forward,out hit))
        //{
        //    Debug.Log("충돌한 물체의 이름 :" + hit.collider.gameObject.name);

        //}
        RaycastHit[] raycastHits = Physics.RaycastAll(transform.position, transform.forward, 0.0f);


        //for (int i = 0; i < hits.Length; i++)
        //{

        //}
        foreach (RaycastHit hit in raycastHits)
        {
            
        }
    }
}
