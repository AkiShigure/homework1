using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPGunControl : MonoBehaviour
{
    public Transform firePoint;
    public GameObject firePre;
    public GameObject fireSparkPre;
    public Transform bulletPoint;
    public GameObject bulletPre;

    private int bulletCount=10;
    private float cd = 0.2f;
    private float timer = 0;
    public AudioSource gunPlayer;
    public AudioClip shoot;
    public AudioClip reload;
    Animator ani;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        gunPlayer = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > cd&&Input.GetMouseButton(0)&&bulletCount>0)
        {
            
            timer = 0;
            Instantiate(firePre, firePoint.position, firePoint.rotation);
            Instantiate(fireSparkPre, firePoint.position, firePoint.rotation);
            Instantiate(bulletPre, bulletPoint.position, bulletPoint.rotation);
            bulletCount--;
            text.text = bulletCount+"";
            gunPlayer.PlayOneShot(shoot);
            if (bulletCount == 0)
            {
                ani.SetTrigger("Reload");
                gunPlayer.PlayOneShot(reload);
                Invoke("Reload", 3.5f);
            }
           
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            bulletCount = 0;
            ani.SetTrigger("Reload");
            gunPlayer.PlayOneShot(reload);
            Invoke("Reload", 3.5f);
        }
        
    }

    void Reload()
    {
        bulletCount = 10;
        text.text = bulletCount + "";
    }
}
