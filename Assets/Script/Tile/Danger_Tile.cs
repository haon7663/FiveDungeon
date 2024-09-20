using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger_Tile : MonoBehaviour
{
    private SpriteRenderer mSpriteRenderer;
    private bool isAphdown = false;

    private void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(isAphdown)
            mSpriteRenderer.color -= new Color(0, 0, 0, Time.deltaTime * 2);
    }
    public void DangerTile()
    {
        Invoke("Destroytime", 0.5f);
        isAphdown = true;
    }
    private void Destroytime()
    {
        Destroy(gameObject);
    }
}
