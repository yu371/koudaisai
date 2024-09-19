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
        var children = new Transform[parent.childCount];
        for (var i = 0; i < children.Length; ++i)
        {
            children[i] = parent.GetChild(i);
        }
        return children;
    }
}
