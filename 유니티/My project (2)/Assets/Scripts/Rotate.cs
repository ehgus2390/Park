
using UnityEngine;
//1.Rotate
//transform.Rotate(Vector3.up * Time.deltaTime * 50f);

//2.���ʹϾ� ȸ��
// transform.rotation *= Quaternion.Euler(Time.deltaTime * 30.0f, 0, 0);

//[Rotate]
//����� ȸ���� �����Ҷ�
//���� ȸ�������� �Էµ� Vector3��ŭ �� ȸ��(����)

//[roration]
//Quaternion.Euler(x,y,z)�� ����� Ư�� ������ ���� ����
//���� ȸ���� �������� �ʰ� ������ ���

//[localRotation]
//roration�� ���������� �θ� ������Ʈ�� ������ �޴� ���� ȸ������ ����
//�θ� ������Ʈ�� ȸ���ϸ� ������� ȸ������ ���� �ɼ� ����

//[LookAt]
//Ư�� Ÿ���� �ٶ�
//3D���� ���� �÷��̾ �ٶ󺼶�?

//[Quaternion.LookRotation]
//LookAt�̶� ���
//Quaternion.LookRotation(Vector3.forward, Vector3.up)�������� up���͸� ���� ����

//[RotateAround]
//Ư�� ��ġ�� �߽����� ������Ʈ ȸ��
//ī�޶� Ư�� ������Ʈ�� ���� ����, �����˵� ȸ�� � Ȱ��
public class Rotate : MonoBehaviour
{

    public Transform target;
    void Update()
    {
        //transform.LookAt(target);

        //Vector3 dir = target.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(dir,Vector3.up);

        //����
        transform.RotateAround(target.position,Vector3.up,30.0f* Time.deltaTime);

        transform.Rotate(Vector3.up, 30.0f * Time.deltaTime);

    }
}
