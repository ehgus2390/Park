using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoScripts01 : MonoBehaviour
{
    private Renderer m_cubeRenderer;
    public float colorChangeInterval = 1.0f; // ���� ���� ���� (��)
    private bool isChangingColor = true; // ���� ���� Ȱ��ȭ ����

    void Start()
    {
        // ���� ���� ������Ʈ�� Renderer ������Ʈ ��������
        m_cubeRenderer = GetComponent<Renderer>();

        // ������Ʈ�� �����ϴ��� Ȯ��
        if (m_cubeRenderer != null)
        {
            // �ڷ�ƾ ����
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
            // ���� ���� ����
            Color newColor = new Color(Random.value, Random.value, Random.value);

            // ���� ���󿡼� ���ο� �������� �ε巴�� ��ȯ
            Color currentColor = m_cubeRenderer.material.color;
            float elapsedTime = 0f;

            while (elapsedTime < colorChangeInterval)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / colorChangeInterval;
                m_cubeRenderer.material.color = Color.Lerp(currentColor, newColor, t);
                yield return null;
            }

            // ��Ȯ�� ���� ����
            m_cubeRenderer.material.color = newColor;

            // ���� ���� ���� ������ ���
            yield return new WaitForSeconds(0.1f);
        }
    }

    // ���� ���� ����
    public void StartColorChange()
    {
        if (!isChangingColor)
        {
            isChangingColor = true;
            StartCoroutine(ChangeColorCo());
        }
    }

    // ���� ���� ����
    public void StopColorChange()
    {
        isChangingColor = false;
        StopCoroutine(ChangeColorCo());
    }

    // ���� ���� ���� ����
    public void SetColorChangeInterval(float interval)
    {
        colorChangeInterval = Mathf.Max(0.1f, interval);
    }
}