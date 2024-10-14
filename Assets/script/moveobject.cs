using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveobject : MonoBehaviour
{
     public float speed = 2.0f;          // 移動速度
    public float distance = 5.0f;       // 移動する距離

    private Vector3 startPosition;      // オブジェクトの開始位置
    private int direction = 1;          // 移動方向（1は右、-1は左）

    void Start()
    {
        startPosition = transform.position;  // オブジェクトの初期位置を保存
    }

    void Update()
    {
        // 現在の位置と開始位置の距離を確認して、方向を反転する
        if (Vector3.Distance(startPosition, transform.position) >= distance)
        {
            direction *= -1;  // 移動方向を逆にする
        }

        // オブジェクトを現在の方向に向けて移動する
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
    }
}
