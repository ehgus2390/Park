using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**********************************************************************
[코루틴]---->면접 단골질문
- 유니티에서 코루틴은 실행을 일시정지하고 제어를 유니티반환하지만 중단한 부분에서 다음 프레임을 계속할수 있는 메서드
-일반적인 유니티에서 시간에 따라 작업을 수행할 때 유용한 기능
- 일반적인 메서드는 호출되면 즉시 실행되고 끝나지만, 코루틴은 특정 조건을 만족할때까지 실행을 멈출수 있다.

[코루틴의 특징]
IEnumerator를 리턴하는 메서드로 작성
- yield 키워드를 사용하여 실행을 일시 중지하고 특정 조건이 충족되면 다시 실행
- startCoroutine() 메서드를 사용하여 코루틴을 시작, stopCoroutine(), StopAllCoroutines()메서드를 사용하여 코루틴을 중지
- 게임의 업데이트 루프와는 독립적으로 동작하여 특정 시간동안 대기하거나 반복적인 작업을 수행할수 있음

- [yield]
- yield return 값 : 현재 값을 반환하고 실행을 일시 중지 후 다음 호출시 재개
- yield break : 반복 또는 코루틴을 즉시 종료
- yield return null : 다음 프레임까지 대기
- yield return new WaitForSecond(t) : t초 동안 대기
- yield return new waitUntil(조건) : 특정 조건이 true가 될때 까지 대기
- yield return new waitWhile(조건) : 특정 조건이 false가 될때까지
- yield return new StartCoroutine() : 다른 코루틴이 끝날때까지

 * *******************************************************************/



//public class CoScript : MonoBehaviour
//{
//    private bool isRunning = true;

//    void Start()
//    {
//        // MainRoutineCo를 호출할 때는 메서드로 호출해야 합니다
//        StartCoroutine(MainRoutineCo());
//    }

//    void Update()
//    {
//        // Update에서 매 프레임마다 코루틴을 시작하는 것은 비효율적입니다
//        // 대신 키 입력이나 특정 조건에서만 시작하도록 수정
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            StartCoroutine(PrintCo());
//        }
//    }

//    IEnumerator PrintCo()
//    {
//        for (int i = 0; i < 5; i++)
//        {
//            Debug.Log("코루틴 실행중 " + i);
//            yield return null; // 다음 프레임까지 대기
//        }
//    }

//    IEnumerator PrintDelayCo()
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            Debug.Log("지연 코루틴 실행중 " + i); // i를 출력하도록 수정
//            yield return new WaitForSeconds(1.0f); // 1초 대기
//        }
//    }

//    IEnumerator MainRoutineCo()
//    {
//        Debug.Log("메인 루틴 시작");

//        // PrintCo 실행
//        yield return StartCoroutine(PrintCo());
//        Debug.Log("PrintCo 완료");

//        // WaitCo 실행
//        yield return StartCoroutine(WaitCo());
//        Debug.Log("WaitCo 완료");

//        // PrintDelayCo 실행
//        yield return StartCoroutine(PrintDelayCo());
//        Debug.Log("PrintDelayCo 완료");

//        // 모든 코루틴을 순차적으로 반복 실행
//        while (isRunning)
//        {
//            Debug.Log("새로운 코루틴 사이클 시작");

//            yield return StartCoroutine(PrintCo());
//            yield return new WaitForSeconds(0.5f); // 코루틴 사이 간격

//            yield return StartCoroutine(PrintDelayCo());
//            yield return new WaitForSeconds(0.5f);

//            yield return StartCoroutine(WaitCo());
//            yield return new WaitForSeconds(1.0f); // 사이클 간 대기 시간
//        }
//    }

//    IEnumerator WaitCo()
//    {
//        Debug.Log("대기 시작");
//        yield return new WaitForSeconds(2.0f);
//        Debug.Log("2초 대기 완료");
//    }

//    // 코루틴 제어를 위한 추가 메서드들
//    public void StopAllCoroutines()
//    {
//        isRunning = false;
//        base.StopAllCoroutines();
//        Debug.Log("모든 코루틴 중지됨");
//    }

//    public void RestartCoroutines()
//    {
//        if (!isRunning)
//        {
//            isRunning = true;
//            StartCoroutine(MainRoutineCo());
//            Debug.Log("코루틴 다시 시작");
//        }
//    }

//    // 게임 오브젝트가 비활성화될 때 호출
//    void OnDisable()
//    {
//        StopAllCoroutines();
//    }
//}
