using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallXCode : MonoBehaviour
{
    public GameObject wall;
    public int damage = 35;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerCode player = GameObject.Find("Player").GetComponent<PlayerCode>();
            player.PlayerDamaged(damage);
            Destroy(wall);
        }
    }
}
