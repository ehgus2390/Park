using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Rotate ������ 
//transform.Rotate(Vector3.up * Time.deltaTime * 50f);
//transform.rotation *= Quaternion.Euler(Time.deltaTime * 30.0f,0,0);

//[Rotate]
//����� ȸ���� ����
//���� ȸ�������� �Էµ� Vector3��ŭ �� ȸ��
//rotagion
//Quaternion.Euler(x,y,z)�� �̿��� Ư�� ������ ����
//���� ȸ���� �������� �ʰ� ������ ���

//[localRotation]
//rotation�� ���������� �θ� ������Ʈ�� ������ �޴� ���� ȸ������ ����
//�θ� ������Ʈ�� ȸ���ϸ� ������� ȸ������ ���� �ɼ� ����

//[LookAt]
//Ư�� Ÿ���� �ٶ�
//3D���� ���� �÷��̾ �ٶ� ��?

//[Quaternion.LookRotation]
//LookAt�̶� ���
//localRotation

//[RotateAround]
//Ư�� ��ġ�� �߽����� ������Ʈ ȸ��


    //[Header("Rotation Settings")]
    //public float rotationSpeed = 5f; // �¾��� ���� �ӵ�
    //public float orbitSpeed = 10f; // ���� �ӵ�
    //public float rotationSpeed = 20f; // ���� �ӵ�
    //public float orbitRadius = 5f; // ���� �ݰ�
    //public float planetSize = 1f; // �༺ ũ��
    //public float orbitTilt = 0f; // �˵� ����

    //private void Update()
    //{
    //    // �¾� ����
    //    transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    //}

 
public class PlanetOrbit : MonoBehaviour
{
    [Header("Earth Settings")]
    [Header("Mercury Settings")]
    [Header("Uranus Settings")]
    [Header("Pluto Settings")]
    [Header("Neptune Settings")]
    [Header("Saturn Settings")]
    [Header("Jupiter Settings")]
    public Transform sun; // �¾��� Transform
    public float orbitSpeed = 10f; // ���� �ӵ�
    public float rotationSpeed = 20f; // ���� �ӵ�
    public float orbitRadius = 5f; // ���� �ݰ�
    public float planetSize = 1f; // ������ ũ��
    public bool isJupiter = false;
    public bool isSaturn = false;
    public bool isNeptune = false;
    public bool isPluto = false;
    public bool isUranus = false;
    public bool isEarth = false;
    public bool isMercury = false;

    private void Start()
    {
        // �¾��� �������� ���� ��� �ڵ����� ã��
        if (sun == null)
        {
            sun = GameObject.FindGameObjectWithTag("Sun")?.transform;
        }

        // �༺�� �ʱ� ��ġ ����
        transform.position = sun.position + new Vector3(orbitRadius, 0, 0);

        // �༺�� ũ�� ����
        transform.localScale = Vector3.one * planetSize;

        if (isMercury)
        {
            orbitSpeed = 47.9f; // ������ ���� �ӵ� (km/s)
            rotationSpeed = 10.9f; // ������ ���� �ӵ� (��/�ð�)
            orbitRadius = 57.9f; // ������ ���� �ݰ� (�鸸 km)
            planetSize = 0.38f; // ������ ũ�� (���� ���)
        }
        if (isJupiter)
        {
            orbitSpeed = 11.86f;
            rotationSpeed = 9.9f;
            orbitRadius = 778.5f;
            planetSize = 0.38f;
        }
        if (isSaturn)
        {
            orbitSpeed = 29.46f;
            rotationSpeed = 10.7f;
            orbitRadius = 1433.5f;
            //planetSize = 0.38f;
        }
        if (isNeptune)
        {
            orbitSpeed = 47.9f;
            rotationSpeed = 10.9f;
            orbitRadius = 57.9f;
            //planetSize = 0.38f;
        }
        if (isPluto)
        {
            orbitSpeed = 60.9f;
            rotationSpeed = 10.9f;
            orbitRadius = 57.9f;
            //planetSize = 0.38f;
        }
        if (isUranus)
        {
            orbitSpeed = 25.9f;
            rotationSpeed = 10.9f;
            orbitRadius = 57.9f;
            //planetSize = 0.38f;
        }
        if (isEarth)
        {
            orbitSpeed = 41.9f;
            rotationSpeed = 10.9f;
            orbitRadius = 30.9f;
            //planetSize = 0.38f;
        }
    }

    private void Update()
    {
        if (sun != null)
        {
            // ���� (�¾� ������ ���� �)
            transform.RotateAround(sun.position, Vector3.up, orbitSpeed * Time.deltaTime);

            // ���� (�༺�� �������� �߽����� ȸ��)
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
