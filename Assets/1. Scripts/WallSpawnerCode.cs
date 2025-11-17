using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnerCode : MonoBehaviour
{
    public GameObject[] prefabToSpawn; // 스폰될 물체
    public float repeatInterval = 5; // 몇 초마다 스폰인지
    public int random = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (repeatInterval > 0)
        {
            InvokeRepeating("SpawnObject", 0.0f, repeatInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.CheckActive() == false) // 플레이어 사망 시 파괴
        {
            Destroy(gameObject);
        }
    }

    public GameObject SpawnObject()
    {
        if (prefabToSpawn != null)
        {
            return Instantiate(prefabToSpawn[random = Random.Range(0, 10)], transform.position, Quaternion.LookRotation(Vector3.back));
        }

        return null;
    }
}