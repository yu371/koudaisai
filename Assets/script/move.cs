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
        true_false = true;
        map = GameObject.FindWithTag("map").transform.position;
        minimap = GameObject.FindWithTag("minimap").transform.position;
        copy = Instantiate(copyobj,(transform.position - minimap)*80 + map,transform.rotation);
        Invoke("test",5f);

    if(copy != null)
    {
        pos = copy.transform;
    }
   
    }
    public void test()
    {
        true_false = false;
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
    true_false = true;

    } 
    public void ungrab()
    {
    true_false = false;
    }
}
