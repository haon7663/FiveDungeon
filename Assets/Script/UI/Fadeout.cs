using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadeout : MonoBehaviour
{
    private SpriteRenderer mSpriteRenderer;
    private void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mSpriteRenderer.color = new Color(0, 0, 0, 1);
    }
    private void Update()
    {
        mSpriteRenderer.color += new Color(0, 0, 0, -Time.deltaTime * 0.75f);
    }
}
