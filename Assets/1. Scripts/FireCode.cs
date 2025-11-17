using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCode : MonoBehaviour
{
    public TrailRenderer trailEf; // 궤적 이펙트
    public Transform bulletPos; // 총을 발사하는 위치
    public GameObject bullet; // 총알 프리팹
    public float bulletSpeed; // 총알 속도

    void Start()
    {
        bulletSpeed = 50.0f;
    }

    void Update()
    {
        if (GameManager.CheckActive() == true && PauseCode.isPause == false)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 입력 시 공격
        {
            GameObject fireBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation); // 총알 생성
            Rigidbody bulletRigid = fireBullet.GetComponent<Rigidbody>(); // 충돌을 위한 물리 판정
            bulletRigid.velocity = bulletPos.forward * bulletSpeed; // 총알의 속도
        }
    }
}
