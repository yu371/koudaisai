using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class bom : MonoBehaviour
{
    public GameObject bomobbj;
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
        rb.AddForce(transform.forward * -forceAmount, ForceMode.Impulse);
    }
     void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.transform.tag != "Gun")
        {
        Instantiate(bomobbj,transform.position,bomobbj.transform.rotation);
        Destroy(gameObject);
        }     
      
    }
    void OnTriggerEnter(Collider other)
    {
         if(other.transform.tag != "Gun")
        {
        Instantiate(bomobbj,transform.position,bomobbj.transform.rotation);
        Destroy(gameObject);
        }     
    }
}
