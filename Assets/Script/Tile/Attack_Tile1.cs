using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Tile1 : MonoBehaviour
{
    public int Dam;
    private SpriteRenderer mSpriteRenderer;

    private void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        mSpriteRenderer.color -= new Color(0, 0, 0, Time.deltaTime * 3);
        if(mSpriteRenderer.color.a <= 0)
        {
            Destroy(gameObject);
        }    
    }
}
