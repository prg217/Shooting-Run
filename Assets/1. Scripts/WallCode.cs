using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCode : MonoBehaviour
{
    public float speed = 3.0f;
    public int score = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.CheckActive() == true)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroy")
        {
            GameManager.GetScore(score);
            SoundManager.Instance.PlayerSfxSound("GetScore");
            Destroy(gameObject);
        }
    }
}
