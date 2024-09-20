using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeStom : MonoBehaviour
{
    [SerializeField] private GameObject mAttack_Tile;

    private int TurnBefore;
    public int TurnCount = 0;
    private int DesTurn = 0;
    private Vector2 mColortile;

    private void Start()
    {
        for (int i = 0; i < 8; i++)
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
            GameObject ATile = Instantiate(mAttack_Tile, new Vector2(Mathf.RoundToInt(transform.position.x) + mColortile.x, Mathf.RoundToInt(transform.position.y) + mColortile.y), Quaternion.identity);
            ATile.GetComponent<Attack_Tile>().Dam = 3;
        }
        Invoke("DillDestroy", 0.62f);
    }
    private void DillDestroy() => Destroy(gameObject);
    /*private void Update()
    {
        if(TurnBefore != GameManager.Turn)
        {
            TurnBefore = GameManager.Turn;
            if(GameManager.Turn != 5) TurnCount += 1;
            if (TurnCount > 1)
            {
                DesTurn += 1;
                for(int i = 0; i < 8; i++)
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
                    Instantiate(mAttack_Tile, new Vector2(Mathf.RoundToInt(transform.position.x) + mColortile.x, Mathf.RoundToInt(transform.position.y) + mColortile.y), Quaternion.identity);
                }
                TurnCount = 0;
            }
        }
        if (DesTurn >= 1)
            Destroy(gameObject);
    }*/
}
