using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTime : MonoBehaviour
{
    public Text timeTxt;

    // Update is called once per frame
    void Update()
    {
        timeTxt.text = "TIME <color=#00ffff>" + MiniTime.time.ToString("0000") + "</color>";
    }
}
