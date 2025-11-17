using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniPlayerCube : MonoBehaviour
{
    public int hp = 100;
    [SerializeField] private Text playerHpTxt;

    public GameObject Effect; //충돌시 이펙트

    static public int countTime = 0;
    //private Renderer renderer;
    public Material[] material;

    private bool active; //플레이어 살아있는지 체크

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        //renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1) * 90 * Time.deltaTime);

        playerHpTxt.text = " " + hp.ToString();

        if (hp <= 0 && active == true)
        {
            active = false;
            MiniGameManager.GameOver();
        }
    }

    private IEnumerator Invincibility()
    {
        while (countTime != 0)
        {
            if (countTime % 2 == 0)
            {
                GetComponent<Renderer>().material = material[0];
                //renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 10);
            }
            else
            {
                GetComponent<Renderer>().material = material[1];
                //renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 255);
            }

            yield return new WaitForSeconds(0.2f);
            countTime--;
        }

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MiniBulletL" && countTime == 0)
        {
            GameObject spark = (GameObject)Instantiate(Effect, gameObject.transform.position + new Vector3(-1, 0, -3), Quaternion.identity);
            hp -= 10;
            SoundManager.Instance.PlayerSfxSound("Hit1");
            countTime = 10;
            StartCoroutine("Invincibility");
        }
        if (other.tag == "MiniBulletR" && countTime == 0)
        {
            GameObject spark = (GameObject)Instantiate(Effect, gameObject.transform.position + new Vector3(1, 0, -3), Quaternion.identity);
            hp -= 10;
            countTime = 10;
            StartCoroutine("Invincibility");
            SoundManager.Instance.PlayerSfxSound("Hit1");
        }

        if (other.tag == "MiniBulletL" && countTime == 0)
        {
            GameObject spark = (GameObject)Instantiate(Effect, gameObject.transform.position + new Vector3(-1, 0, -3), Quaternion.identity);
            Destroy(other.gameObject);
            hp -= 10;
            SoundManager.Instance.PlayerSfxSound("Hit1");
            countTime = 10;
            StartCoroutine("Invincibility");
        }

        if (other.tag == "MiniBulletR" && countTime == 0)
        {
            GameObject spark = (GameObject)Instantiate(Effect, gameObject.transform.position + new Vector3(1, 0, -3), Quaternion.identity);
            Destroy(other.gameObject);
            hp -= 10;
            countTime = 10;
            StartCoroutine("Invincibility");
            SoundManager.Instance.PlayerSfxSound("Hit1");
        }
    }
}