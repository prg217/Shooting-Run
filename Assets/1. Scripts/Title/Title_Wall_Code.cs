using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Wall_Code : MonoBehaviour
{
    [SerializeField] public GameObject Effect; //총알 파괴 이펙트
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet") // Floor에 닿았을 경우 다시 점프가 가능하도록 설정
        {
            Debug.Log("닿았다");
            GameObject spark = (GameObject)Instantiate(Effect, gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
