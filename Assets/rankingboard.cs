using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;


public class rankingboard : MonoBehaviour
{
 
    private TextMeshProUGUI textMeshProUGUI;
    private string myPlayFabId;
    private string displayName;

    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
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
            MaxResultsCount = 3          // 最大3人分の結果を取得
        };

        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboard, OnError);
    }

    // リーダーボード取得に成功したときの処理
    public void OnGetLeaderboard(GetLeaderboardResult result)
    {
        textMeshProUGUI.text = ""; // テキストをクリア
        foreach (var entry in result.Leaderboard)
        {
            // 自分のエントリーかどうかをチェックして名前を設定
            string nameToDisplay = entry.PlayFabId == myPlayFabId 
                ? displayName 
                : entry.DisplayName ?? "other";

            // ランキング順位、名前、スコアを表示
            textMeshProUGUI.text += $"{entry.Position + 1}: {nameToDisplay} {entry.StatValue}\n";
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
    public void UpdateDisplayName(string newName)
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = newName
        };

        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdated, OnError);
    }

    // 表示名が更新された時の処理
    private void OnDisplayNameUpdated(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("DisplayNameが更新されました: " + result.DisplayName);
        displayName = result.DisplayName; // 新しいDisplayNameを保存
    }
}
