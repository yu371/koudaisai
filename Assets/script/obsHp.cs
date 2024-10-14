using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class obsHp : MonoBehaviour
{
  public int maxHp = 100;
    public int currentHp;
    //Sliderを入れる
    public Slider slider;
    
     public GameObject sliderObject;

    // スライダーの表示・非表示を切り替える関数
    public void ToggleSlider()
    {
        // 現在のアクティブ状態を反転させる
        sliderObject.SetActive(true);
    
    }
    public void Offslider()
    {
         sliderObject.SetActive(false);
    }

        
    


    //  public enemyinstance f;
    // public enemyinstance g;
    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        Offslider();
    }
    void Update ()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "enemy")
        {
         ToggleSlider();
        }
        else if(other.transform.tag == "bigzon")
        {
          ToggleSlider();
        }
    }
    void OnTriggerExit(Collider other)
    {
         if(other.transform.tag == "enemy")
        {
        Invoke("Offslider",3f);
        }
         else if(other.transform.tag == "bigzon")
        {
        Invoke("Offslider",3f);
        }
    }
}
