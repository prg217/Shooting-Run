using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCode : MonoBehaviour
{
    public int hp = 100; // 체력

    private float h = 0.0f; // 좌우 좌표
    private float moveSpeed = 10.0f; // 이동 속도
    private float jumpforce = 12.0f; // 점프 정도

    private bool isJump; // 점프 확인 유무 변수
    private bool jumpDown; // Space 입력

    private bool isWall_L; //벽 관통감지
    private bool isWall_R; //벽 관통감지

    private Transform tr; // 위치
    private Animator anim; // 애니메이션
    private Rigidbody rigid; // 물리

    Vector3 moveDir;

    [SerializeField] private Text playerHpTxt;

    public Material[] material;
    private int countTime = 0; //데미지 입을 시 무적시간 동안 깜빡이는거... 체크용
    public GameObject[] playerBody; //마테리얼을 적용할 플레이어 바디

    private void Awake() //초기화함수
    {
        tr = GetComponent<Transform>(); // 위치
        anim = GetComponentInChildren<Animator>(); // 애니메이션
        rigid = GetComponent<Rigidbody>(); // 물리
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.CheckActive() == true)
        {
            // 조작 입력
            h = Input.GetAxis("Horizontal"); // 좌우 이동
            jumpDown = Input.GetButtonDown("Jump"); //점프(Input Manager - Jump에 Space 할당(유니티 기본 설정))

            // 입력 받은 키에 따른 좌우 이동
            moveDir = (Vector3.right * h);

            //벽 물리충돌
            if(!isWall_L && !isWall_R)
            {
                tr.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);
            }

            //둘 중 하나가 닿았으면 반대버튼을 눌러야지만 false로 만든다


            // 입력에 따른 점프
            if (jumpDown && !isJump) // Space 입력 && Floor에 Player가 닿아 있을 때
            {
                rigid.AddForce(Vector3.up * jumpforce, ForceMode.Impulse); // Space 입력 시 점프
                anim.SetTrigger("DoJump"); // Space 입력 시 점프 모션이 나오는 애니메이션용 트리거
                anim.SetBool("IsJump", true); // DoJump 트리거가 발동 시 점프 애니메이션을 나오게 하기 위한 변경
                isJump = true; // 점프 중임을 나타내기 위한 ture값으로의 변경

                SoundManager.Instance.PlayerSfxSound("Jump_P");

                if (GameManager.CheckActive() == true)
                {
                    anim.SetBool("IsDie", true);
                    anim.SetBool("IsJump", false);
                }
            }

            if (Input.GetMouseButtonDown(0) && PauseCode.isPause == false) // 마우스 왼쪽 버튼 입력 시
            {
                anim.SetTrigger("DoShot"); // 총 쏘는 애니메이션 재생용 트리거
                SoundManager.Instance.PlayerSfxSound("Shot_P");
            }

            anim.SetBool("IsDie", false);
        }

        PlayerHp(hp);//플레이어의 hp 표시
    }

    public void PlayerDamaged(int damage)
    {

        if (GameManager.CheckActive() == true && countTime == 0) //죽었어도 체력이 계속 깎이는 것을 방지한다 + 무적 시간 동안 데미지 안입게
        {
            hp -= damage;
            SoundManager.Instance.PlayerSfxSound("Hit1");

            if (hp <= 0)
            {
                anim.SetBool("IsDie", true);
                PlayerDie();
            }
            else
            {
                countTime = 10;
                StartCoroutine("Invincibility");
            }
        }
    }

    public void PlayerDie() //플레이어가 죽으면
    {
        hp = 0; // hp는 0 이하일 경우 0으로 유지
       
        GameManager.GameOver();

        Debug.Log("Game Over");

        ScoreManager.chack = true; //스코어 기록하도록
    }
    private void PlayerHp(int hp)
    {
        playerHpTxt.text = " " + hp.ToString();
    }

    private void StopWall() //벽 통과하지 않게 Raycast로 벽 감지하기
    {
        Debug.DrawRay(transform.position, new Vector3(1,0,0) * 1, Color.red); //확인하는 광선설정 (시작위치, 광선 길이, 광선 색깔)
        Debug.DrawRay(transform.position, new Vector3(-1,0,0) * 1, Color.red); //확인하는 광선설정 (시작위치, 광선 길이, 광선 색깔)

        isWall_L = Physics.Raycast(transform.position, moveDir, 0.8f, LayerMask.GetMask("Wall")); //레이캐스트를 통해 벽을 감지하면 true값으로 변환
        isWall_R = Physics.Raycast(transform.position, moveDir, 0.8f, LayerMask.GetMask("Wall"));
    }

    private void FixedUpdate() //일정한 간격으로 호출되어 물리충돌 일어날때 쓰는 함수
    {
        StopWall();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") // Floor에 닿았을 경우 다시 점프가 가능하도록 설정
        {
            anim.SetBool("IsJump", false); // 점프 애니메이션 종료
            isJump = false; // 다시 점프할 수 있도록 변수값 변경
        }

    }

    private IEnumerator Invincibility() //무적
    {
        while (countTime != 0)
        {
            if (countTime % 2 == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    playerBody[i].GetComponent<Renderer>().material = material[0];
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    playerBody[i].GetComponent<Renderer>().material = material[1];
                }
            }

            yield return new WaitForSeconds(0.3f);
            countTime--;
        }

        yield return null;
    }
}