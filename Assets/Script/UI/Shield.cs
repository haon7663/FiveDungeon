using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    [SerializeField] private int SD;

    private Image mImage;

    private void Start()
    {
        mImage = GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        if (SD > GameManager.PlayerShield)
            mImage.enabled = false;
        else
            mImage.enabled = true;
    }
}
