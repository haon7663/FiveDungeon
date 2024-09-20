using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Gm;

    public static int PlayerHP = 5;
    public static int PlayerShield = 0;
    public static int Turn = 5;
    public static bool HaveTurn = true;
    public static bool isAcitive = false;

    private bool isTurning;
    private bool isInvoke = true;
    private bool isInst = true;
    private bool isDanger = true;

    private int Turndown;
    private int summonTurn = 0;
    private float ShakeAmount;
    public int sumPlus = 0;
    public int sumCount = 2;
    public int sumMax = 5;
    public int Score;

    private int SumRange;

    public GameObject[] TIle = new GameObject[10];
    public Vector2[] XY = new Vector2[3];
 
    private AudioSource mAudioSource;
    [SerializeField] private AudioClip mWalk;
    [SerializeField] private AudioClip mSkelwalk;
    [SerializeField] private AudioClip mSkelhit;
    [SerializeField] private AudioClip mSword;
    [SerializeField] private AudioClip mSwordBig;
    [SerializeField] private AudioClip mDash;

    [SerializeField] private GameObject mTurnText;
    [SerializeField] private GameObject mPlayerText;
    [SerializeField] private GameObject mSkel;
    [SerializeField] private GameObject mSkelRange;
    [SerializeField] private GameObject mSumDanger;

    [SerializeField] private GameObject mMainCamera;
    [SerializeField] private GameObject mCamera;
    [SerializeField] private GameObject mFlatCamera;
    [SerializeField] private GameObject mFade;

    private GameObject mPlayer;
    private void Awake()
    {
        mFade.SetActive(true);
        PlayerHP = 5;
        Turn = 5;
        HaveTurn = true;
        isAcitive = false;
        isInvoke = true;
        isInst = true;
        isDanger = true;
        summonTurn = 0;
        sumPlus = 0;
        sumCount = 2;
        sumMax = 5;
        Score = 0;
        SumRange = 0;
    }
    private void Start()
    {
        Gm = this;

        mPlayer = GameObject.FindGameObjectWithTag("Player");
        this.mAudioSource = GetComponent<AudioSource>();
        for (int i = 0; i < 2; i++)
        {
            float X = Random.Range(-4, 6);
            float Y = Random.Range(5, -5);
            Instantiate(mSkel, new Vector3(X, Y, 0), Quaternion.identity);
        }
        Turndown = Turn;
    }

    private void Update()
    {
        if(Turndown != Turn && Turn != 5)
        {
            Turndown = Turn;
            mPlayer.GetComponent<Player>().Qcoll -= 1;
            mPlayer.GetComponent<Player>().Ecoll -= 1;
            mPlayer.GetComponent<Player>().Rcoll -= 1;
        }
    }
    private void FixedUpdate()
    {
        if (Turn <= 0 && !isTurning && isInst)
        {
            isInst = false;

            Invoke("Inst", 0.13f);
        }
        if(!HaveTurn && !isAcitive && isInvoke && !isTurning)
        {
            isInvoke = false;
            Invoke("onAct", 0.13f);
        }
    }
    private void Inst()
    {
        if (HaveTurn)
        {
            HaveTurn = false;
            Instantiate(mTurnText, GameObject.Find("Canvas").transform);
        }
        else
        {
            if (PlayerHP > 0)
            {
                Instantiate(mPlayerText, GameObject.Find("Canvas").transform);
                sumPlus += 1;
                if (sumPlus >= sumMax)
                {
                    sumMax += 3;
                    sumPlus = 0;
                    sumCount += 1;
                }
            }
            HaveTurn = true;
        }
        isInst = true;
        isTurning = true;
        Invoke("TurnDown", 1.75f);
    }
    private void TurnDown()
    {
        isTurning = false;
        Turn = 5;
        summonTurn += 1;
        if(HaveTurn) PlayerShield = 0;
        if (summonTurn >= 2 && isDanger)
        {
            isDanger = false;
            for (int i = 0; i < sumCount; i++)
            {
                XY[i] = new Vector2(Random.Range(-4, 6), Random.Range(-5, 5));
                TIle[i] = Instantiate(mSumDanger, XY[i], Quaternion.identity);
            }
        }
        if (summonTurn >= 4)
        {
            for(int i = 0; i < sumCount; i++)
            {
                TIle[i].GetComponent<Danger_Tile>().DangerTile();
                SumRange += 1;
                if(SumRange > 3)
                {
                    SumRange = 0;
                    Instantiate(mSkelRange, XY[i], Quaternion.identity);
                }
                else
                    Instantiate(mSkel, XY[i], Quaternion.identity);
            }
            summonTurn = 0;
            isDanger = true;
        }
    }
    private void onAct()
    {
        if(Turn > 0)
        {
            Turn -= 1;
        }
            
        isAcitive = true;
        Invoke("unAct", 0.2f);
    }
    private void unAct()
    {
        isAcitive = false;
        isInvoke = true;
    }

    public void PlaySound(string action)
    {
        switch (action)
        {
            case "Walk":
                mAudioSource.clip = mWalk;
                mAudioSource.volume = 1f;
                break;

            case "skel":
                mAudioSource.clip = mSkelwalk;
                mAudioSource.volume = 1f;
                break;
            case "skelhit":
                mAudioSource.clip = mSkelhit;
                mAudioSource.volume = 1f;
                break;
            case "sword":
                mAudioSource.clip = mSword;
                mAudioSource.volume = 1f;
                break;

            case "bigsword":
                mAudioSource.clip = mSwordBig;
                mAudioSource.volume = 1f;
                break;
            case "dash":
                mAudioSource.clip = mDash;
                mAudioSource.volume = 1f;
                break;
        }
        mAudioSource.Play();
    }

    public void ShakeAllcam(float Time, float Power)
    {
        mMainCamera.GetComponent<FollowCam>().VibrateForTime(Time, Power);
    }
}
