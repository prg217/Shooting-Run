using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    public Material[] material;

    public void OnClickBlueButton()
    {
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        material[0].color = new Color(71 / 255f, 170 / 255f, 255 / 255f, 255 / 255f);
        material[1].color = new Color(71 / 255f, 170 / 255f, 255 / 255f, 180 / 255f);
    }

    public void OnClickGreenButton()
    {
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        material[0].color = new Color(110 / 255f, 219 / 255f, 144 / 255f, 255 / 255f);
        material[1].color = new Color(110 / 255f, 219 / 255f, 144 / 255f, 180 / 255f);
    }

    public void OnClickRedButton()
    {
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        material[0].color = new Color(209 / 255f, 104 / 255f, 108 / 255f, 255 / 255f);
        material[1].color = new Color(209 / 255f, 104 / 255f, 108 / 255f, 180 / 255f);
    }

    public void OnClickPurpleButton()
    {
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        material[0].color = new Color(142 / 255f, 107 / 255f, 185 / 255f, 255 / 255f);
        material[1].color = new Color(142 / 255f, 107 / 255f, 185 / 255f, 180 / 255f);
    }

    public void OnClickYellowButton()
    {
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        material[0].color = new Color(221 / 255f, 218 / 255f, 110 / 255f, 255 / 255f);
        material[1].color = new Color(221 / 255f, 218 / 255f, 110 / 255f, 180 / 255f);
    }

    public void OnClickBlackButton()
    {
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        material[0].color = new Color(27 / 255f, 27 / 255f, 27 / 255f, 255 / 255f);
        material[1].color = new Color(27 / 255f, 27 / 255f, 27 / 255f, 180 / 255f);
    }

    public void OnClickWhiteButton()
    {
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        material[0].color = new Color(225 / 255f, 225 / 255f, 225 / 255f, 255 / 255f);
        material[1].color = new Color(225 / 255f, 225 / 255f, 225 / 255f, 180 / 255f);
    }

    public void OnClickOrangeButton()
    {
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        material[0].color = new Color(225 / 255f, 154 / 255f, 83 / 255f, 255 / 255f);
        material[1].color = new Color(225 / 255f, 154 / 255f, 83 / 255f, 180 / 255f);
    }

    public void OnClickPinkButton()
    {
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        material[0].color = new Color(226 / 255f, 142 / 255f, 196 / 255f, 255 / 255f);
        material[1].color = new Color(226 / 255f, 142 / 255f, 196 / 255f, 180 / 255f);
    }
}
