using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tilemap : MonoBehaviour
{
    [SerializeField] private GameObject mPlayer;

    public Tilemap mTilemap;
    public GridLayout mGridLayout;
    public Vector3Int mCellPosition;

    private void Start()
    {
        mTilemap = GetComponent<Tilemap>();
        mGridLayout = transform.parent.GetComponentInParent<GridLayout>();
    }
    private void Update()
    {
        Vector2 point = transform.position;
        mCellPosition = mGridLayout.WorldToCell(point);
    }
}
