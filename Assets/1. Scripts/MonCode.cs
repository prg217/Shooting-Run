using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonCode : MonoBehaviour
{
    public int hp;
    public int damage;
    public float speed;
    public int score;

    private float timeCheckDMG;
    private float timeCheckHP;

    private float timeCheckAttack;
    private float randomTime;

    public GameObject bulletPrefab;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
        damage = 5;
        speed = Random.Range(2.0f, 4.0f);
        score = 10;

        timeCheckDMG = 0.0f;
        timeCheckHP = 0.0f;

        timeCheckAttack = 0.0f;
        randomTime = Random.Range(3.0f, 5.0f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.CheckActive() == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            TimeDamage();
            TimeHP();
            spawnAttack();
        }
    }

    void TimeDamage()
    {
        if (timeCheckDMG < 30.0f)
            timeCheckDMG += Time.deltaTime;
        else
        {
            timeCheckDMG = 0.0f;
            damage += 2;
        }
    }

    void TimeHP()
    {
        if (timeCheckHP < 45.0f)
            timeCheckHP += Time.deltaTime;
        else
        {
            timeCheckHP = 0.0f;
            hp += 1;
        }
    }

    public GameObject spawnAttack()
    {
        if (this.transform.position.z > player.transform.position.z + 5)
        {
            if (timeCheckAttack < randomTime)
            {
                timeCheckAttack += Time.deltaTime;
            }
            else
            {
                timeCheckAttack = 0.0f;

                if (bulletPrefab != null)
                {
                    Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                }
            }
        }
        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroy") // ³¡¿¡¼­ ÆÄ±«
        {
            Destroy(gameObject);
        }

        else if (other.tag == "Bullet") // ÃÑ¾Ë¿¡ ´ê¾ÒÀ» ¶§
        {
            hp -= 1;

            if (hp <= 0)
            {
                GameManager.GetScore(score);
                SoundManager.Instance.PlayerSfxSound("GetScore");
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerCode player = GameObject.Find("Player").GetComponent<PlayerCode>();
            player.PlayerDamaged(damage);
            Destroy(gameObject);
        }
    }
}