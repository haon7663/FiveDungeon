using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unsprite : MonoBehaviour
{
    private SpriteRenderer mSpriteRenderer;

    private void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        if (transform.position.x >= 6.9f || transform.position.x <= -6.9f || transform.position.y >= 6.9f || transform.position.y <= -6.9f)
        {
            mSpriteRenderer.enabled = false;
            enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if(GameManager.HaveTurn)
            mSpriteRenderer.enabled = true;
        else
            mSpriteRenderer.enabled = false;
    }
}
