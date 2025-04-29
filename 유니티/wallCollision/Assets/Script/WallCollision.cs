using UnityEngine;

public class ChangeColorOnCollision : MonoBehaviour
{
    public Color targetColor = Color.red; // �浹 �� ������ ���� (�ν����Ϳ��� ���� ����)
    private Renderer cubeRenderer;

    void Start()
    {
        // �� ��ũ��Ʈ�� ����� ������Ʈ�� Renderer ������Ʈ�� �����ɴϴ�.
        cubeRenderer = GetComponent<Renderer>();

        // Renderer ������Ʈ�� ������ ���� �޽����� ����ϰ� ��ũ��Ʈ�� �����մϴ�.
        if (cubeRenderer == null)
        {
            Debug.LogError("Renderer component not found on this GameObject!");
            enabled = false;
        }
    }

    // �ٸ� �ݶ��̴��� �浹���� �� ȣ��Ǵ� �Լ�
    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� �±װ� "Sphere"���� Ȯ���մϴ�.
        if (collision.gameObject.CompareTag("Sphere"))
        {
            // ť���� ��Ƽ���� ������ targetColor�� �����մϴ�.
            cubeRenderer.material.color = targetColor;
        }
    }

    //�浹�� ������ ��(���� ����)
     void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            // �浹�� ������ �� ���� �������� �ǵ����ų� �ٸ� ������ ������ �� �ֽ��ϴ�.
            cubeRenderer.material.color = Color.white; // ����: ������� �ǵ�����
        }
    }
}
