using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FPEnemyController : MonoBehaviour
{
    public event Action<int, int> UpdateHealthBarOnAttack;
    private int blood=5;
    public float xOffset;
    public float yOffset;
    public GameObject player;
    
   
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        
        
        
        if (blood == 0)
        {
            player.GetComponent<end>().enemyCount -= 1;
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            blood--;
            UpdateHealthBarOnAttack?.Invoke(blood, 5);
        }
    }

   
}
