using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RGD : MonoBehaviour
{
      /// <summary>
    /// 射出するオブジェクト
    /// </summary>

    private GameObject ThrowingObject;

    /// <summary>
    /// 標的のオブジェクト
    /// </summary>
    [SerializeField, Tooltip("標的のオブジェクトをここに割り当てる")]
    private GameObject TargetObject;
    private Rigidbody rid;

    /// <summary>
    /// 射出角度
    /// </summary>
    [SerializeField, Range(0F, 90F), Tooltip("射出する角度")]
    private float ThrowingAngle;
    private Transform pos;
    public GameObject RPD;

    private void Start()
    {
        pos = transform;
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            // 干渉しないようにisTriggerをつける
            collider.isTrigger = true;
        }
    }

    private void Update()
    {
    
    }
  
    /// <summary>
    /// ボールを射出する
    /// </summary>
    public void ThrowingBall()
    {
        if (TargetObject != null)
        {
            // Ballオブジェクトの生成
            GameObject ball = gameObject;
             rid = ball.GetComponent<Rigidbody>();
            rid.isKinematic = false;

            // 標的の座標
            Vector3 targetPosition = TargetObject.transform.position;
            Destroy(TargetObject);
            // 射出角度
            float angle = ThrowingAngle;

            // 射出速度を算出
            Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);

            // 射出
            rid.AddForce(velocity * rid.mass, ForceMode.Impulse);
        }
        else
        {
            throw new System.Exception("射出するオブジェクトまたは標的のオブジェクトが未設定です。");
        }
    }

    /// <summary>
    /// 標的に命中する射出速度の計算
    /// </summary>
    /// <param name="pointA">射出開始座標</param>
    /// <param name="pointB">標的の座標</param>
    /// <returns>射出速度</returns>
    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        // 射出角をラジアンに変換
        float rad = angle * Mathf.PI / 180;

        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

        // 垂直方向の距離y
        float y = pointA.y - pointB.y;

        // 斜方投射の公式を初速度について解く
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }
    public GameObject bom;
        void OnTriggerEnter(Collider other)
    {
    if(other.transform.tag == "build" || other.transform.tag == "isground" )
    {
    Instantiate(bom,transform.position,Quaternion.identity);
    transform.position = new Vector3(0.959999979f,1.71000004f,-1.02999997f);
    transform.rotation = Quaternion.identity;
    rid.isKinematic = true;

    }

    }
}
