using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform target; // プレイヤーなどのターゲットを指定

    private NavMeshAgent agent;
    private score score;
    private Rigidbody rd;
    private Animator animator;
    private home Home;
    public float test;
    private AudioSource audioSource;
    void Start()
    {
        Home = GameObject.FindWithTag("Home").GetComponent<home>();
        animator = GetComponent<Animator>();
        animator.SetBool("Attack",false);
                animator.SetBool("run",true);
        rd = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("target").transform;
        // NavMeshAgentコンポーネントの取得
        agent = GetComponent<NavMeshAgent>();
        score = GameObject.FindWithTag("text").GetComponent<score>();
        
    }

    void Update()
    {
       test += Time.deltaTime;
        if (target != null)
        {
            // ターゲットの位置.seyをNavMeshAgentに設定して移動
            agent.SetDestination(target.position);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "ballet")
        {
        if(this.tag== "Golem")
        {
        Destroy(gameObject,5f);
        this.tag = "cadevar";
        score.Point();
        agent.isStopped = true;
        animator.SetBool("Death",true);
             animator.SetBool("Attack",false);
        }
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
    if(collisionInfo.gameObject.transform.tag == "build")
    {
    Vector3 pushDirection = rd.GetComponent<Rigidbody>().velocity*2;
    Rigidbody rd2 = collisionInfo.gameObject.GetComponent<Rigidbody>();
    pushDirection.y +=  100;
    rd2.AddForce(pushDirection, ForceMode.Impulse); 
    }
}
void OnTriggerStay(Collider other)
{
    if(this.tag != "cadevar")
    {
     if(other.transform.tag == "Home")
        {
            if(test >=3)
            {
         
             animator.SetBool("Attack",true);
              int damage = 10;
            Debug.Log("damage : " + damage);
            Home.currentHp = Home.currentHp - damage;
            Home.slider.value = (float)Home.currentHp / (float)Home.maxHp; ;
            if(Home.currentHp <= 0)
            {
            score.AddPoint();
            Home.GameFinish();
            }
            test = 0;
            }
        }
    }  
}
}
