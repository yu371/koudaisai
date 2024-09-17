using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class city : MonoBehaviour
{
  [SerializeField] private Transform _parent;

    private void Start()
    {
        // 子オブジェクトを取得する
        var children = GetChildren(_parent);

        // 取得した子オブジェクト名をログ出力
        for (var i = 0; i < children.Length; i++)
        {
            
            children[i].name = i.ToString();
        }
    }

    // parent直下の子オブジェクトをforループで取得する
    private static Transform[] GetChildren(Transform parent)
    {
        // 子オブジェクトを格納する配列作成
        var children = new Transform[parent.childCount];

        // 0～個数-1までの子を順番に配列に格納
        for (var i = 0; i < children.Length; ++i)
        {
            children[i] = parent.GetChild(i);
        }

        // 子オブジェクトが格納された配列
        return children;
    }
}
