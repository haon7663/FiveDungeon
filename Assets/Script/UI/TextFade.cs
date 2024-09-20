using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFade : MonoBehaviour
{
    public TextMeshProUGUI mText;
    private void Start()
    {
        mText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        mText.color += new Color(0, 0, 0, Time.deltaTime * 0.3f);
    }
}
