using System.Collections;
using UnityEngine;

public class Enemy_Skel : MonoBehaviour
{
    [SerializeField] private Material mRedMaterial;
    [SerializeField] private Material mDefaultMaterial;
    [SerializeField] private int mEnemyType;

    private float RedDam;
    public int HP;
    private Animator mAnimator;
    private SpriteRenderer mSpriteRenderer;
    private ParticleSystem mParticleSystem;

    private GameObject mPlayer;
    public GameObject mAtt;
    public GameObject mBoneAtt;

    private float inputX, inputY;
    private int moveTurn = 0;
    private int AttackTurn = 1;
    public int AttackD;
    public int range;

    private bool isAct = true;

    public Sprite[] sprite = new Sprite[2];
    public GameObject hudDamageText;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mParticleSystem = GetComponentInChildren<ParticleSystem>();
        //mAtt = GameObject.FindGameObjectWithTag("Skel_B");
    }
    private void FixedUpdate()
    {
        if(RedDam > 0)
        {
            mSpriteRenderer.material = mRedMaterial;
            RedDam -= Time.deltaTime;
        }
        else mSpriteRenderer.material = mDefaultMaterial;
        if (!GameManager.HaveTurn && GameManager.isAcitive && isAct)
        {
            isAct = false;
            if((Mathf.Abs(Mathf.RoundToInt(transform.position.x - mPlayer.transform.position.x)) <= range && Mathf.RoundToInt(transform.position.y - mPlayer.transform.position.y) == 0) 
             || (Mathf.Abs(Mathf.RoundToInt(transform.position.y - mPlayer.transform.position.y)) <= range && Mathf.RoundToInt(transform.position.x - mPlayer.transform.position.x) == 0))
            {
                if(mEnemyType == 0)
                {
                    if (Mathf.RoundToInt(transform.position.x - mPlayer.transform.position.x) == 1)
                    {
                        Instantiate(mAtt, mPlayer.transform.position, Quaternion.Euler(0, 0, 90));
                        mAnimator.SetInteger("Rota", 1);
                        mSpriteRenderer.flipX = true;
                    }
                    else if (Mathf.RoundToInt(transform.position.x - mPlayer.transform.position.x) == -1)
                    {
                        Instantiate(mAtt, mPlayer.transform.position, Quaternion.Euler(0, 0, -90));
                        mAnimator.SetInteger("Rota", 1);
                        mSpriteRenderer.flipX = false;
                    }
                    else if (Mathf.RoundToInt(transform.position.y - mPlayer.transform.position.y) == 1)
                    {
                        Instantiate(mAtt, mPlayer.transform.position, Quaternion.Euler(0, 0, 180));
                        mAnimator.SetInteger("Rota", 0);
                    }
                    else if (Mathf.RoundToInt(transform.position.y - mPlayer.transform.position.y) == -1)
                    {
                        Instantiate(mAtt, mPlayer.transform.position, Quaternion.Euler(0, 0, 0));
                        mAnimator.SetInteger("Rota", 2);
                    }
                    if (GameManager.PlayerShield > 0)
                        GameManager.PlayerShield -= 1;
                    else
                    {
                        GameManager.Gm.ShakeAllcam(0.15f, 0.25f);
                        GameManager.PlayerHP -= 1;
                        mPlayer.GetComponent<Player>().RedDam = 0.2f;
                        mPlayer.GetComponent<Player>().OnDam();
                    }
                }
                else if(mEnemyType == 1)
                {
                    AttackTurn += 1;
                    if (AttackTurn > AttackD)
                    {
                        AttackTurn = 0;
                        if (Mathf.RoundToInt(transform.position.x - mPlayer.transform.position.x) >= 1)
                        {
                            Instantiate(mBoneAtt, transform.position, Quaternion.Euler(0, 0, 180));
                            mAnimator.SetInteger("Rota", 1);
                            mSpriteRenderer.flipX = true;
                        }
                        else if (Mathf.RoundToInt(transform.position.x - mPlayer.transform.position.x) <= -1)
                        {
                            Instantiate(mBoneAtt, transform.position, Quaternion.Euler(0, 0, 0));
                            mAnimator.SetInteger("Rota", 1);
                            mSpriteRenderer.flipX = false;
                        }
                        else if (Mathf.RoundToInt(transform.position.y - mPlayer.transform.position.y) >= 1)
                        {
                            Instantiate(mBoneAtt, transform.position, Quaternion.Euler(0, 0, -90));
                            mAnimator.SetInteger("Rota", 0);
                        }
                        else if (Mathf.RoundToInt(transform.position.y - mPlayer.transform.position.y) <= -1)
                        {
                            Instantiate(mBoneAtt, transform.position, Quaternion.Euler(0, 0, 90));
                            mAnimator.SetInteger("Rota", 2);
                        }
                    }
                }
            }
            else
            {
                EnemyMovesign();
            }
        }
        else if(!GameManager.HaveTurn && !GameManager.isAcitive && !isAct)
        {
            isAct = true;
        }
        Died();
    }
    private void Died()
    {
        if(HP <= 0)
        {
            GameManager.Gm.Score += 1;
            Destroy(gameObject);
        }    
    }
    public void OnDam(int dam)
    {
        mParticleSystem.Play();
        GameManager.Gm.PlaySound("skelhit");
        HP -= dam;
        RedDam = 0.125f;
        GameObject hudText = Instantiate(hudDamageText, transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        hudText.GetComponent<DamCount>().Damage = dam;
        GameManager.Gm.ShakeAllcam(0.12f, 0.2f);
    }
    public void EnemyMovesign()
    {
        moveTurn += 1;
        if (moveTurn > 0)
        {
            moveTurn = 0;
            StartCoroutine("Enemymove");
        }
    }
    IEnumerator Enemymove()
    {
        MoveRata();
        GameManager.Gm.PlaySound("skel");
        for (int i = 0; i < 8; i++)
        {
            transform.Translate(new Vector2(inputX, inputY) / 8);
            yield return new WaitForFixedUpdate();
        }
        inputX = 0; inputY = 0;
        yield return null;
    }
    
    private void MoveRata()
    {
        if (mEnemyType == 0)
        {
            if (Mathf.Abs(transform.position.x - mPlayer.transform.position.x) >= Mathf.Abs(transform.position.y - mPlayer.transform.position.y))
            {
                if (transform.position.x < mPlayer.transform.position.x)
                {
                    inputX += 1;
                    mAnimator.SetInteger("Rota", 1);
                    mSpriteRenderer.flipX = false;
                }
                else
                {
                    inputX -= 1;
                    mAnimator.SetInteger("Rota", 1);
                    mSpriteRenderer.flipX = true;
                }
            }
            else
            {
                if (transform.position.y < mPlayer.transform.position.y)
                {
                    inputY += 1;
                    mAnimator.SetInteger("Rota", 2);
                }
                else
                {
                    inputY -= 1;
                    mAnimator.SetInteger("Rota", 0);
                }
            }
        }
        else if (mEnemyType == 1)
        {
            if (Mathf.Abs(transform.position.x - mPlayer.transform.position.x) <= Mathf.Abs(transform.position.y - mPlayer.transform.position.y))
            {
                if(Mathf.Abs(transform.position.y - mPlayer.transform.position.y) > range)
                {
                    if (transform.position.y < mPlayer.transform.position.y)
                    {
                        inputY += 1;
                        mAnimator.SetInteger("Rota", 2);
                    }
                    else
                    {
                        inputY -= 1;
                        mAnimator.SetInteger("Rota", 0);
                    }
                }
                else
                {
                    if (transform.position.x < mPlayer.transform.position.x)
                    {
                        inputX += 1;
                        mAnimator.SetInteger("Rota", 1);
                        mSpriteRenderer.flipX = false;
                    }
                    else
                    {
                        inputX -= 1;
                        mAnimator.SetInteger("Rota", 1);
                        mSpriteRenderer.flipX = true;
                    }
                }
            }
            else
            {
                if (Mathf.Abs(transform.position.x - mPlayer.transform.position.x) > range)
                {
                    if (transform.position.x < mPlayer.transform.position.x)
                    {
                        inputX += 1;
                        mAnimator.SetInteger("Rota", 1);
                        mSpriteRenderer.flipX = false;
                    }
                    else
                    {
                        inputX -= 1;
                        mAnimator.SetInteger("Rota", 1);
                        mSpriteRenderer.flipX = true;
                    }
                }
                else
                {
                    if (transform.position.y < mPlayer.transform.position.y)
                    {
                        inputY += 1;
                        mAnimator.SetInteger("Rota", 2);
                    }
                    else
                    {
                        inputY -= 1;
                        mAnimator.SetInteger("Rota", 0);
                    }
                }
            }
        }
    }
}
