using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBox : MonoBehaviour
{
    private GameObject mPlayer;

    public bool isBox = false;
    public int Roat;

    private void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        transform.position = mPlayer.transform.position;
        if (mPlayer.GetComponent<Player>().Rota == 0)
            transform.position += new Vector3(1, 0);
        else if (mPlayer.GetComponent<Player>().Rota == 1)
            transform.position += new Vector3(-1, 0);
        else if (mPlayer.GetComponent<Player>().Rota == 2)
            transform.position += new Vector3(0, 1);
        else if (mPlayer.GetComponent<Player>().Rota == 3)
            transform.position += new Vector3(0, -1);

        Roat = mPlayer.GetComponent<Player>().Rota;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            isBox = true;
        else
            isBox = false;
    }
}
