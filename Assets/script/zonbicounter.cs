using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonbicounter : MonoBehaviour
{
    public int zonbicount;
    public GameObject bigzonbi;
    private float span;
    public GameObject obbj;
    void Start()
    {
    }
    void Update()
    {
        span += Time.deltaTime;
       if(zonbicount >= 100)
       {
        zonbicount -= 10000;
        Bigzonbi();
        }
    }
    public Material sky;
    void Bigzonbi()
    {
    Instantiate(obbj,transform.position,obbj.transform.rotation);
    RenderSettings.skybox = sky;
//     List<GameObject> enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("enemy"));
// //    for (int i = 0; i < enemies.Count; i++)
// //    {
// //     if(i <100)
// //     {
// //     enemies[i].GetComponent<ZombieCharacterControl>().Death();
// //     }
// //    }
//     enemies.Clear();
    Instantiate(bigzonbi,transform.position,Quaternion.identity);
    }
}
