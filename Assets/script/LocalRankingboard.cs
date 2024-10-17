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
    private float score;
    public string text;
    private Dictionary<string,float > newdic = new Dictionary<string, float>();
    private int i;

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
    newdic = new Dictionary<string, float>(); // 新しい辞書を初期化
}
    void Start()
    {
        LoadDictionary();
           i =1;
        UpdateRankingBoard();
    }

    // 名前を保存
    public void SaveName(string name)
    {
        Name = name;
        PlayerPrefs.SetString("Name",Name);
        PlayerPrefs.Save();
    }

    // スコアを保存
    public void Scoresend(float ascore)
    {
        score = ascore;
        scoreAdd();
           i =1;
        UpdateRankingBoard();
     
    }

    // スコアを辞書に追加し、保存
    private void scoreAdd()
    {
        Name = PlayerPrefs.GetString("Name","NoName");
        if (string.IsNullOrEmpty(Name))
        {
            Name = "noname";
        }

        // 既に同じ名前が存在する場合、スコアを比較して高い方を保持
        if (newdic.ContainsKey(Name))
        {
            if (newdic[Name] > score)  // 新しいスコア低い場合は更新
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
            newdic = Deserialize<Dictionary<string, float>>(serializedDict);
        }
        else
        {
            newdic = new Dictionary<string, float>();
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
        
        int K =0;
        text = ""; 

        foreach (var entry in newdic.OrderBy(x => x.Value))
        {
            K+=1;
            if(K >=i && K<i+5)
            {
             if (newdic.ContainsKey(entry.Key))
             {
            string sc = "";
            if(entry.Value <= 40f)
            {
            sc = "SS";
            }
            else if(entry.Value <= 50f)
            {
            sc = "S";
            }
               else if(entry.Value <= 60f)
            {
            sc = "A";
            }
               else if(entry.Value <= 70f)
            {
            sc = "B";
            }
               else if(entry.Value <= 90f)
            {
            sc = "C";
            }
               else if(entry.Value <= 500)
            {
            sc = "D";
            }
            else
            {
            sc = "Z";
            }
            text += $"{K}位:{entry.Key}: {entry.Value+"秒"}:{sc}\n";
             }
             else
             {
              text += "nodate\n";
             }
            }
        }
    }
    
    public void Plus_i()
    {
    
    i+=5;
    UpdateRankingBoard();
    }
    public void Minus_i()
    {
    if(i >= 6)
    {
    i-=5;
    UpdateRankingBoard();
    }
    }
}

