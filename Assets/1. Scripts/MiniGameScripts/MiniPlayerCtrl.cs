using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlayerCtrl : MonoBehaviour
{
    private float h = 0.0f; // 좌우 좌표
    private float moveSpeed = 5.0f; // 이동 속도
    private float jumpforce = 15.0f; // 점프 정도

    bool isJump; // 점프 확인 유무 변수
    bool jumpDown; // Space 입력

    public Transform tr; // 위치
    public Rigidbody rigid; // 물리

    // Update is called once per frame
    void Update()
    {
        tr.eulerAngles = new Vector3(tr.rotation.x, tr.rotation.y, 0f); //물리적인 충돌에 회전되지 않게
        tr.position = new Vector3(tr.position.x, tr.position.y, 0f); //끼임 방지

        // 조작 입력
        h = Input.GetAxis("Horizontal"); // 좌우 이동
        jumpDown = Input.GetButtonDown("Jump"); //점프(Input Manager - Jump에 Space 할당(유니티 기본 설정))

        // 입력 받은 키에 따른 좌우 이동
        Vector3 moveDir = (Vector3.right * h);
        tr.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);

        // 입력에 따른 점프
        if (jumpDown && !isJump) // Space 입력 && Floor에 Player가 닿아 있을 때
        {
            rigid.AddForce(Vector3.up * jumpforce, ForceMode.Impulse); // Space 입력 시 점프
            isJump = true; // 점프 중임을 나타내기 위한 ture값으로의 변경
            SoundManager.Instance.PlayerSfxSound("Jump_P");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") // Floor에 닿았을 경우 다시 점프가 가능하도록 설정
        {
            isJump = false; // 다시 점프할 수 있도록 변수값 변경
        }
    }
}
