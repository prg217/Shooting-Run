using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefabToSpawn; // 스폰될 물체
    public GameObject SpawnBullet; //스포너
    private float RandomY = 0;
    private float timer = 5;

    void Update()
    {
        RandomY = UnityEngine.Random.Range(25f, 0f);

        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            SpawnBullet = Instantiate(prefabToSpawn, transform.position + new Vector3(0, RandomY, 0), Quaternion.identity);
            timer = UnityEngine.Random.Range(4f, 1.5f);
        }
    }
}
