using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerR : MonoBehaviour
{
    public GameObject danger;

    // Start is called before the first frame update
    void Start()
    {
        danger.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MiniBulletR")
        {
            danger.SetActive(true);
            SoundManager.Instance.PlayerSfxSound("Die_M1");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MiniBulletR")
        {
            danger.SetActive(false);
        }
    }
}
