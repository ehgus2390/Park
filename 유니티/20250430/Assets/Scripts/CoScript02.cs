using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoScript02 : MonoBehaviour
{

    private float m_bounceHeight = 2.0f;
    private float m_bounceDuration = 1.0f;
    private Vector3 m_startPosition;
    private Vector3 m_targetPosition;
    private float elapsedTime = 0.0f;
    private bool m_isMoving = true;
    // Start is called before the first frame update

    void Start()
    {
        //m_startPosition = transform.position;
        //m_targetPosition = transform.position;
        StartCoroutine(BounceCubeCo());
    }

    IEnumerator BounceCubeCo()
    {
        Vector3 startPosition = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObjectCo(transform, m_startPosition, m_targetPosition, m_bounceDuration));

            yield return StartCoroutine(MoveObjectCo(transform, m_targetPosition, m_startPosition, m_bounceDuration));
        }
    }

    IEnumerator MoveObjectCo(Transform obj, Vector3 start, Vector3 end, float duration)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime<duration)
        {
            obj.position = Vector3.Lerp(start, end, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obj.position = end; //최종위치 보정
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = Time.deltaTime;
        if (m_isMoving)
        {
            transform.position = Vector3.Lerp(m_startPosition, m_targetPosition, elapsedTime / m_bounceDuration);
        }
        else
        {
            transform.position = Vector3.Lerp(m_targetPosition, m_startPosition, elapsedTime / m_bounceDuration);
        }
        if (elapsedTime >= m_bounceDuration)
        {
            elapsedTime = 0.0f;
            m_isMoving = !m_isMoving;
        }
    }
}
