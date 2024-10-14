using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsinstance : MonoBehaviour
{
    // GameObjectのリストを作成
    public List<GameObject> objectList;

    // 生成する位置
    public Transform spawnPosition;
    void Start()
    {
        SpawnRandomObjects(15);
    }

    // GameObjectをランダムに選んで生成する関数
    public void SpawnRandomObjects(int numberOfObjects)
    {
         spawnPosition = transform;
        for (int i = 0; i < numberOfObjects; i++)
        {
            // リストの中からランダムに1つ選ぶ
            int randomIndex = Random.Range(0, objectList.Count);
            GameObject selectedObject = objectList[randomIndex];
            spawnPosition.position +=new Vector3(0,0.05f,0);

            // 選ばれたGameObjectを生成（指定した位置で）
            Instantiate(selectedObject, spawnPosition.position, spawnPosition.rotation);
        }
    }
}
