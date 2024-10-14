using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Dynamic;

public class home : MonoBehaviour
{
  //最大HPと現在のHP。
    public int maxHp = 100;
    public int currentHp;
    //Sliderを入れる
    public Slider slider;
    public score score;
    public bool golemon_off = true;  // 攻撃がオンかオフかを制御するフラグ
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
   

    void OnTriggerStay(Collider other)
    {
        // Golemタグを持つオブジェクトに対する処理
    }
  
  
  
    
    // Golemが3秒おきに攻撃するコルーチン
    // Golemが攻撃をする関数
    public void GameStart()
    {
        //Sliderを満タンにする。
        slider.value = 1;
     
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
    }
 
    public void GameFinish()
    {

       
       GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy); // オブジェクトを削除
        }
          GameObject[] ghoost = GameObject.FindGameObjectsWithTag("instance");
        
        foreach (GameObject ghos in ghoost)
        {
            Destroy(ghos); // オブジェクトを削除
        }
          GameObject[] golems = GameObject.FindGameObjectsWithTag("Golem");
        
        foreach (GameObject enemy in golems)
        {
            Destroy(enemy); // オブジェクトを削除
        }
        GameObject[] cadevars = GameObject.FindGameObjectsWithTag("cadevar");
        foreach (GameObject cadevar in cadevars)
        {
            Destroy(cadevar); 
        }
        GameObject[] bigzon = GameObject.FindGameObjectsWithTag("bigzon");
        foreach (GameObject cadevar in bigzon)
        {
            Destroy(cadevar); 
        }
        Invoke("LoadScene",10f);
     
    }
    void LoadScene()
    {
    SceneManager.LoadScene("home");
    }
}
