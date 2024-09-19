using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
  //最大HPと現在のHP。
    int maxHp = 100;
    int currentHp;
    //Sliderを入れる
    public Slider slider;
    public score score;
    public GameObject sliderobj;
    public enemyinstance enemyinstance;
    public enemyinstance a;
    public enemyinstance b;
     public enemyinstance c;
     public enemyinstance d;
     public enemyinstance e;
    //  public enemyinstance f;
    // public enemyinstance g;
    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
    }
    void Update ()
    {
    }
    void OnCollisionEnter(Collision collider)
    {
      if (collider.gameObject.tag == "enemy")
        {
            int damage = 10;
            Debug.Log("damage : " + damage);
            currentHp = currentHp - damage;
            slider.value = (float)currentHp / (float)maxHp; ;
            if(currentHp <= 0)
            {
            score.AddPoint();
            GameFinish();
            }
        }
    }
    public void GameStart()
    {
        //Sliderを満タンにする。
        slider.value = 1;
     
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
    }
    public void GameFinish()
    {

       enemyinstance.GameFinish();
       a.GameFinish();
       b.GameFinish();
       c.GameFinish();
       d.GameFinish();
       e.GameFinish();
    //    f.GameFinish();
    //    g.GameFinish();
       
       GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy); // オブジェクトを削除
        }
        GameObject[] cadevars = GameObject.FindGameObjectsWithTag("cadevar");
        foreach (GameObject cadevar in cadevars)
        {
            Destroy(cadevar); 
        }
        SceneManager.LoadScene("home");
    }
}
