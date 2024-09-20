using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RColorTile : MonoBehaviour
{
    [SerializeField] private GameObject mTile;
    [SerializeField] private GameObject mAtt_Tile;

    private GameObject[] TIle;

    private GameObject mPlayer;

    private Vector2 mColortile;

    private int downRange;
    private int arraySize;
    private void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        arraySize = 16;
        TIle = new GameObject[arraySize];
    }

    public void Move_Rangemark(int Range)
    {
        downRange = Range;
        for(int i = 0; i < 4; i++)
        {
            for(int j = 1; j <= Range; j++)
            {
                mColortile = new Vector2(0, 0);
                if (i == 0) mColortile.x = 1; 
                if (i == 1) mColortile.x = -1; 
                if (i == 2) mColortile.y = 1; 
                if (i == 3) mColortile.y = -1;
                TIle[(j-1)*4 + i] = Instantiate(mTile, new Vector2(mPlayer.transform.position.x + mColortile.x*j, mPlayer.transform.position.y + mColortile.y*j), Quaternion.identity);
            }    
        }
    }
    public void Attack_Rangemark(int Range)
    {
        downRange = Range;
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
    public void Q_Rangemark()
    {
        Debug.Log("d");
        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                mColortile = new Vector2(0, 0);
                if (i == 0) mColortile.x = 1;
                if (i == 1) mColortile.x = -1;
                if (i == 2) mColortile.y = 1;
                if (i == 3) mColortile.y = -1;
                TIle[(j - 1) * 4 + i] = Instantiate(mTile, new Vector2(mPlayer.transform.position.x + mColortile.x * j, mPlayer.transform.position.y + mColortile.y * j), Quaternion.identity);
            }
        }
    }
    public void onMoveDestroy()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j <= downRange; j++)
            {
                Destroy(TIle[(j - 1) * 4 + i]);
            }
        }
    }
    public void onAttackDestroy()
    {
        for (int i = 0; i < 8; i++)
        { 
            for (int j = 1; j <= downRange; j++)
            {
                Destroy(TIle[(j - 1) * 4 + i]);
            }
        }
    }
    public void onQDestroy()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                Destroy(TIle[(j - 1) * 4 + i]);
            }
        }
    }
}
