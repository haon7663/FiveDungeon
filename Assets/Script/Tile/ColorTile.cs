using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTile : MonoBehaviour
{
    public void onDestroy()
    {
        Destroy(gameObject);
    }
}
