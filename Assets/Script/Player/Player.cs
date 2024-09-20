using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float mPlayerspeed;
    [SerializeField] private R_ColorTile mColorTile;
    [SerializeField] private GameObject mTile;
    [SerializeField] private GameObject mAttack_Tile;
    [SerializeField] private GameObject mBasic_Att;
    [SerializeField] private GameObject mPa;
    [SerializeField] private GameObject mDead;
    [SerializeField] private FadeIn mFadeIn;
    [SerializeField] private GameObject mSwordStom;

    [SerializeField] private Material mRedMaterial;
    [SerializeField] private Material mDefaultMaterial;
    public float Qcolldown;
    public float Ecolldown;
    public float Rcolldown;
    public float Qcoll;
    public float Ecoll;
    public float Rcoll;
    public float RedDam;

    public int isn = 0;
    public int Rota;
    private int SmartRota;

    private float inputX, inputY;

    private Vector2 Devpos;
    private Vector2 Colpos;

    private PlayerBox mPlayerbox;
    private Rigidbody2D mRigidbody2D;
    private Animator mAnimator;
    private SpriteRenderer mSpriteRenderer;
    private ParticleSystem mParticleSystem;

    private bool isMoving = false;
    public bool isAttack = false;
    private bool Dontmove = false;
    private bool isDied = false;
    private bool isQ = false;
    private bool isClick = false;
    private bool isSmartKey = false;

    private void Awake()
    {
        Ecoll = 0;
        Qcoll = 0;
    }
    private void Start()
    {
        mAnimator = GetComponent<Animator>();
        mRigidbody2D = GetComponent<Rigidbody2D>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mColorTile.Move_Rangemark(1);
        mPlayerbox = transform.GetChild(0).GetComponent<PlayerBox>();
        mParticleSystem = GetComponentInChildren<ParticleSystem>();
        mFadeIn.fade(false);
    }
    private void Update()
    {
        if (GameManager.HaveTurn && GameManager.Turn > 0 && !isMoving)
        {
            if (Input.GetAxisRaw("Horizontal") > 0) Rota = 0;
            else if (Input.GetAxisRaw("Horizontal") < 0) Rota = 1;
            else if (Input.GetAxisRaw("Vertical") > 0) Rota = 2;
            else if (Input.GetAxisRaw("Vertical") < 0) Rota = 3;
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                if(!isClick)
                {
                    isClick = true;
                    if(isn == 1)
                    {
                        mColorTile.AllDestroy();
                        mColorTile.Q_RangeClick(Rota);
                    }
                    else if (isn == 2)
                    {
                        mColorTile.AllDestroy();
                        mColorTile.Move_RangeClick(3, Rota);
                    }
                    else if (isn == 3)
                    {
                        mColorTile.AllDestroy();
                        mColorTile.SwordStom_RangeClick(1);
                    }
                    else if (isAttack)
                    {
                        mColorTile.AllDestroy();
                        mColorTile.Attack_RangeClick(Rota);
                    }
                    else if (!isAttack)
                    {
                        mColorTile.AllDestroy();
                        mColorTile.Move_RangeClick(1, Rota);
                    }
                }
            }
            else
            {
                isClick = false;
                InputLeftShift();
                InputSpace();
                InputSkill();
            }
            InputADSW();
        }
        Reddam();
    }
    private void FixedUpdate()
    {
        if(GameManager.PlayerHP <= 0 && !isDied)
        {
            isDied = true;
            Instantiate(mDead, transform.position, Quaternion.identity);
            mSpriteRenderer.enabled = false;
            Invoke("Fadein", 0.5f);
        }
    }

    private void Fadein()
    {
        mFadeIn.fade(true);
        enabled = false;
    }
    private void Reddam()
    {
        if (RedDam > 0)
        {
            mSpriteRenderer.material = mRedMaterial;
            RedDam -= Time.deltaTime;
        }
        else mSpriteRenderer.material = mDefaultMaterial;
    }
    
    private void InputLeftShift()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameManager.PlayerShield += 1;
            GameManager.Turn -= 1;
        }
    }
    private void InputSpace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isMoving)
            {
                SmartRota = 100;
                isSmartKey = false;
                isn = 0;
                if (isQ)
                {
                    mColorTile.AllDestroy();
                    isQ = false;
                }
                if (isAttack)
                {
                    mColorTile.AllDestroy();
                    Dontmove = true;
                    mColorTile.Move_Rangemark(1);
                    isAttack = false;
                    Dontmove = false;
                }
                else
                {
                    mColorTile.AllDestroy();
                    Dontmove = true;
                    mColorTile.Attack_Rangemark(1);
                    isAttack = true;
                    Dontmove = false;
                }
            }
        }
    }
    private void InputSkill()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Qcoll <= 0)
            {
                SmartRota = 100;
                isSmartKey = false;
                if (isn != 1)
                {
                    isn = 1;
                    isQ = true;
                    mColorTile.AllDestroy();
                    mColorTile.Q_Rangemark();
                }
                else
                {
                    mColorTile.AllDestroy();
                    if(isAttack) mColorTile.Attack_Rangemark(1);
                    else mColorTile.Move_Rangemark(1);
                    isn = 0;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (Ecoll <= 0)
            {
                SmartRota = 100;
                isSmartKey = false;
                if (isn != 2)
                {
                    isn = 2;
                    mColorTile.AllDestroy();
                    mColorTile.Move_Rangemark(3);
                }
                else
                {
                    isn = 0;
                    mColorTile.AllDestroy();
                    mColorTile.Move_Rangemark(1);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (Rcoll <= 0)
            {
                SmartRota = 100;
                isSmartKey = false;
                if (isn != 3)
                {
                    isn = 3;
                    isQ = true;
                    mColorTile.AllDestroy();
                    mColorTile.Attack_Rangemark(1);
                }
                else
                {
                    mColorTile.AllDestroy();
                    if (isAttack) mColorTile.Attack_Rangemark(1);
                    else mColorTile.Move_Rangemark(1);
                    isn = 0;
                }
            }
        }
    }
    private void InputADSW()
    {
        if (!isSmartKey)
        {
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
            {
                isSmartKey = true;
                SmartRota = Rota;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
            {
                if(SmartRota == Rota)
                {
                    if (!isMoving)
                    {
                        if (isn == 1)
                        {
                            if (Rota == 0) Blade(1, true, false);
                            else if (Rota == 1) Blade(1, true, true);
                            else if (Rota == 2) Blade(2, false, true);
                            else if (Rota == 3) Blade(0, false, true);
                        }
                        else if (isn == 2)
                        {
                            if (Rota == 0) Dash(1, 3, 0, true, false);
                            else if (Rota == 1) Dash(1, -3, 0, true, true);
                            else if (Rota == 2) Dash(2, 0, 3, false, true);
                            else if (Rota == 3) Dash(0, 0, -3, false, true);
                        }
                        else if (isn == 3)
                        {
                            SwordStom();
                        }
                        else if (isAttack)
                        {
                            if (Rota == 0) Attack(90, 1, 1, 0, true, false);
                            else if (Rota == 1) Attack(-90, 1, -1, 0, true, true);
                            else if (Rota == 2) Attack(180, 2, 0, 1, false, true);
                            else if (Rota == 3) Attack(0, 0, 0, -1, false, true);
                            StartCoroutine("PlayerAttack");
                        }
                        else if (!Dontmove && !isAttack)
                        {
                            if (Rota == 0) Move(1, 1, 0, true, false);
                            else if (Rota == 1) Move(1, -1, 0, true, true);
                            else if (Rota == 2) Move(2, 0, 1, false, true);
                            else if (Rota == 3) Move(0, 0, -1, false, true);
                            StartCoroutine("Playermove");
                        }
                        SmartRota = 100;
                        isSmartKey = false;
                    }
                }
                else
                {
                    SmartRota = 100;
                    isSmartKey = false;
                    //mColorTile.AllDestroy();
                }
            }
        }
    }

    IEnumerator Playermove()
    {
        GameManager.Gm.PlaySound("Walk");
        GameManager.Turn -= 1;
        isMoving = true;
        for (int i = 0; i < 8; i++)
        {
            transform.Translate(new Vector2(inputX, inputY) / 8);
            yield return new WaitForFixedUpdate();
        }
        inputX = 0; inputY = 0;
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        Invoke("Move_delay", 0.1f);
        mColorTile.Move_Rangemark(1);
        yield return null;
    }
    IEnumerator PlayerAttack()
    {
        GameManager.Gm.PlaySound("sword");
        isMoving = true;
        for (int i = 0; i < 8; i++)
        {
            transform.Translate(new Vector2(inputX, inputY) / 8);
            yield return new WaitForFixedUpdate();
        }
        inputX = 0; inputY = 0;
        Invoke("Move_delay", 0.1f);
        
        yield return null;
    }

    public void OnDam()
    {
        mParticleSystem.Play(false);
    }
    private void Move_delay() => isMoving = false;
    private void Blade(int Animrota, bool isX, bool isflipx)
    {
        isQ = true;
        mPa.GetComponent<Sword_Pa>().Pa();
        GameManager.Turn -= 1;
        if(isX) mSpriteRenderer.flipX = isflipx;
        mAnimator.SetInteger("Rota", Animrota);
        Qcoll = Qcolldown;
        isn = 0;
        GameManager.Gm.PlaySound("swordbig");
        mColorTile.AllDestroy();
    }
    private void Dash(int Animrota, int x, int y, bool isX, bool isflipx)
    {
        if (isX) mSpriteRenderer.flipX = isflipx;
        mAnimator.SetInteger("Rota", Animrota);
        inputX = x;
        inputY = y;
        Ecoll = Ecolldown;
        mColorTile.AllDestroy();
        StartCoroutine("Playermove");
        isn = 0;
        GameManager.Gm.PlaySound("dash");
    }
    private void Attack(int Insrota, int Animrota, int x, int y, bool isX, bool isflipx)
    {
        Instantiate(mBasic_Att, new Vector2(transform.position.x + x, transform.position.y + y), Quaternion.Euler(0, 0, Insrota));
        if (isX) mSpriteRenderer.flipX = isflipx;
        mAnimator.SetInteger("Rota", Animrota);
        GameManager.Turn -= 1;
        if(x != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(mAttack_Tile, new Vector2(transform.position.x + x, transform.position.y + (i - 1)), Quaternion.identity);
            }
        }
        else if (y != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(mAttack_Tile, new Vector2(transform.position.x + (i - 1), transform.position.y + y), Quaternion.identity);
            }
        }
        mColorTile.AllDestroy();
        mColorTile.Attack_Rangemark(1);
    }
    private void Move(int Animrota, int x, int y, bool isX, bool isflipx)
    {
        inputX = x;
        inputY = y;
        mAnimator.SetInteger("Rota", Animrota);
        if (isX) mSpriteRenderer.flipX = isflipx;
        mColorTile.AllDestroy();
    }
    private void SwordStom()
    {
        GameManager.Turn -= 1;
        Rcoll = Rcolldown;
        mColorTile.AllDestroy();
        GameObject Stom = Instantiate(mSwordStom, transform.position, Quaternion.identity);
        Stom.transform.SetParent(this.transform); 
        isn = 0;
        GameManager.Gm.PlaySound("dash");
    }
}
