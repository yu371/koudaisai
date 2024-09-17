using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyinstance : MonoBehaviour
{
    public GameObject enemy;
    private float span;
    private float instancespan;
    private bool on_off;
    // Start is called before the first frame update
    void Start()
    {
        on_off = true;
    instancespan = 5f;
    }

    // Update is called once per frame
    void Update()
    {
    if(on_off == true)
    {
        span +=Time.deltaTime;
        if(instancespan >= 0.5f)
        {
        if(span >= instancespan)
        {
        span = 0;
        instancespan -= 0.1f;
        Instantiate(enemy,transform.position,Quaternion.identity);

        }
        }
        else
        {
         if(span >= 0.5f)
        {
        span = 0;
        Instantiate(enemy,transform.position,Quaternion.identity);

        }

    }
    }
    }
    void Gamestart()
    {

    }
}
