using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Updown : MonoBehaviour
{
    [SerializeField] private GameObject mFade;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Instantiate(mFade);
            Invoke("Scen", 1.5f);
        }
    }
    private void Scen()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
