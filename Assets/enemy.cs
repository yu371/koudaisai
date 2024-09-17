using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform target; // プレイヤーなどのターゲットを指定

    private NavMeshAgent agent;

    void Start()
    {
        target = GameObject.FindWithTag("target").transform;
        // NavMeshAgentコンポーネントの取得
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            // ターゲットの位置をNavMeshAgentに設定して移動
            agent.SetDestination(target.position);
        }
    }

}
