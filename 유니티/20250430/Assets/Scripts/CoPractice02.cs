using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoPractice02 : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(5f, 0f, 5f);
    public Vector3 rotationAngles = new Vector3(5f, 0f, 5f);
    public float moveDelay = 2f;
    public float rotateDelay = 2f;
    public float moveDuration = 1f;
    public float rotateDuration= 1f;
    // Start is called before the first frame update
    void Start()
    {
        //�� �ڷ�ƾ ��� ����
        StartCoroutine(MoveWithDelayCo());
        StartCoroutine(RotateWithDelayCo());
    }

    IEnumerator MoveWithDelayCo()
    {
        Debug.Log("�̵� ��� ����");
        //������ �ð���ŭ ���
        yield return new WaitForSeconds(moveDelay);

        Debug.Log("�̵� ����");
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;


    }

    IEnumerator RotateWithDelayCo()
    {
        Debug.Log("ȸ����� ����");
        yield return new WaitForSeconds(rotateDelay);

        Debug.Log("ȸ�� ����");
        Quaternion quaternion = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(rotationAngles);
        float elapsedTime = 0f;
    }

    //�̵��� ȸ���� ���������� �����ϴ� �ڷ�ƾ
    //public void StartSequentialMovement()
    //{
    //    StartCoroutine(StartSequentialMovement());
    //}

    //IEnumerator SequentialMovementCo()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
