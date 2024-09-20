using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private SpriteRenderer mSpriteRenderer;

    private void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (GameManager.PlayerShield > 0)
        {
            mSpriteRenderer.enabled = true;
        }
        else
            mSpriteRenderer.enabled = false;
    }
}
