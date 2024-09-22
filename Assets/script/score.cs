using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Samples;
using TMPro;
using UnityEngine;

public class score : MonoBehaviour
{
    public TextMeshProUGUI pointText;       // ポイント表示用のテキスト
    public TextMeshProUGUI pointListText;   // ポイントリスト表示用のテキスト
    public int point = 0;                   // 現在のポイント
    private List<int> pointList = new List<int>(); // ポイントのリスト
    public bool On_off1;
    public GameObject minimap;

    void Start()
    {   
    
        // LoadPoints(); 
        // UpdatePointList(); 
    Invoke("StartGame",60f);
     On_off1 = true;
     Invoke("off",60f);

    }

    public void Point()
    {
        point += 100; 
        UpdatePointText();
    }
   private float time;
    
    void Update()
    {
        if(On_off1 == true)
        {
          time += Time.deltaTime;
        //time変数をint型にし制限時間から引いた数をint型のlimit変数に代入
        int remaining = 60 - (int)time;
        //timerTextを更新していく
        pointText.text = $"のこり：{remaining.ToString("D3")}";
        }
      
    }

    // public void GameStart()
    // {
    //  Invoke("StartGame",60f);
    //  On_off = true;
    //  Invoke("off",60f);

    // }
    private void off()
    {
    On_off1 = false;
    }
    private void StartGame()
    {
         point = 0;
        UpdatePointText();
        Destroy(minimap);  
    }


    public void GameFinish()
    {
        AddPoint(); // ポイントを追加
        UpdatePointText(); // UIを更新
        GameObject.FindWithTag("Ranking").GetComponent<LocalRankingboard>().Scoresend(1000000);   
        }

    // ポイントを追加するメソッド
    public void AddPoint()
    {

        UpdatePointText(); // ポイント表示を更新
        // UpdatePointList(); // ポイントリストを更新
        // SavePoints(); // ポイントリストを保存
    }

    // ポイント表示を更新するメソッド
    void UpdatePointText()
    {
        pointText.text = "point: " + point;
    }

    // // ポイントリストを更新するメソッド
    // void UpdatePointList()
    // {
    //     pointListText.text = ""; // リストを初期化
    //     pointList.Sort((a, b) => b.CompareTo(a));

    //     // ソートされたリストを表示
    //     for (int i = 0; i < pointList.Count; i++)
    //     {
    //         pointListText.text += (i + 1) + ": " + pointList[i] + "\n";
    //     }
    // }
    void SavePoints()
    {
        string pointsString = string.Join(",", pointList);
        PlayerPrefs.SetString("PointList", pointsString);
        PlayerPrefs.Save();
    }

    // ポイントリストを読み込むメソッド
    // void LoadPoints()
    // {
    //     string pointsString = PlayerPrefs.GetString("PointList", "");
    //     if (!string.IsNullOrEmpty(pointsString))
    //     {
    //         // カンマ区切りの文字列をリストに再構築
    //         string[] pointsArray = pointsString.Split(',');
    //         foreach (string pointStr in pointsArray)
    //         {
    //             if (int.TryParse(pointStr, out int value))
    //             {
    //                 pointList.Add(value);
    //             }
    //         }
    //     }
    //     // UpdatePointList(); 
    // }
}
