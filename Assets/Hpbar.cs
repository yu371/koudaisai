using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hpbar : MonoBehaviour
{
  //最大HPと現在のHP。
    int maxHp = 100;
    int currentHp;
    //Sliderを入れる
    public Slider slider;

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
        transform.rotation = Camera.main.transform.rotation;
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnTriggerEnter(Collider collider)
    {
        //Enemyタグのオブジェクトに触れると発動
        if (collider.gameObject.tag == "Enemy")
        {
            int damage = Random.Range(1, 5);
            Debug.Log("damage : " + damage);
            currentHp = currentHp - damage;
            slider.value = (float)currentHp / (float)maxHp; ;
      
        }
    }
}
