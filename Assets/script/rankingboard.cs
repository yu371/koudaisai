using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;


public class rankingboard : MonoBehaviour
{
        private static rankingboard world;
 
    private TextMeshProUGUI textMeshProUGUI;
    private string myPlayFabId;
    private string displayName;
    
    private int i;
     public string text;
      void Awake()
    {
        if (world == null)
        {
            world = this;
            DontDestroyOnLoad(this.gameObject);  // オブジェクトを破壊しないように設定
        }
        else if (world != this)
        {
            // 既にインスタンスが存在する場合、このオブジェクトを破壊する
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        LoginAsGuest(); // ゲストとしてログイン
        
    }

    // PlayFabにゲストとしてログイン
    public void LoginAsGuest()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier, // デバイス固有IDを使用
            CreateAccount = true                          // アカウントがなければ自動作成
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    // ログイン成功時の処理
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("PlayFabへのゲストログイン成功！");
        myPlayFabId = result.PlayFabId; // PlayFabIDを保存

        // アカウント情報を取得してディスプレイネームを取得
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest { PlayFabId = myPlayFabId }, OnGetAccountInfo, OnError);
        
    }

    // アカウント情報取得成功時の処理
    private void OnGetAccountInfo(GetAccountInfoResult result)
    {
        displayName = result.AccountInfo.TitleInfo.DisplayName ?? "you"; // DisplayNameを取得、nullなら"you"
        Debug.Log("ディスプレイネーム取得: " + displayName);
        GetLeaderboard();
    }

    // ログイン失敗時の処理
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("ゲストログイン失敗: " + error.GenerateErrorReport());
    }

    // リーダーボードのデータを取得するメソッド
    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "HighScore", // 統計データ名（スコア）を指定
            StartPosition = 0,           // リーダーボードの最初の位置から取得
            MaxResultsCount = 10       // 最大3人分の結果を取得
        };

        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboard, OnError);
    }

    // リーダーボード取得に成功したときの処理
    public void OnGetLeaderboard(GetLeaderboardResult result)
    {
        // textMeshProUGUI.text = ""; // テキストをクリア
        // foreach (var entry in result.Leaderboard)
        // {
        //     // 自分のエントリーかどうかをチェックして名前を設定
        // string nameToDisplay = entry.PlayFabId == myPlayFabId 
        //         ? displayName 
        //         : entry.DisplayName ?? "Noname";

        //     // ランキング順位、名前、スコアを表示
        //     textMeshProUGUI.text += $"{entry.Position + 1}: {nameToDisplay} {entry.StatValue}\n";
        // }
         int K =0;
        text = ""; 

        foreach (var entry in result.Leaderboard)
        {
            K+=1;
                     // 自分のエントリーかどうかをチェックして名前を設定
            string nameToDisplay = entry.PlayFabId == myPlayFabId 
                ? displayName 
                : entry.DisplayName ?? "Noname";
            if(K >=i && K<i+5)
            { 
            text += $"{entry.Position + 1}: {nameToDisplay} {entry.StatValue}\n";
            }
        }
    }

    // エラーが発生したときの処理
    private void OnError(PlayFabError error)
    {
        Debug.LogError("リーダーボード取得中にエラーが発生しました: " + error.GenerateErrorReport());
    }

    // スコア送信メソッド
public void SendScore(int newScore)
{
    // 現在のスコアを取得
    PlayFabClientAPI.GetPlayerStatistics(new GetPlayerStatisticsRequest(), result =>
    {
        int currentHighScore = 0;

        foreach (var statistic in result.Statistics)
        {
            if (statistic.StatisticName == "HighScore")
            {
                currentHighScore = statistic.Value;
                break;
            }
        }

        // 新しいスコアが現在のスコアより高い場合のみ送信
        if (newScore > currentHighScore)
        {
            var scoreRequest = new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
                {
                    new StatisticUpdate { StatisticName = "HighScore", Value = newScore }
                }
            };

            PlayFabClientAPI.UpdatePlayerStatistics(scoreRequest, OnStatisticsUpdate, OnError);
        }
        else
        {
            Debug.Log("新しいスコアが以前のスコアより低いため、送信しませんでした。");
        }
    }, OnError);
}


    // スコア送信後の処理
    private void OnStatisticsUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("スコアが更新されました!");
        GetLeaderboard(); // スコア送信後にリーダーボードを取得
    }

    // 表示名を変更するメソッド
    public void SetPlayerDisplayName (string displayName) {
	PlayFabClientAPI.UpdateUserTitleDisplayName(
		new UpdateUserTitleDisplayNameRequest {
			DisplayName = displayName
		},
		result => {
			Debug.Log("Set display name was succeeded.");
		},
		error => {
			Debug.LogError(error.GenerateErrorReport());
		}
	);
}
}
