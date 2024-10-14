using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class worldranking : MonoBehaviour
{
    // Start is called before the first frame update
  private TextMeshProUGUI textMeshProUGUI;
  private rankingboard localRankingboard;
  private string text; 
  void Start()
  {
     localRankingboard = GameObject.FindWithTag("worldranking").GetComponent<rankingboard>();
     textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    
  }
  void Update()
  {
   if(localRankingboard.text != null)
   {
       textMeshProUGUI.text = localRankingboard.text;
   }

  }
}
