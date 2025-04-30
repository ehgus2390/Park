using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//RayCast
/**********************************************************
-Ư���������� ������ ����(Ray)�� ���� �� ������ �浹�� ��ü�� �����ϴ� ���
-�浹����, �Ͱ���, ��ȣ�ۿ� ���� ������ �� ���
-RayCast�� ���������� ����Ͽ� �浹�� ����, ������������ ���� ������ �浹�ϴ��� �ľ��Ѵ�.
-�������� ���������� �ϴ°��� �ƴϱ� ������ Update���� ó��

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
        //    Debug.Log("�浹�� ��ü�� �̸� :" + hit.collider.gameObject.name);

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
