using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPBulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 800);
    }

    // Update is called once per frame
   

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
