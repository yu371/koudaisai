using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textform : MonoBehaviour
{
      private TouchScreenKeyboard overlayKeyboard;
    public static string inputText = "";
    public LocalRankingboard localRankingboard;
    public rankingboard Rankingboard;
    public TextMeshProUGUI textMeshProUGUI;
    private bool On_off;
    

    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
    On_off = true;
    textMeshProUGUI.text = "名前登録";
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Kettei()
    {
     Rankingboard.SetPlayerDisplayName(overlayKeyboard.text);
     localRankingboard.SaveName(overlayKeyboard.text);
    }
    public void Keyboard()
    {
     if(On_off == true)
     {
     On_off = false;
     overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    textMeshProUGUI.text = "決定";
     }
     else
     {
        Kettei();
        On_off = true;
        textMeshProUGUI.text = "名前変更";
     }
    }
}
