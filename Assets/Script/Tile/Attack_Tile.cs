using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Tile : MonoBehaviour
{
    public int Dam;
    private SpriteRenderer mSpriteRenderer;
    private float Timer;

    private void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Timer += Time.deltaTime;
        mSpriteRenderer.color -= new Color(0, 0, 0, Time.deltaTime * 3);
        if(mSpriteRenderer.color.a <= 0)
        {
            Destroy(gameObject);
        }    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Skel_Enemy") && Timer <= 0.05f)
        {
            other.GetComponent<Enemy_Skel>().OnDam(Dam);
        }
    }
}
