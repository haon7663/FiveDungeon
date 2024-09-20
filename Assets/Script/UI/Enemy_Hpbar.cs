using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Hpbar : MonoBehaviour
{
    private float maxhp;

    public Image nowHpbar;
    public float culhp;

    private void Start()
    {
        maxhp = transform.GetComponent<Enemy_Skel>().HP;
        nowHpbar = transform.GetChild(0).gameObject.transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        culhp = transform.GetComponent<Enemy_Skel>().HP;
        nowHpbar.fillAmount = culhp / maxhp;
    }
}
