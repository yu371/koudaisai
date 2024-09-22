using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{
    // Start is called before the first frame upda
 
    void Start()
    {
      Invoke("ChangeScene",10f);
    }
    // Update is called once per frame
    void Update () {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("test");
    }
}
