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
    private Rigidbody rd;
    // Start is called before the first frame update
    void Start()
    {
        true_false = false;
        map = GameObject.FindWithTag("map").transform.position;
        minimap = GameObject.FindWithTag("minimap").transform.position;
        textMeshProUGUI = GameObject.FindWithTag("text").GetComponent<TextMeshProUGUI>();
        
    GameObject copy = GameObject.Find("a"+this.name);
    if(copy != null)
    {
        pos = copy.transform;
    rd =copy.GetComponent<Rigidbody>();
    rd.isKinematic = true;
    true_false = true;  
    }
   
    }

    // Update is called once per frame
    void Update()
    {
        // if(pos != null)
        // {
        //        pos.position = (transform.position - minimap)*500 + map;
        // pos.rotation = transform.rotation; 
        // }
        if(true_false == true)
        {
        pos.position = (transform.position - minimap)*500 + map;
        pos.rotation = transform.rotation; 
        }
        
  
    }
    public void Grab()
    {
    GameObject copy = GameObject.Find("a"+this.name);
    pos = copy.transform;
    rd =copy.GetComponent<Rigidbody>();
    rd.isKinematic = true;
    true_false = true;

    } 
    public void ungrab()
    {
    rd.isKinematic = false;
    true_false = false;
    }

}