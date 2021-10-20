using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPparaticle : MonoBehaviour
{
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 0)
        {
            this.GetComponent<ParticleSystem>().Play();
            StartCoroutine(Stop());
            i += 1;
        }
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<ParticleSystem>().Stop();
    }
}
