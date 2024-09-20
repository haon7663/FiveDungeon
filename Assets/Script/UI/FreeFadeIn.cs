using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FreeFadeIn : MonoBehaviour
{
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void fade(bool inout)
    {
        if (inout) StartCoroutine("fadein");
        else StartCoroutine("fadeout");
    }
    internal static class YieldInstructionCache
    {
        public static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();
        public static readonly WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();
        private static readonly Dictionary<float, WaitForSeconds> waitForSeconds = new Dictionary<float, WaitForSeconds>();

        public static WaitForSeconds WaitForSeconds(float seconds)
        {
            WaitForSeconds wfs;
            if (!waitForSeconds.TryGetValue(seconds, out wfs))
                waitForSeconds.Add(seconds, wfs = new WaitForSeconds(seconds));
            return wfs;
        }
    }
    IEnumerator fadein()
    {
        for (float i = 0; i < 0.75f; i += Time.deltaTime)
        {
            image.color += new Color(0, 0, 0, Time.deltaTime / 0.75f);
            yield return YieldInstructionCache.WaitForFixedUpdate;
        }
        yield return null;
    }
    IEnumerator fadeout()
    {
        for(float i = 0; i < 1.25f; i += Time.deltaTime)
        {
            image.color -= new Color(0, 0, 0, Time.deltaTime / 1.25f);
            yield return YieldInstructionCache.WaitForFixedUpdate;
        }
        yield return null;
    }

    public void ReGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
