using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonSpCode : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // 몬스터 목록
    private BoxCollider area; // 몬스터 생성 범위
    public float spawnTime; // 생성 쿨타임
    public int spawnNum; // 생성 개수

    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider>(); // 생성 범위 지정
        spawnTime = 5.0f; // 5초 (임시로 벽이랑 동일하게)
        spawnNum = Random.Range(2, 3); // 처음에는 둘 또는 셋만 스폰

        InvokeRepeating("spawnMonster", 0.0f, spawnTime); // 몬스터 스폰 계속 반복
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.CheckActive() == false) // 플레이어가 죽을 경우
        {
            Destroy(gameObject); // 스폰 오브젝트 삭제
        }
    }

    public GameObject spawnMonster()
    {
        if (monsterPrefabs != null)
        {
            for (int i = 0; i < spawnNum; i++)
            {
                Vector3 spawnPos = randomPosition();

                Instantiate(monsterPrefabs[Random.Range(0, 4)], spawnPos, Quaternion.LookRotation(Vector3.back));
            }
        }
        spawnNum = Random.Range(2, 5);

        return null;
    }

    public Vector3 randomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }
}
