using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamCount : MonoBehaviour
{
    [SerializeField] private float mJumpPower;
    [SerializeField] private float mDestroytime;
    [SerializeField] private float mCountUp;

    public int Damage;

    public TextMeshProUGUI mtext;
    private Rigidbody2D mRigidbody2D;

    private float mXSpeed;

    private void Start()
    {
        mtext = GetComponent<TextMeshProUGUI>();
        mXSpeed = Random.Range(-2f, 2f);
        mtext.text = Damage.ToString();
       
        transform.position += new Vector3(0, mCountUp, 0);
        mRigidbody2D = GetComponent<Rigidbody2D>();
        mRigidbody2D.AddForce(Vector2.up * mJumpPower, ForceMode2D.Impulse);
        Invoke("OnDestroy", mDestroytime);
    }

    private void Update()
    {
        this.transform.position += new Vector3(mXSpeed, 0) * Time.deltaTime;
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
