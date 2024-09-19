using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyinstance : MonoBehaviour
{
    public GameObject enemy;
    private float span;
    public float instancespan;
    public bool on_off;
    public GameObject ghoost;
    // Start is called before the first frame update
    void Start()
    {
    on_off = false;
    instancespan = 5f;
    }
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
   public void Gamestart()
    {
    on_off = true;
    instancespan = 5f;
    }
    public void GameFinish()
    {
    on_off = false;

    }
}
