using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**********************************************************************
[�ڷ�ƾ]---->���� �ܰ�����
- ����Ƽ���� �ڷ�ƾ�� ������ �Ͻ������ϰ� ��� ����Ƽ��ȯ������ �ߴ��� �κп��� ���� �������� ����Ҽ� �ִ� �޼���
-�Ϲ����� ����Ƽ���� �ð��� ���� �۾��� ������ �� ������ ���
- �Ϲ����� �޼���� ȣ��Ǹ� ��� ����ǰ� ��������, �ڷ�ƾ�� Ư�� ������ �����Ҷ����� ������ ����� �ִ�.

[�ڷ�ƾ�� Ư¡]
IEnumerator�� �����ϴ� �޼���� �ۼ�
- yield Ű���带 ����Ͽ� ������ �Ͻ� �����ϰ� Ư�� ������ �����Ǹ� �ٽ� ����
- startCoroutine() �޼��带 ����Ͽ� �ڷ�ƾ�� ����, stopCoroutine(), StopAllCoroutines()�޼��带 ����Ͽ� �ڷ�ƾ�� ����
- ������ ������Ʈ �����ʹ� ���������� �����Ͽ� Ư�� �ð����� ����ϰų� �ݺ����� �۾��� �����Ҽ� ����

- [yield]
- yield return �� : ���� ���� ��ȯ�ϰ� ������ �Ͻ� ���� �� ���� ȣ��� �簳
- yield break : �ݺ� �Ǵ� �ڷ�ƾ�� ��� ����
- yield return null : ���� �����ӱ��� ���
- yield return new WaitForSecond(t) : t�� ���� ���
- yield return new waitUntil(����) : Ư�� ������ true�� �ɶ� ���� ���
- yield return new waitWhile(����) : Ư�� ������ false�� �ɶ�����
- yield return new StartCoroutine() : �ٸ� �ڷ�ƾ�� ����������

 * *******************************************************************/



//public class CoScript : MonoBehaviour
//{
//    private bool isRunning = true;

//    void Start()
//    {
//        // MainRoutineCo�� ȣ���� ���� �޼���� ȣ���ؾ� �մϴ�
//        StartCoroutine(MainRoutineCo());
//    }

//    void Update()
//    {
//        // Update���� �� �����Ӹ��� �ڷ�ƾ�� �����ϴ� ���� ��ȿ�����Դϴ�
//        // ��� Ű �Է��̳� Ư�� ���ǿ����� �����ϵ��� ����
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            StartCoroutine(PrintCo());
//        }
//    }

//    IEnumerator PrintCo()
//    {
//        for (int i = 0; i < 5; i++)
//        {
//            Debug.Log("�ڷ�ƾ ������ " + i);
//            yield return null; // ���� �����ӱ��� ���
//        }
//    }

//    IEnumerator PrintDelayCo()
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            Debug.Log("���� �ڷ�ƾ ������ " + i); // i�� ����ϵ��� ����
//            yield return new WaitForSeconds(1.0f); // 1�� ���
//        }
//    }

//    IEnumerator MainRoutineCo()
//    {
//        Debug.Log("���� ��ƾ ����");

//        // PrintCo ����
//        yield return StartCoroutine(PrintCo());
//        Debug.Log("PrintCo �Ϸ�");

//        // WaitCo ����
//        yield return StartCoroutine(WaitCo());
//        Debug.Log("WaitCo �Ϸ�");

//        // PrintDelayCo ����
//        yield return StartCoroutine(PrintDelayCo());
//        Debug.Log("PrintDelayCo �Ϸ�");

//        // ��� �ڷ�ƾ�� ���������� �ݺ� ����
//        while (isRunning)
//        {
//            Debug.Log("���ο� �ڷ�ƾ ����Ŭ ����");

//            yield return StartCoroutine(PrintCo());
//            yield return new WaitForSeconds(0.5f); // �ڷ�ƾ ���� ����

//            yield return StartCoroutine(PrintDelayCo());
//            yield return new WaitForSeconds(0.5f);

//            yield return StartCoroutine(WaitCo());
//            yield return new WaitForSeconds(1.0f); // ����Ŭ �� ��� �ð�
//        }
//    }

//    IEnumerator WaitCo()
//    {
//        Debug.Log("��� ����");
//        yield return new WaitForSeconds(2.0f);
//        Debug.Log("2�� ��� �Ϸ�");
//    }

//    // �ڷ�ƾ ��� ���� �߰� �޼����
//    public void StopAllCoroutines()
//    {
//        isRunning = false;
//        base.StopAllCoroutines();
//        Debug.Log("��� �ڷ�ƾ ������");
//    }

//    public void RestartCoroutines()
//    {
//        if (!isRunning)
//        {
//            isRunning = true;
//            StartCoroutine(MainRoutineCo());
//            Debug.Log("�ڷ�ƾ �ٽ� ����");
//        }
//    }

//    // ���� ������Ʈ�� ��Ȱ��ȭ�� �� ȣ��
//    void OnDisable()
//    {
//        StopAllCoroutines();
//    }
//}
