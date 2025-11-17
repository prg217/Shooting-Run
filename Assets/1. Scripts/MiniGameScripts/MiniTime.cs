using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniTime : MonoBehaviour
{
    public Text timeTxt;
    static public float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = "TIME <color=#00ffff>" + time.ToString("0000") + "</color>";
    }
}
