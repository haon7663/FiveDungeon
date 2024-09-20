using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnText : MonoBehaviour
{
    public TextMeshProUGUI mText;
    private void Start()
    {
        mText = GetComponent<TextMeshProUGUI>();
    }
    private void FixedUpdate()
    {
        mText.text = GameManager.Turn.ToString();
    }
}
