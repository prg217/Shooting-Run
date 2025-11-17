using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    public GameObject sparkEffect; // 벽에 충돌 시 이펙트
    private RaycastHit hitRay;

    private Transform bulletTr;
    // Start is called before the first frame update
    void Start()
    {
        bulletTr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            GameObject spark = (GameObject)Instantiate(sparkEffect, bulletTr.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
