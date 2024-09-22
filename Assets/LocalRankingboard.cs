using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class LocalRankingboard : MonoBehaviour
{
       private static LocalRankingboard instance;
  private string Name;
    private int score;
    public string text;
    private Dictionary<string, int> newdic = new Dictionary<string, int>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);  // オブジェクトを破壊しないように設定
        }
        else if (instance != this)
        {
            // 既にインスタンスが存在する場合、このオブジェクトを破壊する
            Destroy(gameObject);
        }
    }
    void ClearOldData()
{
    PlayerPrefs.DeleteKey("A");
    newdic = new Dictionary<string, int>(); // 新しい辞書を初期化
}
    void Start()
    {
        LoadDictionary();
        UpdateRankingBoard();
    }

    // 名前を保存
    public void SaveName(string name)
    {
        Name = name;
    }

    // スコアを保存
    public void Scoresend(int ascore)
    {
        score = ascore;
        scoreAdd();
        UpdateRankingBoard();
    }

    // スコアを辞書に追加し、保存
    private void scoreAdd()
    {
        if (string.IsNullOrEmpty(Name))
        {
            Name = "noname";
        }

        // 既に同じ名前が存在する場合、スコアを比較して高い方を保持
        if (newdic.ContainsKey(Name))
        {
            if (newdic[Name] < score)  // 新しいスコアが高い場合は更新
            {
                newdic[Name] = score;
            }
        }
        else
        {
            newdic.Add(Name, score);  // 新しい名前の場合は追加
        }

        SaveDictionary();
    }

    // 辞書をシリアライズして保存する
    private void SaveDictionary()
    {
        string serializedDict = Serialize(newdic);
        PlayerPrefs.SetString("A", serializedDict);
        PlayerPrefs.Save();
    }

    // 辞書をデシリアライズして読み込む
    private void LoadDictionary()
    {
        if (PlayerPrefs.HasKey("A"))
        {
            string serializedDict = PlayerPrefs.GetString("A");
            newdic = Deserialize<Dictionary<string, int>>(serializedDict);
        }
        else
        {
            newdic = new Dictionary<string, int>();
        }
    }

    // 辞書をシリアライズする
    private string Serialize<T>(T obj)
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, obj);
            return Convert.ToBase64String(ms.ToArray());
        }
    }

    // 辞書をデシリアライズする
    private T Deserialize<T>(string str)
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(str)))
        {
            return (T)bf.Deserialize(ms);
        }
    }

    // ランキングボードを更新する（表示する）
    private void UpdateRankingBoard()
    {
        text = ""; 

        foreach (var entry in newdic.OrderByDescending(x => x.Value))
        {
            text += $"{entry.Key}: {entry.Value}\n";
        }
    }
}

