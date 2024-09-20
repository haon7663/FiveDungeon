using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private SpriteRenderer mSpriteRenderer;
    private void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        mSpriteRenderer.color += new Color(0, 0, 0, Time.deltaTime * 0.2f);
    }
}
