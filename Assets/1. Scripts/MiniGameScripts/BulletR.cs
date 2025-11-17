using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletR : MonoBehaviour
{
    private float moveSpeed = 8.0f; // 이동 속도
    public Transform tr; // 위치

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = (Vector3.left);
        tr.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
