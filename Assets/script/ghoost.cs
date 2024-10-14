using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ghoost : MonoBehaviour
{
  public Transform target; // プレイヤーなどのターゲットを指定
    private score score;
    private Rigidbody rd;
    private Animator animator;
    private bool on_off;
    private home Home;
    
    private AudioSource audioSource;



    void Start()
    {
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
        span += Time.deltaTime;
        if(on_off == true)
        {
            float step = speed * Time.deltaTime;  // 1フレームごとの移動距離

        // オブジェクトの位置を目的地へ向かって更新
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        // 目的地までの距離を計算
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "ballet")
        {
        if(this.tag != "cadevar")
        {
       Destroy(gameObject,0.1f);
        this.tag = "cadevar";
        score.Point();
         on_off = false;
         animator.SetBool("Death",true );
        animator.SetBool("Attack",false);
        }

        }
        
    }
    private float span;
    void OnTriggerStay(Collider other)
    {
        if(this.tag != "cadevar")
        {
   if(other.transform.tag == "Home")
        {
            if(span >= 3)
            {
            audioSource.PlayOneShot(audioSource.clip);
            
            span = 0;
             on_off = false;
             animator.SetBool("Attack",true);
             int damage = 5;
            Debug.Log("damage : " + damage);
            Home.currentHp = Home.currentHp - damage;
            Home.slider.value = (float)Home.currentHp / (float)Home.maxHp; ;
            if(Home.currentHp <= 0)
            {
            score.AddPoint();
            Home.GameFinish();
            }
            }
           
        }
        }
    }
     public float rotationSpeed = 10f; 


}
