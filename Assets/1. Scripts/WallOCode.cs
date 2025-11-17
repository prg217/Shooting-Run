using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOCode : MonoBehaviour
{
    public GameObject Effect; //º® ÆÄ±« ÀÌÆåÆ®
    public GameObject wall;
    public int hp;
    public int damage = 35;

    private float timeCheckHP;


    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
        timeCheckHP = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            GameObject spark = (GameObject)Instantiate(Effect, gameObject.transform.position, Quaternion.identity);
            SoundManager.Instance.PlayerSfxSound("Hit3");
            Destroy(gameObject);
        }

        TimeHP();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            hp--;
        }

        if (other.tag == "Player")
        {
            PlayerCode player = GameObject.Find("Player").GetComponent<PlayerCode>();
            player.PlayerDamaged(damage);
            Destroy(wall);
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
}
