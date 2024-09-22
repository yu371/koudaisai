using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Samples;
using TMPro;
using UnityEngine;

public class score : MonoBehaviour
{
    public TextMeshProUGUI pointText;       // ポイント表示用のテキスト
    public TextMeshProUGUI pointListText;   // ポイントリスト表示用のテキスト
    private int point = 0;                   // 現在のポイント
    private List<int> pointList = new List<int>(); // ポイントのリスト
    void Start()
    {
        LoadPoints(); 
        UpdatePointText(); 
        UpdatePointList(); 
    }

    public void Point()
    {
        point += 100; 
        UpdatePointText();
    }

    public void GameStart()
    {
        point = 0;
        UpdatePointText();

    }

    public void GameFinish()
    {
        AddPoint(); // ポイントを追加
        UpdatePointText(); // UIを更新
    }

    // ポイントを追加するメソッド
    public void AddPoint()
    {
        pointList.Add(point); // 現在のポイントをリストに追加
        UpdatePointText(); // ポイント表示を更新
        UpdatePointList(); // ポイントリストを更新
        SavePoints(); // ポイントリストを保存
    }

    // ポイント表示を更新するメソッド
    void UpdatePointText()
    {
        pointText.text = "point: " + point;
    }

    // ポイントリストを更新するメソッド
    void UpdatePointList()
    {
        pointListText.text = ""; // リストを初期化
        pointList.Sort((a, b) => b.CompareTo(a));

        // ソートされたリストを表示
        for (int i = 0; i < pointList.Count; i++)
        {
            pointListText.text += (i + 1) + ": " + pointList[i] + "\n";
        }
    }
    void SavePoints()
    {
        string pointsString = string.Join(",", pointList);
        PlayerPrefs.SetString("PointList", pointsString);
        PlayerPrefs.Save();
    }

    // ポイントリストを読み込むメソッド
    void LoadPoints()
    {
        string pointsString = PlayerPrefs.GetString("PointList", "");
        if (!string.IsNullOrEmpty(pointsString))
        {
            // カンマ区切りの文字列をリストに再構築
            string[] pointsArray = pointsString.Split(',');
            foreach (string pointStr in pointsArray)
            {
                if (int.TryParse(pointStr, out int value))
                {
                    pointList.Add(value);
                }
            }
        }
        UpdatePointList(); 
    }
}
