using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoScripts01 : MonoBehaviour
{
    private Renderer m_cubeRenderer;
    public float colorChangeInterval = 1.0f; // 색상 변경 간격 (초)
    private bool isChangingColor = true; // 색상 변경 활성화 상태

    void Start()
    {
        // 현재 게임 오브젝트의 Renderer 컴포넌트 가져오기
        m_cubeRenderer = GetComponent<Renderer>();

        // 컴포넌트가 존재하는지 확인
        if (m_cubeRenderer != null)
        {
            // 코루틴 시작
            StartCoroutine(ChangeColorCo());
        }
        else
        {
            Debug.LogError("Renderer component not found!");
        }
    }

    IEnumerator ChangeColorCo()
    {
        while (isChangingColor)
        {
            // 랜덤 색상 생성
            Color newColor = new Color(Random.value, Random.value, Random.value);

            // 현재 색상에서 새로운 색상으로 부드럽게 전환
            Color currentColor = m_cubeRenderer.material.color;
            float elapsedTime = 0f;

            while (elapsedTime < colorChangeInterval)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / colorChangeInterval;
                m_cubeRenderer.material.color = Color.Lerp(currentColor, newColor, t);
                yield return null;
            }

            // 정확한 색상 설정
            m_cubeRenderer.material.color = newColor;

            // 다음 색상 변경 전까지 대기
            yield return new WaitForSeconds(0.1f);
        }
    }

    // 색상 변경 시작
    public void StartColorChange()
    {
        if (!isChangingColor)
        {
            isChangingColor = true;
            StartCoroutine(ChangeColorCo());
        }
    }

    // 색상 변경 중지
    public void StopColorChange()
    {
        isChangingColor = false;
        StopCoroutine(ChangeColorCo());
    }

    // 색상 변경 간격 설정
    public void SetColorChangeInterval(float interval)
    {
        colorChangeInterval = Mathf.Max(0.1f, interval);
    }
}