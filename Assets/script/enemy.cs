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

    void Start()
    {
        rd = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("target").transform;
        // NavMeshAgentコンポーネントの取得
        agent = GetComponent<NavMeshAgent>();
        score = GameObject.FindWithTag("text").GetComponent<score>();
    }

    void Update()
    {
    
        if (target != null)
        {
            // ターゲットの位置をNavMeshAgentに設定して移動
            agent.SetDestination(target.position);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "ballet")
        {
        Destroy(gameObject,5f);
        this.tag = "cadevar";
        score.Point();
        agent.isStopped = true;
        Vector3 pushDirection = other.GetComponent<Rigidbody>().velocity;
         pushDirection.y +=  50; 
         rd.AddForce(pushDirection, ForceMode.Impulse); 
         
        }
    }

}
