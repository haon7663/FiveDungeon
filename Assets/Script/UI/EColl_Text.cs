using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EColl_Text : MonoBehaviour
{
    private GameObject mPlayer;
    private Player mPlayerScript;
    private TextMeshProUGUI mText;

    private void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        mPlayerScript = mPlayer.GetComponent<Player>();
        mText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        mText.text = mPlayerScript.Ecoll.ToString();
        if (mPlayerScript.Ecoll <= 0)
        {
            mText.text = "E";
            mText.color = new Color(0, 1, 1, 1);
        }
        else mText.color = new Color(1, 0, 0, 1);
    }
}
