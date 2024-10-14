using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explanation : MonoBehaviour
{
    public GameObject explain; // 素材を変更したいGameObject
    public List<Material> materials = new List<Material>(); // 素材のリスト
    private int currentIndex = 0; // 現在の素材のインデックス
    private Renderer renderer; // Rendererコンポーネントの参照

    void Start()
    {
        // GameObjectが設定されている場合はRendererを初期化
        if (explain != null)
        {
            renderer = explain.GetComponent<Renderer>();
        }
    }

    void Update()
    {
        // 右矢印キーが押された場合に次の素材に切り替え
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CycleMaterial();
        }

        // 左矢印キーが押された場合に前の素材に戻す
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Back();
        }

        // OculusコントローラーのAボタンが押されたかどうかを確認
        if (OVRInput.GetDown(OVRInput.Button.One)) // Aボタン
        {
            CycleMaterial();
        }

        // OculusコントローラーのBボタンが押されたかどうかを確認
        if (OVRInput.GetDown(OVRInput.Button.Two)) // Bボタン
        {
            Back();
        }
    }

    void Back()
    {
        // 素材のインデックスを1つ減らし、リストの範囲内でラップアラウンドさせる
        currentIndex = (currentIndex - 1 + materials.Count) % materials.Count;

        // 前の素材をexplain GameObjectに適用
        if (explain != null && renderer != null && materials.Count > 0)
        {
            renderer.material = materials[currentIndex];
        }
    }

    void CycleMaterial()
    {
        // 素材のインデックスを1つ増やし、リストの範囲内でラップアラウンドさせる
        currentIndex = (currentIndex + 1) % materials.Count;

        // 素材が一周したらGameObjectを非表示にする
        if (currentIndex == 0)
        {
            explain.SetActive(false); // GameObjectを非表示にする
        }
        else
        {
            // 次の素材をexplain GameObjectに適用
            if (explain != null && renderer != null && materials.Count > 0)
            {
                renderer.material = materials[currentIndex];
            }
        }
    }

    public void Exs()
    {
        // GameObjectをアクティブにしてRendererを初期化する
        if (explain != null)
        {
            explain.SetActive(true);
            renderer = explain.GetComponent<Renderer>(); // Rendererを確実に初期化

            if (renderer != null && materials.Count > 0)
            {
                currentIndex = 0;
                renderer.material = materials[currentIndex]; // 最初の素材を適用
            }
        }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class explanation : MonoBehaviour
// {
//     public GameObject explain; // 素材を変更したいGameObject
//     public List<Material> materials = new List<Material>(); // 素材のリスト

//     public int currentIndex = 0; // 現在の素材のインデックス
//     private Renderer renderer; // Rendererコンポーネントの参照

//     void Start()
//     {
//         if (explain != null)
//         {
//             renderer = explain.GetComponent<Renderer>(); // Rendererコンポーネントの取得
//         }
//     }

//     void Update()
//     {
//         // 右矢印キーが押された場合に次の素材に切り替え
//         if (Input.GetKeyDown(KeyCode.RightArrow))
//         {
//             CycleMaterial();
//         }

//         // 左矢印キーが押された場合に前の素材に戻す
//         if (Input.GetKeyDown(KeyCode.LeftArrow))
//         {
//             Back();
//         }
//     }

//     void Back()
//     {
//         // 素材のインデックスを1つ減らし、リストの範囲内でラップアラウンドさせる
//         currentIndex = (currentIndex - 1 + materials.Count) % materials.Count;

//         // explain GameObjectに前の素材を適用
//         if (explain != null && renderer != null)
//         {
//             renderer.material = materials[currentIndex];
//         }
//     }

//     void CycleMaterial()
//     {
//         // 素材のインデックスを1つ増やし、リストの範囲内でラップアラウンドさせる
//         currentIndex = (currentIndex + 1) % materials.Count;

//         // explain GameObjectに次の素材を適用
//         if (explain != null && renderer != null && materials.Count > 0)
//         {
//             renderer.material = materials[currentIndex];
//         }
//     }
// }