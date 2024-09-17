using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Samples;
using TMPro;
using UnityEngine;

public class grab_move : MonoBehaviour
{
    public Transform pos;
    public Vector3 minimap;
    public Vector3 map;
    private bool true_false;
    private TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        true_false = false;
        map = GameObject.FindWithTag("map").transform.position;
        minimap = GameObject.FindWithTag("minimap").transform.position;
        textMeshProUGUI = GameObject.FindWithTag("text").GetComponent<TextMeshProUGUI>();
        
                
    }

    // Update is called once per frame
    void Update()
    {
        if(true_false == true)
        {
        pos.position = (transform.position - minimap)*1000 + map;
        pos.rotation = transform.rotation; 
        }
  
    }
    public void Grab()
    {
    pos = GameObject.Find("a" +this.name).transform;
    true_false = true;
    } 
    public void ungrab()
    {
    true_false = false;
    }

}