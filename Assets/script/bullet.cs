using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
     public float forceAmount = 500f; // 力の大きさ
    private Rigidbody rb;

    void Start()
    {
        // Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
           AddForceForward();
    }

    void Update()
    {

    }

    void AddForceForward()
    {
        // 前方に力を加える
        rb.AddForce(transform.forward * forceAmount, ForceMode.Impulse);
    }
}
