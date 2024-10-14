using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus_Minus : MonoBehaviour
{
    // Start is called before the first frame update
    
    private LocalRankingboard localRankingboard;
    void Start()
    {
    localRankingboard = GameObject.FindWithTag("Ranking").GetComponent<LocalRankingboard>();
    }
    public void Plus()
    {
    localRankingboard.Plus_i();
    }
    public void Minus()
    {
    localRankingboard.Minus_i();
    }
    // Update is called once per frame
}
