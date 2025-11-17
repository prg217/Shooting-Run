using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerL : MonoBehaviour
{
    //범위 내에 총알이 들어오면 경고 띄우고 범위 벗어나면 경고 해제
    //오른쪽에서 오는 녀석과 왼쪽에서 오는 녀석을 구분할 것
    //태그 구분으로?

    public GameObject danger;

    // Start is called before the first frame update
    void Start()
    {
        danger.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MiniBulletL")
        {
            danger.SetActive(true);
            SoundManager.Instance.PlayerSfxSound("Die_M1");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MiniBulletL")
        {
            danger.SetActive(false);
        }
    }
}
