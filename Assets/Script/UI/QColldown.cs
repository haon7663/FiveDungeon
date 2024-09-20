using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QColldown : MonoBehaviour
{
    public Image q_Img;
    public Image mBlack;
    private GameObject mPlayer;


    private void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() 
    {
        q_Img.fillAmount = ((mPlayer.GetComponent<Player>().Qcolldown - mPlayer.GetComponent<Player>().Qcoll) / mPlayer.GetComponent<Player>().Qcolldown);
        if (mPlayer.GetComponent<Player>().Qcoll <= 0)
            mBlack.enabled = false;
        else
            mBlack.enabled = true;
    }
}
