using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private FreeFadeIn mFadeIn;

    private bool isPress = false;
    private void Start()
    {
        isPress = false;
        mFadeIn.fade(false);
    }

    

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !isPress)
        {
            mFadeIn.fade(true);
            isPress = true;
            Invoke("MoveScene", 1f);
        }
    }
    private void MoveScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
