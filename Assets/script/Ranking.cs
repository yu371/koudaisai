using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    // Start is called before the first frame update
  private TextMeshProUGUI textMeshProUGUI;
  private LocalRankingboard localRankingboard;
  private string text; 
  void Start()
  {
     localRankingboard = GameObject.FindWithTag("Ranking").GetComponent<LocalRankingboard>();
     textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    
  }
  void Update()
  {
   textMeshProUGUI.text = localRankingboard.text;
  }
}
