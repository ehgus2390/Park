using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    // Inspector���� ������ �� �ִ� ������
    public Vector3 targetPosition = new Vector3(5f, 0f, 5f); // ��ǥ ��ġ
    public Vector3 rotationAngles = new Vector3(0f, 90f, 0f); // ȸ���� ����
    public float moveDelay = 2f; // �̵� �� ��� �ð�
    public float rotateDelay = 2f; // ȸ�� �� ��� �ð�
    public float moveDuration = 1f; // �̵��ϴ� �� �ɸ��� �ð�
    public float rotateDuration = 1f; // ȸ���ϴ� �� �ɸ��� �ð�

    void Start()
    {
        // �� �ڷ�ƾ ��� ����
        StartCoroutine(MoveWithDelayCo());
        StartCoroutine(RotateWithDelayCo());
    }

    // ���� �� �̵��ϴ� �ڷ�ƾ
    IEnumerator MoveWithDelayCo()
    {
        Debug.Log("�̵� ��� ����...");
        // ������ �ð���ŭ ���
        yield return new WaitForSeconds(moveDelay);
        
        Debug.Log("�̵� ����!");
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        
        // �ε巯�� �̵� ����
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / moveDuration;

            // ��¡ �Լ��� ����Ͽ� �� �ε巯�� �̵�
            t = Mathf.SmoothStep(0f, 1f, t);

            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        // ��Ȯ�� ���� ��ġ ����
        transform.position = targetPosition;
        Debug.Log("�̵� �Ϸ�!");
    }

    // ���� �� ȸ���ϴ� �ڷ�ƾ
    IEnumerator RotateWithDelayCo()
    {
        Debug.Log("ȸ�� ��� ����...");
        // ������ �ð���ŭ ���
        yield return new WaitForSeconds(rotateDelay);

        Debug.Log("ȸ�� ����!");
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(rotationAngles);
        float elapsedTime = 0f;

        // �ε巯�� ȸ�� ����
        while (elapsedTime < rotateDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / rotateDuration;

            // ��¡ �Լ��� ����Ͽ� �� �ε巯�� ȸ��
            t = Mathf.SmoothStep(0f, 1f, t);

            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            yield return null;
        }

        // ��Ȯ�� ���� ȸ�� ����
        transform.rotation = targetRotation;
        Debug.Log("ȸ�� �Ϸ�!");
    }

    // �̵��� ȸ���� ���������� �����ϴ� �ڷ�ƾ
    public void StartSequentialMovement()
    {
        StartCoroutine(SequentialMovementCo());
    }

    IEnumerator SequentialMovementCo()
    {
        // ���� �̵�
        yield return StartCoroutine(MoveWithDelayCo());
        // �̵��� �Ϸ�� �� ȸ��
        yield return StartCoroutine(RotateWithDelayCo());
        Debug.Log("��� ���� �Ϸ�!");
    }

    // ���� ���� ���� ��� ���� ����
    public void StopAllMovements()
    {
        StopAllCoroutines();
        Debug.Log("��� ������ �����Ǿ����ϴ�.");
    }


    // Ư�� ��ġ�� ��� �̵�
    public void SetInstantPosition(Vector3 position)
    {
        StopAllCoroutines();
        transform.position = position;
    }

    // Ư�� ������ ��� ȸ��
    public void SetInstantRotation(Vector3 angles)
    {
        StopAllCoroutines();
        transform.rotation = Quaternion.Euler(angles);
    }
}
