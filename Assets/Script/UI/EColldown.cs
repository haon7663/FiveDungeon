using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EColldown : MonoBehaviour
{
    public Image e_Img;
    public Image mBlack;
    private GameObject mPlayer;

    private void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        e_Img.fillAmount = ((mPlayer.GetComponent<Player>().Ecolldown - mPlayer.GetComponent<Player>().Ecoll) / mPlayer.GetComponent<Player>().Ecolldown);
        if (mPlayer.GetComponent<Player>().Ecoll <= 0)
            mBlack.enabled = false;
        else
            mBlack.enabled = true;
    }
}
