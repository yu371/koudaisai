using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Transform pos;
    public Vector3 minimap;
    public Vector3 map;
    private bool true_false;
    private Rigidbody rd;
    public GameObject copyobj;
    private GameObject copy;
  
    // Start is called before the first frame update
    void Start()
    {
        true_false = false;
        map = GameObject.FindWithTag("map").transform.position;
        minimap = GameObject.FindWithTag("minimap").transform.position;
        copy = Instantiate(copyobj,(transform.position - minimap)*80 + map,transform.rotation);

    if(copy != null)
    {
        pos = copy.transform;
    }
   
    }

    // Update is called once per frame
    void Update()
    {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        // if(pos != null)
        // {
        //        pos.position = (transform.position - minimap)*500 + map;
        // pos.rotation = transform.rotation; 
        // }
        if(true_false == true)
        {
        pos.position = (transform.position - minimap)*80 + map;
        pos.rotation = transform.rotation; 
        }
        
  
    }
    public void Grab()
    {
    pos = copy.transform;
    rd =copy.GetComponent<Rigidbody>();
    rd.isKinematic = true;
    rd.useGravity = false;
    true_false = true;

    } 
    public void ungrab()
    {
    rd.isKinematic = false;
    rd.useGravity = true;
    true_false = false;
    }
}
