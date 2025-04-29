
using UnityEngine;
//1.Rotate
//transform.Rotate(Vector3.up * Time.deltaTime * 50f);

//2.쿼터니언 회전
// transform.rotation *= Quaternion.Euler(Time.deltaTime * 30.0f, 0, 0);

//[Rotate]
//상대적 회전을 설정할때
//현재 회전값에서 입력된 Vector3만큼 더 회전(누적)

//[roration]
//Quaternion.Euler(x,y,z)를 사용해 특정 각도로 직접 설정
//기존 회전을 유지하지 않고 덮어씌우는 방식

//[localRotation]
//roration과 유사하지만 부모 오브젝트의 영향을 받는 로컬 회전값을 설정
//부모 오브젝트가 회전하면 상대적인 회전값이 변경 될수 있음

//[LookAt]
//특정 타겟을 바라봄
//3D에서 적이 플레이어를 바라볼때?

//[Quaternion.LookRotation]
//LookAt이랑 비슷
//Quaternion.LookRotation(Vector3.forward, Vector3.up)형식으로 up벡터를 지정 가능

//[RotateAround]
//특정 위치를 중심으로 오브젝트 회전
//카메라가 특정 오브젝트를 도는 연출, 위성궤도 회전 등에 활용
public class Rotate : MonoBehaviour
{

    public Transform target;
    void Update()
    {
        //transform.LookAt(target);

        //Vector3 dir = target.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(dir,Vector3.up);

        //공전
        transform.RotateAround(target.position,Vector3.up,30.0f* Time.deltaTime);

        transform.Rotate(Vector3.up, 30.0f * Time.deltaTime);

    }
}
