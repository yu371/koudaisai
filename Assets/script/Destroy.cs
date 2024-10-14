using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float Time = 1f;
    // Start is called before the first frame update
    void Start()
    {
    Invoke("objDestroy",Time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void objDestroy()
    {
    Destroy(gameObject);
    }
}
