using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonBulletCode : MonoBehaviour
{
    public int damage; // ÃÑ¾Ë µ¥¹ÌÁö
    public float speed;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        damage = 5;
        speed = 3.0f;

        player = GameObject.FindGameObjectWithTag("Target").transform;
        this.transform.LookAt(player);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.CheckActive() == true)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        if (this.transform.position.z < player.transform.position.z - 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroy")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            PlayerCode player = GameObject.Find("Player").GetComponent<PlayerCode>();
            player.PlayerDamaged(damage);
            Destroy(gameObject);
        }
    }
}
