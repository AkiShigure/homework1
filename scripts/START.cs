using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class START : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void OnApplicationQuit()
    {
        Application.Quit();
    }

     public  void StartScene()
    {
        SceneManager.LoadScene("mainScene1");
    }
}
