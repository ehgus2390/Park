using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    // Inspector에서 설정할 수 있는 변수들
    public Vector3 targetPosition = new Vector3(5f, 0f, 5f); // 목표 위치
    public Vector3 rotationAngles = new Vector3(0f, 90f, 0f); // 회전할 각도
    public float moveDelay = 2f; // 이동 전 대기 시간
    public float rotateDelay = 2f; // 회전 전 대기 시간
    public float moveDuration = 1f; // 이동하는 데 걸리는 시간
    public float rotateDuration = 1f; // 회전하는 데 걸리는 시간

    void Start()
    {
        // 두 코루틴 모두 시작
        StartCoroutine(MoveWithDelayCo());
        StartCoroutine(RotateWithDelayCo());
    }

    // 지연 후 이동하는 코루틴
    IEnumerator MoveWithDelayCo()
    {
        Debug.Log("이동 대기 시작...");
        // 지정된 시간만큼 대기
        yield return new WaitForSeconds(moveDelay);
        
        Debug.Log("이동 시작!");
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        
        // 부드러운 이동 실행
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / moveDuration;

            // 이징 함수를 사용하여 더 부드러운 이동
            t = Mathf.SmoothStep(0f, 1f, t);

            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        // 정확한 최종 위치 설정
        transform.position = targetPosition;
        Debug.Log("이동 완료!");
    }

    // 지연 후 회전하는 코루틴
    IEnumerator RotateWithDelayCo()
    {
        Debug.Log("회전 대기 시작...");
        // 지정된 시간만큼 대기
        yield return new WaitForSeconds(rotateDelay);

        Debug.Log("회전 시작!");
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(rotationAngles);
        float elapsedTime = 0f;

        // 부드러운 회전 실행
        while (elapsedTime < rotateDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / rotateDuration;

            // 이징 함수를 사용하여 더 부드러운 회전
            t = Mathf.SmoothStep(0f, 1f, t);

            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            yield return null;
        }

        // 정확한 최종 회전 설정
        transform.rotation = targetRotation;
        Debug.Log("회전 완료!");
    }

    // 이동과 회전을 순차적으로 실행하는 코루틴
    public void StartSequentialMovement()
    {
        StartCoroutine(SequentialMovementCo());
    }

    IEnumerator SequentialMovementCo()
    {
        // 먼저 이동
        yield return StartCoroutine(MoveWithDelayCo());
        // 이동이 완료된 후 회전
        yield return StartCoroutine(RotateWithDelayCo());
        Debug.Log("모든 동작 완료!");
    }

    // 현재 진행 중인 모든 동작 중지
    public void StopAllMovements()
    {
        StopAllCoroutines();
        Debug.Log("모든 동작이 중지되었습니다.");
    }


    // 특정 위치로 즉시 이동
    public void SetInstantPosition(Vector3 position)
    {
        StopAllCoroutines();
        transform.position = position;
    }

    // 특정 각도로 즉시 회전
    public void SetInstantRotation(Vector3 angles)
    {
        StopAllCoroutines();
        transform.rotation = Quaternion.Euler(angles);
    }
}
