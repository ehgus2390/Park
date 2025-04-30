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
        //두 코루틴 모두 시작
        StartCoroutine(MoveWithDelayCo());
        StartCoroutine(RotateWithDelayCo());
    }

    IEnumerator MoveWithDelayCo()
    {
        Debug.Log("이동 대기 시작");
        //지정된 시간만큼 대기
        yield return new WaitForSeconds(moveDelay);

        Debug.Log("이동 시작");
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;


    }

    IEnumerator RotateWithDelayCo()
    {
        Debug.Log("회전대기 시작");
        yield return new WaitForSeconds(rotateDelay);

        Debug.Log("회전 시작");
        Quaternion quaternion = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(rotationAngles);
        float elapsedTime = 0f;
    }

    //이동과 회전을 순차적으로 실행하는 코루틴
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
