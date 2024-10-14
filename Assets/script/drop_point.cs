using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop_point : MonoBehaviour
{
    public bool On_off;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
        transform.position = new Vector3(transform.position.x,0,transform.position.z);

        float rightTriggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        if(On_off == true)
        {
        if(rightTriggerValue >= 0.2)
        {
         transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        }
        }
        
    }
    public void On()
    {
        On_off = true;

    }
    public void Off()
    {
    On_off = false;
    }
}
