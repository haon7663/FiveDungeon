using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private GameObject mPlayer;

    private float ShakeAmount;
    private float ShakeTime;

    Vector3 initialPosition;

    private void Update()
    {
        if (ShakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
            ShakeTime -= Time.deltaTime;
        }
        else
        {
            ShakeTime = 0.0f;
            transform.position = initialPosition;
        }
    }
    private void FixedUpdate()
    {
        Vector3 dst = mPlayer.transform.position;
        if (dst.y <= -3.1f)
            dst = new Vector3(dst.x, -3.1f);
        else if (dst.y >= 3.1f)
            dst = new Vector3(dst.x, 3.1f);
        dst = new Vector3(0, dst.y);

        transform.position = Vector3.Lerp(transform.position, dst, 4f * Time.deltaTime);
        initialPosition = new Vector3(transform.position.x, transform.position.y, -10);
    }
    public void VibrateForTime(float time, float power)
    {
        ShakeAmount = power;
        ShakeTime = time;
    }
}
