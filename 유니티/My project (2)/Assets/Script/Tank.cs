using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Rotate 짐벌낙 
//transform.Rotate(Vector3.up * Time.deltaTime * 50f);
//transform.rotation *= Quaternion.Euler(Time.deltaTime * 30.0f,0,0);

//[Rotate]
//상대적 회적을 설정
//현재 회전값에서 입력된 Vector3만큼 더 회전
//rotagion
//Quaternion.Euler(x,y,z)를 이용해 특정 각도로 설정
//기존 회전을 유지하지 않고 덮어씌우는 방식

//[localRotation]
//rotation과 유사하지만 부모 오브젝트의 영향을 받는 로컬 회전값을 설정
//부모 오브젝트가 회전하면 상대적인 회전값이 변경 될수 있음

//[LookAt]
//특정 타겟을 바라봄
//3D에서 적이 플레이어를 바라볼 때?

//[Quaternion.LookRotation]
//LookAt이랑 비슷
//localRotation

//[RotateAround]
//특정 위치를 중심으로 오브젝트 회전


    //[Header("Rotation Settings")]
    //public float rotationSpeed = 5f; // 태양의 자전 속도
    //public float orbitSpeed = 10f; // 공전 속도
    //public float rotationSpeed = 20f; // 자전 속도
    //public float orbitRadius = 5f; // 공전 반경
    //public float planetSize = 1f; // 행성 크기
    //public float orbitTilt = 0f; // 궤도 기울기

    //private void Update()
    //{
    //    // 태양 자전
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
    public Transform sun; // 태양의 Transform
    public float orbitSpeed = 10f; // 공전 속도
    public float rotationSpeed = 20f; // 자전 속도
    public float orbitRadius = 5f; // 공전 반경
    public float planetSize = 1f; // 지구의 크기
    public bool isJupiter = false;
    public bool isSaturn = false;
    public bool isNeptune = false;
    public bool isPluto = false;
    public bool isUranus = false;
    public bool isEarth = false;
    public bool isMercury = false;

    private void Start()
    {
        // 태양이 지정되지 않은 경우 자동으로 찾기
        if (sun == null)
        {
            sun = GameObject.FindGameObjectWithTag("Sun")?.transform;
        }

        // 행성의 초기 위치 설정
        transform.position = sun.position + new Vector3(orbitRadius, 0, 0);

        // 행성의 크기 설정
        transform.localScale = Vector3.one * planetSize;

        if (isMercury)
        {
            orbitSpeed = 47.9f; // 수성의 공전 속도 (km/s)
            rotationSpeed = 10.9f; // 수성의 자전 속도 (도/시간)
            orbitRadius = 57.9f; // 수성의 공전 반경 (백만 km)
            planetSize = 0.38f; // 수성의 크기 (지구 대비)
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
            // 공전 (태양 주위를 도는 운동)
            transform.RotateAround(sun.position, Vector3.up, orbitSpeed * Time.deltaTime);

            // 자전 (행성의 자전축을 중심으로 회전)
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
