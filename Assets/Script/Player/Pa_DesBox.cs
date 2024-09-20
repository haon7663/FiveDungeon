using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pa_DesBox : MonoBehaviour
{
    private Sword_Pa SwordPa;

    private void Start()
    {
        SwordPa = transform.parent.gameObject.GetComponent<Sword_Pa>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            SwordPa.Ds();
    }
}
