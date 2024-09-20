using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Text : MonoBehaviour
{
    private Text mText;

    private void Start()
    {
        mText = GetComponent<Text>();
        mText.text = "Score: " + GameManager.Gm.Score.ToString();
    }
}
