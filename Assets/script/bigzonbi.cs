using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class bigzonbi : MonoBehaviour
{
    // Start is called before the first frame update
     public Transform target; // プレイヤーなどのターゲットを指定
    private score score;
    private Rigidbody rd;
    private Animator animator;
    private bool on_off;
    private home Home;
    public obsHp obsHp;
    private AudioSource audioSource;


    void Start()
    {
         slider.value = 1;
        currentHp = maxHp;
        Home = GameObject.FindWithTag("Home").GetComponent<home>();
        on_off = true;
        animator = GetComponent<Animator>();
       
        animator.SetBool("Attack",false);
        rd = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("target").transform;
        score = GameObject.FindWithTag("text").GetComponent<score>();
          RotateTowardsTarget();
          audioSource = GetComponent<AudioSource>();
     
    }
    
      void RotateTowardsTarget()
    {
        if (target != null)
        {
            // ターゲットの方向を取得
            Vector3 direction = target.position - transform.position;

            // 方向を基に回転を計算
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // オブジェクトをターゲットの方向に一瞬で向ける
            transform.rotation = targetRotation;
        }
    }
       public float speed = 5f;

    void Update()
    {
        if(on_off == true)
        {
            float step = speed * Time.deltaTime;  // 1フレームごとの移動距離

        // オブジェクトの位置を目的地へ向かって更新
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        // 目的地までの距離を計算
    }
        public Material sky;
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "ballet")
        {
        
        if(this.tag != "cadevar")
        {
            float damage = 0.5f;
            Debug.Log("damage : " + damage);
            currentHp = currentHp - damage;
            slider.value = (float)currentHp / (float)maxHp;
            if(currentHp <= 0)
            {
            GameObject.FindWithTag("Ranking").GetComponent<LocalRankingboard>().Scoresend(score.gametime);
            RenderSettings.skybox = sky;
            animator.SetBool("Death",true);
            score.GameWin();
            Home.GameFinish();
            Destroy(gameObject);
            score.customPoint(10000);
            }
        }
        }
        if(other.transform.tag == "rocket")
        {
           if(this.tag != "cadevar")
        {
            float damage = 5f;
            Debug.Log("damage : " + damage);
            currentHp = currentHp - damage;
            slider.value = (float)currentHp / (float)maxHp;
            if(currentHp <= 0)
            {
            GameObject.FindWithTag("Ranking").GetComponent<LocalRankingboard>().Scoresend(score.gametime);
            RenderSettings.skybox = sky;
            animator.SetBool("Death",true);
            score.GameWin();
            Home.GameFinish();
            Destroy(gameObject);
            }
        }
        }
        
    }
        public float maxHp = 100;
    public float currentHp;
    //Sliderを入れる
    public Slider slider;

    public float span;
    void OnTriggerStay(Collider other)
    {
        
        if(this.tag != "cadevar")
        {
        
        if(other.transform.tag == "Home")
        {
            span += Time.deltaTime;
             animator.SetBool("Dead",true);
            if(span >= 3)
            {
            span = 0;
             on_off = false;
            
             int damage = 100;
            Debug.Log("damage : " + damage);
            Home.currentHp = Home.currentHp - damage;
            Home.slider.value = (float)Home.currentHp / (float)Home.maxHp; 
            if(Home.currentHp <= 0)
            {
            score.GameFinish();
            Home.GameFinish();
            Destroy(gameObject,2f);
            }
            }
           
        }
          
        }
    }
    public void Win()
    {
    
    }
    public void Lose()
    {

    }
     public float rotationSpeed = 10f; 

}
