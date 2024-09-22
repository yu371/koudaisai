using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textform : MonoBehaviour
{
      private TouchScreenKeyboard overlayKeyboard;
    public static string inputText = "";
    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Aボタンを押した時にシステムキーボードを出す例
if (OVRInput.GetDown(OVRInput.Button.One))
{
	overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    textMeshProUGUI.text = overlayKeyboard.text;
}
 
    }
}
