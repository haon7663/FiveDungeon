using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Att : MonoBehaviour
{
    private void Start()
    {
        transform.Rotate(0, 0, Random.Range(14, -14));
        Invoke("onDestroy", 0.45f);
    }
    private void onDestroy()
    {
        Destroy(gameObject);
    }
}
