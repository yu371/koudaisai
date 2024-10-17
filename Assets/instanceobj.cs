using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanceobj : MonoBehaviour
{
   public GameObject cubePrefab;
    
    // Cubeのサイズ
    public Vector3 cubeSize = new Vector3(1f, 1f, 1f);
    
    // Cubeを敷き詰める親オブジェクト
    public GameObject parentObject;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // 親オブジェクトのBoundsを取得
        Renderer parentRenderer = parentObject.GetComponent<Renderer>();
        if (parentRenderer == null)
        {
            Debug.LogError("親オブジェクトにRendererがありません");
            return;
        }

        Bounds parentBounds = parentRenderer.bounds;

        // 親オブジェクトのサイズを取得
        Vector3 parentSize = parentBounds.size;

        // 親オブジェクトの範囲内でCubeを敷き詰める
        for (float x = parentBounds.min.x; x < parentBounds.max.x; x += cubeSize.x)
        {
            
                for (float z = parentBounds.min.z; z < parentBounds.max.z; z += cubeSize.z)
                {
                    // 位置を計算
                    Vector3 position = new Vector3(x, 1f, z);

                    
                    // Cubeを生成して親オブジェクトの子として配置
                    GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity, parentObject.transform);
                }
            
        }
    }
}

