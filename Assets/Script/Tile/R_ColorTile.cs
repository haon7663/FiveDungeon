using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_ColorTile : MonoBehaviour
{
    [SerializeField] private GameObject mTile;
    [SerializeField] private GameObject mAtt_Tile;
    [SerializeField] private GameObject mHighLight_Tile;
    [SerializeField] private GameObject mHighLightAttack_Tile;

    public GameObject[] TIle;

    private GameObject mPlayer;

    private Vector2 mColortile;

    private int downRange;
    private int arraySize;
    private void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        arraySize = 200;
        TIle = new GameObject[arraySize];
    }

    public void Move_Rangemark(int Range)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j <= Range; j++)
            {
                mColortile = new Vector2(0, 0);
                if (i == 0) mColortile.x = 1;
                if (i == 1) mColortile.x = -1;
                if (i == 2) mColortile.y = 1;
                if (i == 3) mColortile.y = -1;
                TIle[(j - 1) * 4 + i] = Instantiate(mTile, new Vector2(Mathf.RoundToInt(mPlayer.transform.position.x) + mColortile.x * j, Mathf.RoundToInt(mPlayer.transform.position.y) + mColortile.y * j), Quaternion.identity);
            }
        }
    }
    public void Move_RangeClick(int Range, int Rota)
    {
        for (int j = 1; j <= Range; j++)
        {
            mColortile = new Vector2(0, 0);
            if (Rota == 0) mColortile.x = 1;
            if (Rota == 1) mColortile.x = -1;
            if (Rota == 2) mColortile.y = 1;
            if (Rota == 3) mColortile.y = -1;
            TIle[j] = Instantiate(mHighLight_Tile, new Vector2(Mathf.RoundToInt(mPlayer.transform.position.x) + mColortile.x * j, Mathf.RoundToInt(mPlayer.transform.position.y) + mColortile.y * j), Quaternion.identity);
        }
    }
    public void Attack_Rangemark(int Range)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 1; j <= Range; j++)
            {
                mColortile = new Vector2(0, 0);
                if (i == 0) mColortile.x = 1;
                if (i == 1) mColortile.x = -1;
                if (i == 2) mColortile.y = 1;
                if (i == 3) mColortile.y = -1;
                if (i == 4)
                {
                    mColortile.x = 1;
                    mColortile.y = -1;
                }
                if (i == 5)
                {
                    mColortile.x = -1;
                    mColortile.y = -1;
                }
                if (i == 6)
                {
                    mColortile.x = -1;
                    mColortile.y = 1;
                }
                if (i == 7)
                {
                    mColortile.x = 1;
                    mColortile.y = 1;
                }
                TIle[(j - 1) * 8 + i] = Instantiate(mAtt_Tile, new Vector2(mPlayer.transform.position.x + mColortile.x * j, mPlayer.transform.position.y + mColortile.y * j), Quaternion.identity);
            }
        }
    }
    public void Attack_RangeClick(int Rota)
    {
        mColortile = new Vector2(0, 0);
        if (Rota == 0) mColortile.x = 1;
        if (Rota == 1) mColortile.x = -1;
        if (Rota == 2) mColortile.y = 1;
        if (Rota == 3) mColortile.y = -1;
        if (Rota <= 1)
        {
            for (int i = 0; i < 3; i++)
                TIle[i] = Instantiate(mHighLightAttack_Tile, new Vector2(Mathf.RoundToInt(mPlayer.transform.position.x) + mColortile.x, Mathf.RoundToInt(mPlayer.transform.position.y) + mColortile.y + i - 1), Quaternion.identity);
        }
        else
        {
            for (int i = 0; i < 3; i++)
                TIle[i] = Instantiate(mHighLightAttack_Tile, new Vector2(Mathf.RoundToInt(mPlayer.transform.position.x) + mColortile.x + i - 1, Mathf.RoundToInt(mPlayer.transform.position.y) + mColortile.y), Quaternion.identity);
        }
    }
    public void Q_Rangemark()
    {
        int tile = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                mColortile = new Vector2(0, 0);
                if (i == 0) mColortile.x = j;
                if (i == 1) mColortile.x = -j;
                if (i == 2) mColortile.y = j;
                if (i == 3) mColortile.y = -j;
                if (i == 4)
                {
                    mColortile.x = j;
                    TIle[tile++] = Instantiate(mAtt_Tile, new Vector2(mPlayer.transform.position.x + mColortile.x, mPlayer.transform.position.y - 1), Quaternion.identity);
                    mColortile.y = -j;
                    if (j != 1) TIle[tile++] = Instantiate(mAtt_Tile, new Vector2(mPlayer.transform.position.x + 1, mPlayer.transform.position.y + mColortile.y), Quaternion.identity);
                }
                if (i == 5)
                {
                    mColortile.x = -j;
                    TIle[tile++] = Instantiate(mAtt_Tile, new Vector2(mPlayer.transform.position.x + mColortile.x, mPlayer.transform.position.y - 1), Quaternion.identity);
                    mColortile.y = -j;
                    if (j != 1) TIle[tile++] = Instantiate(mAtt_Tile, new Vector2(mPlayer.transform.position.x - 1, mPlayer.transform.position.y + mColortile.y), Quaternion.identity);
                }
                if (i == 6)
                {
                    mColortile.x = -j;
                    TIle[tile++] = Instantiate(mAtt_Tile, new Vector2(mPlayer.transform.position.x + mColortile.x, mPlayer.transform.position.y + 1), Quaternion.identity);
                    mColortile.y = j;
                    if (j != 1) TIle[tile++] = Instantiate(mAtt_Tile, new Vector2(mPlayer.transform.position.x - 1, mPlayer.transform.position.y + mColortile.y), Quaternion.identity);
                }
                if (i == 7)
                {
                    mColortile.x = j;
                    TIle[tile++] = Instantiate(mAtt_Tile, new Vector2(mPlayer.transform.position.x + mColortile.x, mPlayer.transform.position.y + 1), Quaternion.identity);
                    mColortile.y = j;
                    if(j != 1) TIle[tile++] = Instantiate(mAtt_Tile, new Vector2(mPlayer.transform.position.x + 1, mPlayer.transform.position.y + mColortile.y), Quaternion.identity);
                }
                if(i <= 3) TIle[tile++] = Instantiate(mAtt_Tile, new Vector2(mPlayer.transform.position.x + mColortile.x, mPlayer.transform.position.y + mColortile.y), Quaternion.identity);
            }
        }
    }
    public void Q_RangeClick(int Rota)
    {
        mColortile = new Vector2(0, 0);
        if (Rota == 0) mColortile.x = 1;
        if (Rota == 1) mColortile.x = -1;
        if (Rota == 2) mColortile.y = 1;
        if (Rota == 3) mColortile.y = -1;
        int tile = 0;
        if (Rota <= 1)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tile++;
                    TIle[tile] = Instantiate(mHighLightAttack_Tile, new Vector2(Mathf.RoundToInt(mPlayer.transform.position.x) + mColortile.x * j, Mathf.RoundToInt(mPlayer.transform.position.y) + mColortile.y + i - 1), Quaternion.identity);
                }
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tile++;
                    TIle[tile] = Instantiate(mHighLightAttack_Tile, new Vector2(Mathf.RoundToInt(mPlayer.transform.position.x) + mColortile.x + i - 1, Mathf.RoundToInt(mPlayer.transform.position.y) + mColortile.y * j), Quaternion.identity);
                }
            }
        }
    }
    public void SwordStom_RangeClick(int Range)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 1; j <= Range; j++)
            {
                mColortile = new Vector2(0, 0);
                if (i == 0) mColortile.x = 1;
                if (i == 1) mColortile.x = -1;
                if (i == 2) mColortile.y = 1;
                if (i == 3) mColortile.y = -1;
                if (i == 4)
                {
                    mColortile.x = 1;
                    mColortile.y = -1;
                }
                if (i == 5)
                {
                    mColortile.x = -1;
                    mColortile.y = -1;
                }
                if (i == 6)
                {
                    mColortile.x = -1;
                    mColortile.y = 1;
                }
                if (i == 7)
                {
                    mColortile.x = 1;
                    mColortile.y = 1;
                }
                TIle[(j - 1) * 8 + i] = Instantiate(mHighLightAttack_Tile, new Vector2(mPlayer.transform.position.x + mColortile.x * j, mPlayer.transform.position.y + mColortile.y * j), Quaternion.identity);
            }
        }
    }
    public void AllDestroy()
    {
        for(int i = 0; i < TIle.Length; i++)
            Destroy(TIle[i]);
    }
}
