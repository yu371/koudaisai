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
    private home Home;
    public float span;
    private bool Death_check = false;
    private obsHp obsHp;

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
    public void Death()
    {
        Destroy(gameObject,5f);
        this.tag = "cadevar";
        m_navMeshAgent.isStopped = true;
        m_animator.SetBool("Dead",true);
        m_animator.SetBool("Attack",false);    
    }
    private score score;
    public int zonbicount;

    void Start()
    {

        Home = GameObject.FindWithTag("Home").GetComponent<home>();
        m_target = GameObject.FindWithTag("target").transform;
        score = GameObject.FindWithTag("text").GetComponent<score>();
        zonbicount =  GameObject.Find("zonbicounter").GetComponent<zonbicounter>().zonbicount;
        
    }
    private void FixedUpdate()
    {
        span+= Time.deltaTime;
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
        if(this.tag != "cadevar")
        {
         Destroy(gameObject,3f);
        this.tag = "cadevar";
        score.Point();
        m_navMeshAgent.isStopped = true;
        m_animator.SetBool("Dead",true);
        m_animator.SetBool("Attack",false);
        Death_check = false;
        GameObject.Find("zonbicounter").GetComponent<zonbicounter>().zonbicount +=1;
        }
         
        }
        if(other.gameObject.tag == "build")
        {
        obsHp = other.GetComponent<obsHp>();
        }
        else if(other.transform.tag == "rocket")
        {
         Destroy(gameObject,3f);
        this.tag = "cadevar";
        score.Point();
        m_navMeshAgent.isStopped = true;
        m_animator.SetBool("Dead",true);
        m_animator.SetBool("Attack",false);
        Death_check = false;
        GameObject.Find("zonbicounter").GetComponent<zonbicounter>().zonbicount +=1;  
        }
        
    }
   private void OnTriggerStay(Collider other)
    {
            
        if(this.tag != "cadevar")
        {
         if(other.gameObject.transform.tag == "Home")
        {
            if(span >= 3)
            {
            m_animator.SetBool("Attack",true);
            int damage = 5;
            Debug.Log("damage : " + damage);
            Home.currentHp = Home.currentHp - damage;
            Home.slider.value = (float)Home.currentHp / (float)Home.maxHp; 
            if(Home.currentHp <= 0)
            {
            score.AddPoint();
            Home.GameFinish();
            score.GameFinish();
            }
            span =0;
            }
        }
         if(other.gameObject.transform.tag == "build")
        {
            if(span >= 3)
            {
       
            m_animator.SetBool("Attack",true);
            int damage = 5;
            Debug.Log("damage : " + damage);
            obsHp.currentHp = obsHp.currentHp - damage;
            obsHp.slider.value = (float)obsHp.currentHp / (float)obsHp.maxHp; 
            if(obsHp.currentHp <= 0)
            {
            Destroy(other.gameObject);
            m_animator.SetBool("Attack",false);
            }
            span =0;
            }
        }
        }   
    }
}
