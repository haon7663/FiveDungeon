using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone_Att : MonoBehaviour
{
    private Rigidbody2D mRigidbody2D;
    private SpriteRenderer mSpriteRenderer;
    private BoxCollider2D mBoxCollider2D;
    private ParticleSystem mParticleSystem;

    private void Start()
    {
        mRigidbody2D = GetComponent<Rigidbody2D>();
        mSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        mBoxCollider2D = GetComponent<BoxCollider2D>();
        mParticleSystem = GetComponentInChildren<ParticleSystem>();
        mRigidbody2D.AddForce(transform.right * 10f, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (GameManager.PlayerShield > 0)
                GameManager.PlayerShield -= 1;
            else
            {
                GameManager.Gm.ShakeAllcam(0.15f, 0.25f);
                GameManager.PlayerHP -= 1;
                collision.GetComponent<Player>().RedDam = 0.2f;
                collision.GetComponent<Player>().OnDam();
            }
            Invoke("DillDestroy", 0.1f);
        }
    }
    private void DillDestroy()
    {
        mSpriteRenderer.enabled = false;
        mBoxCollider2D.enabled = false;
        mParticleSystem.Stop();
        Invoke("DDes", 0.7f);
    }
    private void DDes()
    {
        Destroy(gameObject);
    }
}
