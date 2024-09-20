using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarDied : MonoBehaviour
{
    Image nowHpbar;

    private void Start()
    {
        nowHpbar = GetComponent<Image>();
    }

    private void Update()
    {
        if (nowHpbar.fillAmount <= 0.01f)
        {
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}
