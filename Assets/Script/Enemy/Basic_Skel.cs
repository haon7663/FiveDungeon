using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Skel : MonoBehaviour
{
    private void Start()
    {
        Invoke("onDestroy", 0.45f);
    }
    private void onDestroy()
    {
        Destroy(gameObject);
    }
}
