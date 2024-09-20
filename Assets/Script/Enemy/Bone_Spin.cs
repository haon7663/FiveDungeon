using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone_Spin : MonoBehaviour
{
    private void Start()
    {
        transform.Rotate(0, 0, Random.Range(0, 359));
    }
    private void Update()
    {
        transform.Rotate(0, 0, 1250 * Time.deltaTime);
    }
}
