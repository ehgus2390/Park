using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    [SerializeField]private GameObject m_bulletPrefab;
    [SerializeField] private Transform target;

    private float spawnRateMin = 0.5f;
    private float spawnRateMax = 3.0f;

    //현재 스폰 간격
    private float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        if (target==null)
        {
            target = FindObjectOfType<PlayerControlor>()?.transform;

            if (target==null)
            {
                return;
            }
        }
        StartCoroutine(SpawnBulletCo());
    }

    IEnumerator SpawnBulletCo()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            if (target!=null)
            {
                GameObject bullet = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity);
                bullet.transform.LookAt(target);
            }
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
