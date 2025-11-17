using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Bullet_Code : MonoBehaviour
{
    //public TrailRenderer trailEf; // 궤적 이펙트

    [SerializeField] private Transform bulletPos; // 총을 발사하는 위치
    [SerializeField] private Transform wallPos; //총알이 발사되는 방향
    [SerializeField] private GameObject bullet; // 총알 프리팹
    [SerializeField] public GameObject Effect; //배경 꾸며주는 이펙트

    public float bulletSpeed; // 총알 속도
    public float bulletSpTime = 8.0f; // 총알 생성되는 시간

    Vector3 dir; //총알의 방향 벡터


    private void Awake()
    {
        bulletSpeed = 6.0f;
        wallPos = GameObject.FindGameObjectWithTag("Wall").transform;
    }

    private void Start()
    {
        StartCoroutine(Attack()); //무한반복 코루틴코드 실행하기
    }

    private IEnumerator Attack() //총알 발사를 무한반복하는 함수
    {
        dir = wallPos.position - bulletPos.position.normalized; //wallPos의 방향이 어디인지 계산
        GameObject fireBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation); // 총알 생성
        Rigidbody bulletRigid = fireBullet.GetComponent<Rigidbody>(); // 충돌을 위한 물리 판정
        bulletRigid.velocity = dir.normalized * bulletSpeed; // wallPos의 방향으로 총알이 얼만큼의 속도로 날라가는가

        yield return new WaitForSeconds(bulletSpTime); //무조건 한 번 실행

        StartCoroutine(Attack()); //재귀함수를 통해 무한반복을 설정한다
    }
}
