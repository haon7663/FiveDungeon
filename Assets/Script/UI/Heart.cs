using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [SerializeField] private int HP;

    private Image mImage;

    private void Start()
    {
        mImage = GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        if (HP > GameManager.PlayerHP)
            mImage.enabled = false;
        else
            mImage.enabled = true;
    }
}
