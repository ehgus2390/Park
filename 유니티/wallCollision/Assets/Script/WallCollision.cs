using UnityEngine;

public class ChangeColorOnCollision : MonoBehaviour
{
    public Color targetColor = Color.red; // 충돌 시 변경할 색상 (인스펙터에서 설정 가능)
    private Renderer cubeRenderer;

    void Start()
    {
        // 이 스크립트가 적용된 오브젝트의 Renderer 컴포넌트를 가져옵니다.
        cubeRenderer = GetComponent<Renderer>();

        // Renderer 컴포넌트가 없으면 에러 메시지를 출력하고 스크립트를 종료합니다.
        if (cubeRenderer == null)
        {
            Debug.LogError("Renderer component not found on this GameObject!");
            enabled = false;
        }
    }

    // 다른 콜라이더와 충돌했을 때 호출되는 함수
    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 태그가 "Sphere"인지 확인합니다.
        if (collision.gameObject.CompareTag("Sphere"))
        {
            // 큐브의 머티리얼 색상을 targetColor로 변경합니다.
            cubeRenderer.material.color = targetColor;
        }
    }

    //충돌이 끝났을 때(선택 사항)
     void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            // 충돌이 끝났을 때 원래 색상으로 되돌리거나 다른 동작을 수행할 수 있습니다.
            cubeRenderer.material.color = Color.white; // 예시: 흰색으로 되돌리기
        }
    }
}
