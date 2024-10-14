using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
     public float forceAmount = 10f; // 力の大きさ
    private Rigidbody rb;
    public float Time = 5f;

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
        Invoke("Destroy",Time);
        // 前方に力を加える
        rb.AddForce(transform.forward * forceAmount, ForceMode.Impulse);
    }
    public void Destroy()
    {
    Destroy(gameObject);
    }
  void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "enemy")
    {
    Destroy();
    }
    else if(other.gameObject.tag == "bigzon")
    {
    Destroy();

    }
  }
}
