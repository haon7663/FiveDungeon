using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Pa : MonoBehaviour
{
    [SerializeField] private GameObject mAttack_Tile;
    [SerializeField] private float mSpeed;

    private Rigidbody2D mRigidbody2D;
    private SpriteRenderer mSpriteRenderer;
    private BoxCollider2D mBoxCollider2D;

    private GameObject mPlayer;
    private void Start()
    {
        mRigidbody2D = GetComponent<Rigidbody2D>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mBoxCollider2D = GetComponent<BoxCollider2D>();
        mPlayer = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        if(mSpriteRenderer.enabled)
            transform.position += transform.right * Time.deltaTime * mSpeed;
    }
    public void Pa()
    {
        if (mPlayer.GetComponent<Player>().Rota == 0)
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (mPlayer.GetComponent<Player>().Rota == 1)
            this.transform.rotation = Quaternion.Euler(0, 0, 180);
        if (mPlayer.GetComponent<Player>().Rota == 2)
            this.transform.rotation = Quaternion.Euler(0, 0, 90);
        if (mPlayer.GetComponent<Player>().Rota == 3)
            this.transform.rotation = Quaternion.Euler(0, 0, -90);
        Invoke("Dill", 0.1f);
    }
    private void Dill()
    {
        mRigidbody2D.velocity = Vector2.zero;
        transform.position = mPlayer.transform.position;
        mSpriteRenderer.enabled = true;
        mBoxCollider2D.enabled = true;
        StartCoroutine("DamTile");
    }

    IEnumerator DamTile()
    {
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(mPlayer.GetComponent<Player>().Rota <= 1)
                    Instantiate(mAttack_Tile, new Vector2(Mathf.RoundToInt(transform.position.x), transform.position.y + (j - 1)), Quaternion.Euler(0, 0, 0));
                else
                    Instantiate(mAttack_Tile, new Vector2(transform.position.x + (j - 1), Mathf.RoundToInt(transform.position.y)), Quaternion.Euler(0, 0, 0));
            }
            if (mSpriteRenderer.enabled == false)
                break;
            yield return new WaitForSeconds(0.03f);
        }
        mSpriteRenderer.enabled = false;
        mBoxCollider2D.enabled = false;
        yield return null;
    }
    public void Ds()
    {
        transform.position = new Vector3(555, 0, 0);
        mSpriteRenderer.enabled = false;
        mBoxCollider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Skel_Enemy"))
        {
            other.GetComponent<Enemy_Skel>().OnDam(2);
        }
    }
}
