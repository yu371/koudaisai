using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objinstance : MonoBehaviour
{
    public Vector3 pos;
    public Vector3 minimap;
    public Vector3 map;
    private bool hasSpawned = false; // true_falseを説明的な名前に変更
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindWithTag("map").transform.position;
        minimap = GameObject.FindWithTag("minimap").transform.position;

        // 初期位置の計算
        pos = (transform.position - minimap) * 80 + map;
    }

    void OnTriggerEnter(Collider other)
    {
        HandleCollision(other);
    }

    void OnCollisionEnter(Collision other)
    {
        HandleCollision(other.collider); // OnCollisionEnter でも同じ処理を実行
    }

    private void HandleCollision(Collider other)
    {
        if (other.CompareTag("Player") && !hasSpawned)
        {
            // オブジェクトの生成と上昇処理
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        pos = (transform.position - minimap) * 80 + map;
        GameObject test = Instantiate(obj, new Vector3(pos.x, -0.5f, pos.z * 2) + new Vector3(0, 0, -map.z), Quaternion.identity);

        // オブジェクトをゆっくり上昇させる
        StartCoroutine(Rise(test));
        hasSpawned = true; // 一度だけ生成されるように
    }
    public void Push()
    {
        
    }
    IEnumerator Rise(GameObject obj)
    {
        float targetHeight = 1f;
        float speed = 0.3f;

        while (obj.transform.position.y < targetHeight)
        {
            obj.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            yield return null;
        }
    }
}