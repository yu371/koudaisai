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
    public float mai;
    // Start is called before the first frame update
    void Start()
    {
    on_off = false;
      Invoke("Game",60f);
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
        instancespan -= mai;
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
    Invoke("Game",60f);
    }
    private void Game()
    {
    on_off = true;
    }
    public void GameFinish()
    {
    on_off = false;

    }
}
