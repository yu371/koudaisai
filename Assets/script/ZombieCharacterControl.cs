using UnityEngine;
using UnityEngine.AI;

public class ZombieCharacterControl : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;
    [SerializeField] private Transform m_target;  // ゾンビが追いかけるターゲット

    private NavMeshAgent m_navMeshAgent;
    private Vector3 m_currentDirection = Vector3.zero;

    private void Awake()
    {
        m_target = GameObject.FindWithTag("target").transform;
        if (!m_animator) { m_animator = gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { m_rigidBody = gameObject.GetComponent<Rigidbody>(); }

        m_navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

        if (m_navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component is missing on " + gameObject.name);
        }
        else
        {
            m_navMeshAgent.speed = m_moveSpeed;
            m_navMeshAgent.updateRotation = false;  // 自動回転をオフにする
        }
    }
    private score score;

    void Start()
    {
        m_target = GameObject.FindWithTag("target").transform;
        score = GameObject.FindWithTag("text").GetComponent<score>();
    }
    private void FixedUpdate()
    {
        if (m_target != null)
        {
            m_navMeshAgent.SetDestination(m_target.position);  // ターゲットに向かって移動

            Vector3 velocity = m_navMeshAgent.desiredVelocity;
            if (velocity != Vector3.zero)
            {
                m_currentDirection = Vector3.Slerp(m_currentDirection, velocity, Time.deltaTime * 10);
                transform.rotation = Quaternion.LookRotation(m_currentDirection);
            }

            m_animator.SetFloat("MoveSpeed", m_navMeshAgent.velocity.magnitude);
        }
        else
        {
            m_animator.SetFloat("MoveSpeed", 0);
        }
    }
      void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "ballet")
        {
        Destroy(gameObject,5f);
        this.tag = "cadevar";
        score.Point();
        m_navMeshAgent.isStopped = true;
        Vector3 pushDirection = other.GetComponent<Rigidbody>().velocity;
         pushDirection.y +=  50; 
         
         m_rigidBody.AddForce(pushDirection, ForceMode.Impulse); 
         
        }
    }
}
