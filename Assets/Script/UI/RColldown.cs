using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RColldown : MonoBehaviour
{
    public Image r_Img;
    public Image mBlack;
    private GameObject mPlayer;

    private void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        r_Img.fillAmount = ((mPlayer.GetComponent<Player>().Rcolldown - mPlayer.GetComponent<Player>().Rcoll) / mPlayer.GetComponent<Player>().Rcolldown);
        if (mPlayer.GetComponent<Player>().Rcoll <= 0)
            mBlack.enabled = false;
        else
            mBlack.enabled = true;
    }
}
