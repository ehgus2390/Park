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



public class CoScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PrintCo());
    }
    IEnumerator PrintCo()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("�ڷ�ƾ ������" + i);
            yield return null;
        }
    }

    IEnumerator PrintDelayCo()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("�ڷ�ƾ ������" + 1);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
